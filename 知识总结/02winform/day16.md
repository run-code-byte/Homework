# day16｜WinForm 温控设备监控综合项目 结构化总结

> 工业上位机完整实战项目；技术栈：WinForm + Modbus‑RTU串口 + MySQL数据库 + GDI+绘图 + BindingList数据绑定 + JSON导出。 业务：温控设备模拟，串口Modbus读写寄存器、实时仪表盘、定时采集、日志记录、定时入库、历史查询统计、JSON导出。

## 一、项目整体架构

### 模块划分

1. **主窗体**：设备连接断开、温度仪表盘GDI绘制、启停温控、设置目标温度、实时采集表格、操作日志。
2. **子窗体（历史查询）**：按时间范围查询数据库记录、温度统计（最大/最小/平均）、导出JSON文件。
3. 底层依赖：
   - NModbus4：Modbus‑RTU读写保持寄存器
   - System.IO.Ports：串口SerialPort
   - MySqlConnector：MySQL数据库读写
   - GDI+双缓冲Panel：消除仪表盘绘图闪烁
   - `BindingList<DeviceTempRecord>` + `INotifyPropertyChanged`：表格双向数据绑定

### Modbus‑RTU寄存器定义（从站Id=1）

| 寄存器地址 | 名称     | 读写 | 说明                             |
| ---------- | -------- | ---- | -------------------------------- |
| 0          | 设备状态 | 读写 | 0待机，1运行，2故障              |
| 1          | 设定温度 | 读写 | 上位机下发目标温度               |
| 2          | 实际温度 | 只读 | 设备反馈实时温度，程序模拟升降温 |
| 3          | 故障码   | 读写 | 0无故障，1超温故障               |

### MySQL数据表 `DeviceTempRecord`

字段：`Id`自增主键、`CollectTime`采集时间、`DeviceStatus`设备状态、`SetTemp`设定温度、`RealTemp`实际温度、`FaultCode`故障码。

### 实体模型 `DeviceTempRecord`

- 实现`INotifyPropertyChanged`接口，属性变更通知UI刷新；
- 构造函数直接接收寄存器ushort数组，自动填充实体、记录采集时间。

## 二、核心对象与字段

```
private BindingList<DeviceTempRecord> DTRs;          // 表格绑定数据源
private SerialPort MyPort;                           // 串口对象
private IModbusSerialMaster Master;                  // Modbus‑RTU主站
private System.Windows.Forms.Timer TempTimer;        // 模拟温度升降，400ms周期
private System.Windows.Forms.Timer DataTimer;         // 数据采集500ms周期
private bool isHeating;                              // true升温 / false降温
private int RecordeDataBase;                          // 计数器：6次采集(3s)写入一次数据库
```

## 三、主窗体核心业务流程

### 1、窗体初始化

1. UI控件状态初始化：断开、启停、设置温度按钮**初始禁用**；
2. 实例化两个Timer定时器；
3. 配置`DataGridView`：关闭自动生成列，手动定义列，`DataSource`绑定`BindingList`；只读、禁止增删行；
4. 给双缓冲Panel绑定`Paint`绘图事件（绘制半圆温度仪表盘）；
5. 全部按钮Click事件绑定。

> 绘图Panel必须使用**自定义双缓冲Panel**，`OptimizedDoubleBuffer`开启内存绘图，消除闪烁。

```
public class DoubleBufferPanel : Panel
{
    public DoubleBufferPanel()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        UpdateStyles();
    }
}
```

### 2、设备连接（Modbus‑RTU串口）

1. 实例SerialPort打开COM串口，创建ModbusSerialMaster；设置读超时、重试次数。
2. **初始化寄存器**：状态0待机，实际温度25，故障码0。
3. 更新UI状态：连接按钮禁用；断开、设置温度按钮启用；写入日志`WriteLog()`。

### 3、断开设备连接

1. 停止两个Timer定时器；
2. 关闭、释放串口SerialPort资源；清空Modbus主站对象；
3. 恢复按钮初始状态，写日志“断开设备，停止采集”。

> ⚠️重点：串口必须Close+Dispose，防止串口被锁死，别的程序打不开。

### 4、日志输出 WriteLog

使用`FlowLayoutPanel`动态生成Label；带时间戳，警告消息字体标红。

### 5、设备控制

1. **设置目标温度**：校验输入0‑600，调用Modbus异步方法写入寄存器地址1，写操作日志。
2. **启动设备**：开启`TempTimer`、`DataTimer`；寄存器0写1运行；更新按钮状态，日志记录。
3. **停止设备**：停止温度模拟定时器；寄存器0写0待机；恢复按钮，写日志。

### 6、定时器业务逻辑

#### TempTimer（400ms，模拟升降温）

1. 读取寄存器2当前实际温度；
2. 模拟升降温：最高300，最低30；到上限切换降温，到下限切换升温；
3. 将新温度写回寄存器2；
4. 判断超温逻辑，修改设备状态寄存器0、故障码寄存器3；输出警告/故障消除日志；
5. `panel.Invalidate()`触发Paint重绘仪表盘。

#### DataTimer（500ms，数据采集）

1. 读取寄存器0‑3共4个保持寄存器；
2. 构造`DeviceTempRecord`实体，加入`BindingList`，DataGridView自动刷新表格；
3. 计数器`RecordeDataBase++`；**每6次（3秒）执行一次MySQL插入入库，计数器清零**。

### 7、GDI+ 半圆仪表盘绘制

- 半圆180°，量程0‑600℃；
- 循环绘制刻度，大刻度附带温度文字；绘制温度指针；
- `SmoothingMode.AntiAlias`开启抗锯齿；
- 定时器回调执行`Invalidate()`触发重绘。

## 四、数据库封装

1. MysqlBase

   基础类：封装连接字符串，提供两个通用异步方法

   - `ConnAndHandle(sql)`：执行增删改，返回bool；
   - `ConnAndRead(sql)`：查询返回`DataTable`。

2. MysqlHandler

   静态业务类：

   - `InsertOne()`：插入一条温控记录；
   - `SearchByTime()`：按起止时间范围查询；
   - `SearchAll()`：查询全部记录。

> 注意：作业可优化：使用参数化`AddWithValue`，防止SQL注入。

## 五、历史查询子窗体功能

1. 打开子窗体自动加载全部历史记录；
2. 时间筛选：起止时间条件查询；
3. 统计：对查询结果计算最大温度、最小温度、平均温度；
4. **导出JSON**：`SaveFileDialog`保存对话框，把表格数据序列化为JSON写入本地文件。

## 六、易错点

1. 串口用完必须释放，否则串口锁死；窗体关闭事件也要做资源释放。
2. 绘图Panel不加双缓冲，仪表盘严重闪烁。
3. Timer定时器启动/停止要配对；断开设备必须Stop定时器，避免后台继续读写Modbus。
4. `INotifyPropertyChanged`属性set里面必须`PropertyChanged?.Invoke()`，BindingList表格才会同步UI。
5. Modbus读写使用**异步方法**，不要同步阻塞UI。
6. 数据库写入：500ms界面刷新表格，**3秒才真正写入数据库**，靠计数器实现。
7. 日志用FlowLayoutPanel动态生成Label，警告信息设置红色字体。

## 七、工业上位机拓展

1. Modbus‑RTU串口对接真实温控仪表，替换模拟升降温逻辑。
2. 增加异常捕获：串口异常、Modbus读写超时、数据库异常弹窗提示。
3. 参数化SQL，防止注入；增加分页查询，数据量大不会卡顿。
4. 导出支持Excel；故障弹窗声音报警。

## 📝面试问答

**Q1：为什么要双缓冲Panel绘制仪表盘？😃**

> A：默认GDI绘制会先擦除背景再绘图，造成画面闪烁；双缓冲把全部绘图操作先在内存画布完成，完成后一次性拷贝到屏幕，消除闪烁。

**Q2：项目中两个Timer定时器分工是什么？🤔**

> A：`TempTimer`(400ms)：模拟设备升降温逻辑，驱动仪表盘重绘； `DataTimer`(500ms)：周期读取Modbus寄存器，更新界面表格；每累计6次触发一次MySQL持久化入库。

**Q3：DeviceTempRecord实体为什么实现INotifyPropertyChanged？**

> A：配合BindingList做DataGridView双向绑定；实体属性修改后触发通知，表格UI自动同步刷新。

**Q4：Modbus‑RTU项目，串口资源要注意什么？**

> A：使用完毕必须Close、Dispose；窗体关闭也要释放；不释放会串口被锁死，别的软件无法打开该串口。

> 本项目是完整小型工业上位机样板，融合：WinForm控件、GDI+绘图、Modbus串口通信、MySQL持久化、数据绑定、定时器、子窗体交互、文件导出。

