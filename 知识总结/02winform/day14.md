# day14｜TCP网络通信、SerialPort串口、Modbus协议 结构化总结

> 工业上位机核心通信章节；重点：TcpListener/TcpClient服务端客户端、异步网络收发、SerialPort串口、Modbus‑RTU/ASCII/TCP，NModbus4库使用。

## 一、网络基础：TCP/IP分层模型

| 分层       | 核心功能           | 典型协议        |
| ---------- | ------------------ | --------------- |
| 应用层     | 应用程序业务数据   | HTTP、DNS、TFTP |
| 传输层     | 端到端传输         | **TCP、UDP**    |
| 网络层     | 路由寻址           | IP、ICMP        |
| 数据链路层 | 帧传输、错误检测   | ARP、PPP        |
| 物理层     | 比特流物理介质传输 | 硬件电气信号    |

> TCP特点：面向连接、可靠传输、三次握手、数据不会丢失乱序；工业设备通信大量使用TCP。

## 二、TCP通信（`System.Net.Sockets`）

### 核心类

1. `TcpListener`：**TCP服务端**，监听IP+端口，等待客户端接入。
2. `TcpClient`：TCP客户端，主动连接服务端。
3. `NetworkStream`：网络数据流，**字节流读写**；所有收发都是`byte[]`字节数组。
4. `CancellationTokenSource`：异步取消令牌，安全终止`AcceptAsync`、`ReadAsync`，防止程序卡死。

> 端口范围：0‑65535；1‑1023系统占用，业务建议使用大于10000端口。

### ✨服务端工作流程

1. `IPAddress.Parse()`解析IP；实例化`TcpListener(ip,port)`
2. `Start()`启动监听
3. `await AcceptTcpClientAsync(token)`异步等待客户端连接
4. 拿到TcpClient，获取`NetworkStream`网络流
5. 循环`ReadAsync()`接收字节；`WriteAsync()`发送字节；**字节与字符串通过Encoding.UTF8互相转换**
6. 结束：停止监听、关闭客户端、释放资源；使用`CancellationToken`做异步取消。

> 注意：同步`Accept()`、`Read()`会阻塞UI线程；WinForm上位机必须使用**Async异步版本**。

### ✨客户端工作流程

1. new `TcpClient()`
2. `await ConnectAsync(ip,port,token)`连接服务端
3. 获取`NetworkStream`流
4. 循环异步Read接收数据；Write发送字节数据
5. 断开：取消令牌、关闭流、关闭TcpClient，置空对象。

### 重要知识点

1. 网络只能收发

   字节数组byte[]

   ：

   ```
   //字符串 → 字节数组（发送）
   byte[] sendBuf = Encoding.UTF8.GetBytes(str);
   //字节数组 → 字符串（接收）
   string recvStr = Encoding.UTF8.GetString(buf,0,readLen);
   ```

2. `ReadAsync`返回`readLen=0`代表**对方客户端已经断开连接**。

3. WinForm中网络接收回调属于子线程，更新UI控件必须使用`Control.Invoke`封送到UI主线程。

4. `CancellationTokenSource`用于安全取消异步IO；窗体关闭事件中执行停止服务/断开客户端，释放资源。

5. 简易聊天室作业：服务器接收消息，广播转发给所有已连接客户端（多客户端群聊）。

### 易错点

1. 不要在UI线程调用同步阻塞`Accept()`、`Read()`，直接卡死界面，全部使用`‑Async`异步。
2. 网络异常要捕获SocketException；连接断开之后要重置对象，防止`ObjectDisposedException`对象已释放异常。
3. 字节流是流式，TCP无消息边界；简单demo按字符串收发；真实项目需要**自定义协议分包（长度头/结束符）**。

## 三、SerialPort 串口通信

> NuGet包：`System.IO.Ports`；工业PLC、传感器、扫码枪常用RS232/RS485。

### 串口关键参数

- 串口号 COMx；波特率；校验位`Parity`；数据位；停止位`StopBits`

```
SerialPort sp = new SerialPort("COM1",9600,Parity.None,8,StopBits.One);
sp.Open(); //打开串口
Stream stream = sp.BaseStream; //拿到底层数据流，支持ReadAsync / WriteAsync
```

### 流程

1. 实例SerialPort，配置串口参数
2. `Open()`打开串口；捕获异常：串口被占用、串口不存在
3. 通过`BaseStream`异步循环`ReadAsync()`接收字节；`WriteAsync()`发送字节数组
4. 窗体关闭：`cts.Cancel()`取消循环，`sp.Close()`、`sp.Dispose()`释放串口资源。

> 常见异常

- `UnauthorizedAccessException`：串口被别的程序占用
- `IOException`：串口设备不存在

> 测试工具：虚拟串口模拟器，虚拟COM1‑COM2互相调试，不用真实硬件。

## 四、Modbus工业总线协议

> Modbus分为3种实现：

1. Modbus‑RTU：串口RS485最常用
2. Modbus‑ASCII：串口，极少使用
3. Modbus‑TCP：以太网TCP，端口默认502

### 角色

- **主站(Master)**：发起读写请求（我们写的上位机软件）
- **从站(Slave)**：PLC、传感器设备，每个从站拥有唯一SlaveId（1‑247）

### Modbus四类存储区

| 存储区                      | 类型   | 说明                       |
| --------------------------- | ------ | -------------------------- |
| 线圈 Coils                  | bool   | 可读写，开关量输出         |
| 离散输入Inputs              | bool   | **只读**，开关量输入       |
| 保持寄存器 HoldingRegisters | ushort | 可读写，16位寄存器，最常用 |
| 输入寄存器 InputRegisters   | ushort | **只读**                   |

### NModbus4库（NuGet）

#### Modbus‑RTU（串口）

```
SerialPort sp = new SerialPort("COM1",9600,Parity.None,8,StopBits.One);
sp.Open();
IModbusSerialMaster master = ModbusSerialMaster.CreateRtu(sp);
master.Transport.ReadTimeout = 2000;
master.Transport.Retries = 3;

//读保持寄存器
ushort[] arr = master.ReadHoldingRegisters(slaveAddress:1,startAddress:0,numberOfPoints:5);
//写单个保持寄存器
master.WriteSingleRegister(1,2,1234);
//批量写寄存器
master.WriteMultipleRegisters(1,2,new ushort[]{11,22,33});
```

#### Modbus‑TCP

```
TcpClient client = new TcpClient();
client.Connect("127.0.0.1",502);
IModbusMaster master = ModbusIpMaster.CreateIp(client);
//读写寄存器API和RTU完全一样
```

> 方法清单

- `ReadCoils()`读线圈；`WriteSingleCoil()`/`WriteMultipleCoils()`写线圈
- `ReadInputs()`读离散输入
- `ReadHoldingRegisters()`读保持寄存器
- `ReadInputRegisters()`读输入寄存器

## 五、工业上位机拓展

1. TCP：对接MES、视觉相机、网口PLC；异步+CancellationToken管理网络连接；子线程收到数据Invoke更新UI。
2. SerialPort：RS485传感器、温控器、老款PLC；窗体关闭必须Close串口，否则串口被锁死。
3. Modbus：工业最通用协议；RTU用于485总线；Modbus‑TCP网口PLC；读写保持寄存器交互设备。

## 📝面试问答（对话式✨）

**Q1：TcpClient读取ReadAsync返回0代表什么？😃**

> A：返回0代表对端已经正常关闭TCP连接。

**Q2：WinForm做TCP通信，为什么要用AcceptAsync、ReadAsync，不用同步Read？**

> A：同步方法是阻塞调用，会卡死UI主线程；异步不会阻塞界面；配合CancellationToken可以安全终止IO。

**Q3：SerialPort打开串口常见两个异常代表什么？🤔**

> A：`UnauthorizedAccessException`串口被其他程序占用；`IOException`串口设备不存在。

**Q4：Modbus四类存储区，哪一类最常用？**

> A：保持寄存器HoldingRegisters，可读写16位ushort，绝大多数参数交互使用。

**Q5：Modbus主站从站分别是什么？**

> A：主站：上位机软件，发起读写请求；从站：PLC、传感器硬件，响应请求；每个从站拥有唯一SlaveId。

> 补充：TCP原始字节流没有消息边界；真实项目需要实现分包协议，例如帧头+长度+数据+校验和。

