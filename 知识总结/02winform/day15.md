# day15｜TCP网络通信、SerialPort串口、Modbus工业协议 结构化总结

> 工业上位机通信实战，和day14知识点高度重合；重点：TCP服务端/客户端异步完整实现、简易聊天室、SerialPort串口严谨写法、NModbus4实现Modbus‑RTU / ASCII / Modbus‑TCP，传送带控制案例。

## 一、网络分层模型（TCP/IP五层）

| 分层       | 功能             | 典型协议     |
| ---------- | ---------------- | ------------ |
| 应用层     | 业务应用数据     | HTTP、DNS    |
| 传输层     | 端到端传输       | **TCP、UDP** |
| 网络层     | 寻址路由         | IP           |
| 数据链路层 | 帧传输、差错校验 | ARP、PPP     |
| 物理层     | 比特流硬件传输   | 电气物理信号 |

> TCP：面向连接、可靠传输；工业设备网口通信主流。端口范围：0‑65535，业务建议使用>10000端口。

## 二、TCP通信核心类

- `TcpListener`：TCP服务端，监听IP+端口，等待客户端接入
- `TcpClient`：TCP客户端，主动连接服务端
- `NetworkStream`：网络流，全部收发都是`byte[]`字节数组
- `CancellationTokenSource`：异步IO安全取消，防止卡死、资源无法释放

### 2.1 TCP服务端开发流程

1. `IPAddress.Parse()`解析监听IP，实例`TcpListener`
2. `Start()`启动监听
3. `await AcceptTcpClientAsync(token)`异步等待客户端连接（**禁止同步Accept阻塞UI**）
4. 获取`TcpClient`，拿到`NetworkStream`网络流
5. 循环`ReadAsync()`接收字节；`WriteAsync()`发送字节；`Encoding.UTF8`完成字节与字符串互转
6. 窗体关闭/断开时：取消令牌、`Stop()`停止监听、关闭`TcpClient`释放资源。

> `ReadAsync`返回`readLen == 0`，代表对端正常断开TCP连接。

### 2.2 TCP客户端开发流程

1. new `TcpClient()`
2. `await ConnectAsync(ip,port,token)`连接服务器
3. 获取`NetworkStream`流对象
4. 循环异步读取服务端数据；按钮触发发送字节数据
5. 断开：取消令牌，关闭流、关闭TcpClient，重置对象。

### 2.3 简易聊天室案例

- 单客户端版本：服务端与单个客户端双向收发消息，动态生成Label展示消息到Panel。
- 作业拓展：**群聊聊天室**，服务端保存所有已连接客户端，收到消息后广播转发给全部客户端。

> ⚠️重点：网络子线程收到数据，更新WinForm UI必须使用`Control.Invoke`封送到UI主线程。 TCP是字节流，**无消息边界**；真实项目需要自定义通信协议（帧头+数据长度+内容+校验），不能直接简单按字符串收发。

## 三、SerialPort 串口通信

NuGet包：`System.IO.Ports`；用于RS232 / RS485传感器、老款PLC。

### 关键参数

```
SerialPort(端口号,波特率,校验位,数据位,停止位)
var sp = new SerialPort("COM1",9600,Parity.None,8,StopBits.One);
sp.Open();
Stream stream = sp.BaseStream; //拿到底层流，支持ReadAsync/WriteAsync
```

### 严谨开发流程

1. 实例SerialPort，配置串口参数

2. ```
   Open()
   ```

   打开串口；捕获异常：

   - `UnauthorizedAccessException`：串口被别的程序占用
   - `IOException`：串口设备不存在

3. 使用`BaseStream`配合`CancellationToken`异步循环收发数据

4. **窗体关闭事件必须处理释放**：取消循环、`sp.Close()`、`sp.Dispose()`，否则串口被锁死，其他程序打不开。

> 调试工具：虚拟串口模拟器，虚拟COM端口，无需真实硬件调试串口代码。

## 四、Modbus工业总线协议

> 角色区分

- **主站Master**：上位机软件，主动发起读写请求（我们写的程序）
- **从站Slave**：PLC、传感器硬件设备，响应请求；每个从站拥有唯一`SlaveId`(1‑247)

### 三种实现方式

1. Modbus‑RTU：串口RS485，工业现场最常用
2. Modbus‑ASCII：串口，极少使用
3. Modbus‑TCP：以太网网口，默认端口502

### Modbus四类存储区

| 存储区                      | 数据类型 | 读写权限 | 说明                    |
| --------------------------- | -------- | -------- | ----------------------- |
| Coils 线圈                  | bool     | 可读可写 | 开关量输出              |
| Inputs 离散输入             | bool     | 只读     | 开关量输入              |
| HoldingRegisters 保持寄存器 | ushort   | 可读可写 | ⭐最常用，16位参数寄存器 |
| InputRegisters 输入寄存器   | ushort   | 只读     | 只读采集数据            |

### NModbus4库（NuGet安装）

#### Modbus‑RTU（串口）

```
SerialPort sp = new SerialPort("COM1",9600,Parity.None,8,StopBits.One);
sp.Open();
IModbusSerialMaster master = ModbusSerialMaster.CreateRtu(sp);
master.Transport.ReadTimeout = 2000;
master.Transport.Retries = 3;

//读保持寄存器
ushort[] arr = master.ReadHoldingRegisters(slaveAddress:1,startAddress:0,numberOfPoints:5);
//写单个寄存器
master.WriteSingleRegister(1,2,1234);
//批量写寄存器
master.WriteMultipleRegisters(1,2,new ushort[]{11,22,33});
```

#### Modbus‑TCP

```
TcpClient client = new TcpClient();
client.Connect("127.0.0.1",502);
IModbusMaster master = ModbusIpMaster.CreateIp(client);
//读写API和RTU完全一致
```

> 常用API清单

- `ReadCoils` / `WriteSingleCoil` / `WriteMultipleCoils`：线圈读写
- `ReadInputs`：读离散输入
- `ReadHoldingRegisters` / `WriteSingleRegister` / `WriteMultipleRegisters`：保持寄存器
- `ReadInputRegisters`：读输入寄存器

### 实战案例：Modbus控制传送带

通过读写保持寄存器实现传送带启动、停止、设置速度。

## 五、易错点

1. TCP同步`Accept()`、`Read()`会卡死WinForm界面，全部使用`‑Async`异步，搭配`CancellationTokenSource`安全取消IO。
2. 串口用完必须Close+Dispose，否则串口资源被锁死。
3. Modbus从站地址范围1‑247；保持寄存器ushort无符号16位。
4. 网络/串口子线程收到数据，**禁止直接操作UI控件**，需要Invoke封送。
5. TCP字节流没有边界，Demo可以简单收发字符串；正式项目必须设计分包协议。

## 六、工业上位机拓展

1. TCP：对接网口PLC、视觉相机、MES系统；异步IO保证UI不卡死；子线程数据Invoke更新界面。
2. SerialPort：对接RS485传感器、温控仪表；窗体关闭释放串口资源。
3. Modbus：工厂PLC、传感器交互；RTU用于485总线；Modbus‑TCP用于网口设备，读写保持寄存器完成参数交互。

## 📝面试问答

**Q1：Tcp ReadAsync返回0代表什么？**

> A：代表对端正常关闭TCP连接。

**Q2：SerialPort打开串口常见两个异常含义？**

> A：`UnauthorizedAccessException`串口被其他程序占用；`IOException`串口设备不存在。

**Q3：Modbus主站、从站分别是什么？哪个存储区最常用？**

> A：主站是上位机软件，主动发起读写；从站是PLC、传感器硬件；**保持寄存器HoldingRegisters**最常用，可读写16位参数。

**Q4：CancellationTokenSource在TCP/串口异步IO的作用？**

> A：安全终止异步ReadAsync/AcceptAsync，避免程序卡死，用于窗体关闭、手动断开连接。

> 如果你需要，我可以把 day01‑day15 全套WinForm+C#复习资料合并一份完整总文档。