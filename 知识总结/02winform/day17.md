# day17｜WinForm温控设备监控系统完整项目 结构化总结

> 工业上位机综合实战项目；技术栈：WinForm、Modbus‑RTU串口通信、MySQL数据库、GDI+双缓冲绘图、BindingList+INotifyPropertyChanged数据绑定、子窗体、JSON文件导出、定时器模拟设备运行。 业务：温控仪表模拟采集、半圆仪表盘实时显示、操作日志、定时采集入库、子窗体历史数据按时间查询、温度统计、导出JSON。

## 一、整体架构

1. **主窗体**：串口Modbus连接断开、启停温控、设定目标温度、GDI仪表盘、实时采集表格、操作日志输出。
2. **历史查询子窗体Form2**：时间筛选查询、最大/最小/平均温度统计、导出JSON文件。
3. 第三方NuGet包：
   - `NModbus4`：Modbus‑RTU主站读写保持寄存器
   - `System.IO.Ports`：串口SerialPort
   - `MySqlConnector`：MySQL数据库
4. 仿真调试：Modbus‑Slave模拟从站设备，虚拟串口调试，无需真实硬件。

### Modbus‑RTU保持寄存器（从站ID=1）

| 寄存器地址 | 名称         | 读写权限 | 说明                |
| ---------- | ------------ | -------- | ------------------- |
| 0          | 设备状态     | 读写     | 0待机，1运行，2故障 |
| 1          | 设定温度     | 读写     | 上位机下发目标温度  |
| 2          | 实际采集温度 | 读写     | 模拟升降温          |
| 3          | 故障码       | 读写     | 0无故障，1超温故障  |

### MySQL数据表 `DeviceTempRecord`

```
CREATE TABLE DeviceTempRecord (
    Id INT AUTO_INCREMENT PRIMARY KEY COMMENT '自增主键',
    CollectTime DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '采集时间',
    DeviceStatus INT NOT NULL COMMENT '设备状态 0待机 1运行 2故障',
    SetTemp INT NOT NULL COMMENT '设定温度',
    RealTemp INT NOT NULL COMMENT '实际温度',
    FaultCode INT NOT NULL COMMENT '故障码 0无故障 1超温故障'
) COMMENT='温控设备历史快照记录表';
```

### 实体 `DeviceTempRecord`

- 实现 **INotifyPropertyChanged**，属性setter内部触发`PropertyChanged?.Invoke()`；
- 构造接收ushort寄存器数组，自动赋值全部字段，记录采集时间；
- 用于`BindingList<T>`绑定DataGridView，属性变更表格UI自动同步。

## 二、主窗体核心字段

```
private BindingList<DeviceTempRecord> DTRs;          // 表格绑定数据源
private SerialPort MyPort;                           // 串口对象
private IModbusSerialMaster Master;                  // Modbus‑RTU主站对象
private System.Windows.Forms.Timer TempTimer;        // 400ms，模拟温度升降
private System.Windows.Forms.Timer DataTimer;         // 500ms，数据采集
private bool isHeating;                              // true升温 / false降温
private int RecordeDataBase;                          // 计数器，6次采集=3s写入一次数据库
```

## 三、主窗体功能流程

### 1、窗体初始化

1. UI状态初始化：断开、启停、设定温度按钮**初始禁用**；

2. 实例两个Timer，绑定Tick事件；

3. SetDataColumns()初始化DataGridView：
   - `AutoGenerateColumns=false`关闭自动生成列，手动定义每一列，设置`DataPropertyName`映射实体属性；
   - 只读、禁止用户增删行；`DataSource`绑定`BindingList<DeviceTempRecord>`；

4. 双缓冲Panel绑定`Paint`绘图事件，消除仪表盘闪烁；

5. 全部按钮Click事件绑定。

> 双缓冲自定义Panel（GDI绘图消除闪烁）

```
public class DoubleBufferPanel : Panel
{
    public DoubleBufferPanel()
    {
        SetStyle(ControlStyles.UserPaint
            | ControlStyles.AllPaintingInWmPaint
            | ControlStyles.OptimizedDoubleBuffer, true);
        UpdateStyles();
    }
}
```

### 2、设备连接 ConnectPLC

1. 实例SerialPort打开串口COM1，创建`ModbusSerialMaster`；设置读超时、重试次数。
2. 初始化寄存器：状态0待机，实际温度25，故障码0。
3. 更新UI按钮状态；调用`WriteLog()`输出日志：`连接设备成功，开始采集`。

### 3、断开设备 ClosePLC

1. 停止`TempTimer`、`DataTimer`两个定时器；

2. `SerialPort.Close()`释放串口资源，清空Modbus主站对象；

3. 恢复全部按钮初始状态，输出断开日志。

   > ⚠️串口必须释放，否则串口锁死，其他软件打不开该串口。

### 4、日志输出 WriteLog

- 使用`FlowLayoutPanel`动态new Label；拼接时间戳+日志文本；
- 包含`警告`关键字文字设置红色；实现运行日志滚动展示。

### 5、设备控制

1. **设置目标温度SetTemp**：输入校验温度范围0‑600；Modbus异步写入寄存器地址1；记录操作日志。
2. **启动设备StartDevice**：启动两个定时器；寄存器0写1运行；更新按钮状态，写日志。
3. **停止设备StopDevice**：停止温度模拟定时器；寄存器0写0待机；恢复UI按钮，写日志。

### 6、定时器业务逻辑

#### TempTimer（400ms，模拟升降温）

1. 读取寄存器2当前实际温度；
2. 模拟逻辑：最高300℃，最低30℃；到上限切换降温，下限切换升温，每次±1；
3. 将新温度写回寄存器2；更新界面实际温度标签；
4. 判断超温逻辑，修改设备状态寄存器0、故障码寄存器3，输出警告/故障消除日志；
5. `tempPanel.Invalidate()`触发Paint重绘半圆仪表盘。

#### DataTimer（500ms，数据采集）

1. 读取寄存器0‑3共4个保持寄存器；
2. 构造`DeviceTempRecord`实体，加入`BindingList`，表格自动刷新；
3. 计数器`RecordeDataBase++`；**累计6次（3秒）调用MySQL插入，计数器清零**。

### 7、GDI+半圆仪表盘绘制

- 半圆角度180°，量程0‑600℃；每5℃一个刻度，每50℃绘制刻度文字；
- `SmoothingMode.HighQuality`开启抗锯齿；
- 根据实际温度换算角度，绘制指针；定时器调用`Invalidate()`重绘。

## 四、MySQL数据库封装

1. MysqlBase基础类：封装连接字符串；
   - `ConnAndHandle(sql)`：执行增删改，返回bool；
   - `ConnAndRead(sql)`：执行查询，返回`DataTable`。

2. 静态业务类MysqlHandler

   - `InsertOne()`插入一条温控采集记录；
   - `SearchByTime(开始,结束)`按时间区间查询；
   - `SearchAll()`查询全部记录。

> 改进提示：示例直接拼接SQL字符串，正式项目需要参数化`AddWithValue()`防止SQL注入。

## 五、历史查询子窗体Form2

1. 窗体`Shown`事件调用初始化方法；初始化表格，加载全部历史数据。

2. DateTimePicker时间控件：

   ValueChanged事件做时间联动约束；

   - 开始时间最大值 = 结束时间；结束时间最小值 = 开始时间，结束时间不能大于系统当前时间。

3. 查询按钮：调用`SearchByTime()`，绑定查询结果到`DataTable`作为表格数据源。

4. 温度统计：使用`DataTable.Compute()`计算Max、Min、Avg；无数据显示NaN。

5. JSON导出功能

   - `SaveFileDialog`弹出保存对话框；
   - 将`DataTable`使用LINQ转为实体集合；
   - `JsonSerializer.Serialize()`序列化；`File.WriteAllText()`写入本地JSON文件。

## 六、易错点

1. 串口使用完毕必须Close释放；窗体关闭事件也要做资源清理，防止串口被锁死。
2. GDI绘图必须使用双缓冲Panel，否则仪表盘严重闪烁。
3. Timer启停配对；断开设备必须Stop定时器，防止后台持续读写Modbus。
4. `INotifyPropertyChanged`实体属性set必须触发通知，BindingList表格才会UI同步更新。
5. Modbus读写优先使用**异步方法**，避免阻塞WinForm UI主线程。
6. 采集界面每500ms刷新表格；**数据库3秒才持久化，靠计数器RecordeDataBase实现**。
7. 子窗体时间控件需要做最大最小时间约束，防止结束时间早于开始时间。

## 七、工业上位机拓展

1. 替换模拟升降温逻辑对接真实Modbus‑RTU温控仪表。
2. SQL改成参数化查询防止注入；增加异常捕获（串口、Modbus读写超时、数据库异常弹窗）。
3. 增加分页查询，海量历史记录不会卡顿；增加Excel导出；故障声音报警。

## 📝面试问答（对话式）

**Q1：项目两个Timer定时器分工是什么？😃**

> A：`TempTimer`(400ms)：模拟设备温度升降，驱动仪表盘重绘； `DataTimer`(500ms)：周期读取Modbus寄存器，刷新界面表格；计数器累计6次执行一次MySQL持久化入库。

**Q2：DeviceTempRecord实体为什么实现INotifyPropertyChanged？🤔**

> A：配合BindingList做DataGridView数据绑定；实体属性修改后触发通知，表格UI自动同步刷新。

**Q3：串口资源有哪些注意事项？**

> A：使用完必须Close、释放；窗体关闭也要释放，否则串口锁死，别的程序无法打开该COM口。

**Q4：DataTable.Compute()作用？**

> A：直接对DataTable内存数据表执行聚合计算，支持Max、Min、Avg、Sum，快速完成历史温度统计。

> 本项目是完整小型工业上位机样板，综合WinForm控件、GDI+绘图、Modbus‑RTU串口通信、MySQL持久化、数据绑定、多窗体交互、定时器、文件导出。

