# day01‑day17｜C# WinForm全套 精简背诵版

> 适合期末/面试快速复习；只记核心考点、易错点、高频代码片段。

## 目录

day01 WinForm入门、基础控件

day02 容器、动态控件、Controls集合、事件

day03 鼠标键盘事件、事件参数、输入校验

day04 对话框、Timer定时器、简单/复杂数据绑定

day05 DataGridView表格进阶

day06 UserControl用户控件、控件与窗体通信

day07 多线程‑Task‑async‑await、MySQL、多媒体

day08 MySQL基础SQL语句

day09‑day10 Invoke跨线程、Settings本地配置、DLL动态链接库

 day12 GDI+绘图

day13 递归函数、打字下落游戏

day14‑day15 TCP‑串口‑Modbus工业通信

day16‑day17 温控设备监控综合上位机项目

------

## day01 WinForm入门、基础控件

1. 新建：Windows窗体应用；`Form`窗体是根容器。

2. 分部类`partial`：`Form1.cs`写业务；`Form1.Designer.cs`设计器自动生成，**禁止手动修改**。

3. 核心入口`Program.cs`：`[STAThread]`必须有；`Application.Run(new Form1())`启动主窗体。

4. 常用控件：`Button、Label、TextBox、CheckBox、RadioButton、ComboBox、PictureBox`

5. PictureBox：`SizeMode.Zoom`等比例缩放不变形（看图必用）。

6. 容器：`Panel、GroupBox、TabControl`。

7. 布局属性

   - `Dock`贴靠边缘，**优先级高于Anchor**；

   - Anchor锚点，窗体缩放控件跟随拉伸。

     > 易错：`RadioButton`互斥仅在**同一个容器内**，多组单选放不同Panel。

## day02 容器、动态控件、Controls集合、事件

1. 容器分普通容器、布局容器：`FlowLayoutPanel`流式自动换行；`TableLayoutPanel`表格网格；`SplitContainer`分割面板。

2. Controls集合：存放子控件；

   Add()添加、Remove()删除、Clear()清空；

   - 动态new控件后**必须Add进容器才显示**。
   - `控件.Parent`拿到父容器；一个控件同一时间只能属于一个父容器。

3. 事件三要素：事件源、事件类型、事件处理方法；绑定：`控件.事件 += 方法`。

4. `sender`：触发事件的对象，object类型，需要`as`强转。

## day03 鼠标键盘事件、事件参数、输入校验

1. 鼠标：`MouseDown、MouseUp、MouseMove`；`MouseEventArgs`取X/Y、按键。

2. 键盘

   - `KeyDown/KeyUp`：物理按键，取`KeyCode`，识别Ctrl/Shift/F系列；
   - `KeyPress`：字符按键；`e.Handled=true`拦截输入字符（文本框只允许数字）。

3. 焦点事件顺序：

   GotFocus → Validating(校验) → Validated → Leave

   - `Validating`中`e.Cancel=true`阻止失去焦点，做输入校验，**避免Leave+Focus造成死循环**。

4. 窗体`KeyPreview=true`：窗体优先接收键盘，不受控件焦点影响。

## day04 对话框、Timer定时器、简单/复杂数据绑定

1. 文件对话框（全部建议using自动释放）

   - `OpenFileDialog`打开；`SaveFileDialog`保存；`FolderBrowserDialog`选文件夹；
   - Filter格式：`显示文本|*.后缀`；判断`ShowDialog()==DialogResult.OK`再拿路径。

2. `System.Windows.Forms.Timer`：UI定时器，Tick跑在UI主线程，耗时业务会卡死界面；`Interval`毫秒；`Start()/Stop()`。

3. 简单绑定（单值控件TextBox/Label）

   - 实体必须实现`INotifyPropertyChanged`；set里面调用`PropertyChanged?.Invoke()`通知UI刷新；
   - `控件.DataBindings.Add("属性",实体,"实体属性")`。

4. 复杂绑定（DataGridView、ListBox、ComboBox）

   - `List<T>`：修改对象属性UI更新；**Add/Remove集合界面不会自动刷新**；
   - `BindingList<T>`⭐优先用，集合增删UI自动刷新。

## day05 DataGridView表格进阶

1. 常用配置

```
dataGridView1.AllowUserToAddRows=false; //禁止自动新增空行
dataGridView1.AllowUserToDeleteRows=false;
dataGridView1.ReadOnly=true;
dataGridView1.SelectionMode=FullRowSelect; //整行选中
dataGridView1.EnableHeadersVisualStyles=false; //关闭系统主题，自定义表头颜色生效
dataGridView1.AlternatingRowsDefaultCellStyle.BackColor=Color.LightGray; //隔行变色
```

1. 新增按钮列`DataGridViewButtonColumn`；
2. 单元格读写：`Rows[行索引].Cells["列名"].Value`；
3. `DataBoundItem`获取绑定的实体对象；
4. 重点事件
   - `CellClick`：`e.RowIndex<0`代表点击表头，要过滤；
   - `SelectionChanged`选中行切换；
   - `CellEndEdit`单元格编辑完成；
   - `DataError`捕获绑定格式异常，`e.ThrowException=false`屏蔽弹窗。
5. 绑定模式下不能直接`Rows.Add()`，要先`DataSource=null`解除绑定。

## day06 UserControl用户控件、控件与窗体通信

1. **UserControl用户控件**：把一组控件+业务逻辑封装复用；写完必须**生成解决方案，工具箱才出现该控件**。
2. 通信
   - 父→子：父持有子对象，直接访问子公开属性/方法；
   - 子→父⭐自定义事件：子定义`Action`事件，子内部`事件?.Invoke(数据)`向外抛；父窗体绑定事件接收；**禁止子直接操作父控件，强耦合无法复用**。
   - 无父子关系（跨窗体）：**单例消息中间人模式**；字典存暗号+回调；发送方按暗号推送，接收方注册回调；窗体关闭注销回调防内存泄漏。

## day07 多线程‑Task‑async‑await、MySQL、多媒体

1. 进程：操作系统资源容器；线程：进程内执行流；WinForm默认UI主线程；**子线程禁止直接操作UI**。
2. 线程类
   - `Thread`原生线程，开销大；
   - `ThreadPool`线程池复用线程；
   - `Task`⭐推荐，底层线程池；支持返回值、`WhenAll/WhenAny`、`ContinueWith`、`CancellationTokenSource`取消任务。
3. 区分：`.Result / Wait()`**阻塞线程，UI线程调用卡死界面**；`await`非阻塞等待。
4. `async void`只用于UI事件；业务尽量返回`Task`便于异常捕获。
5. MySQL：NuGet`MySqlConnector`；`MySqlConnection`连接，**using自动释放连接**；`MySqlCommand`；参数化`AddWithValue`防SQL注入。
6. 多媒体：`AxWindowsMediaPlayer`播放音视频；`SoundPlayer`仅wav音频。

## day08 MySQL基础SQL语句

1. 数据库层级：库→表→字段→行记录。
2. SQL

```
--新增
insert into 表(字段1,字段2) values(值1,值2),(值3,值4);
--删除（不加where清空全表！）
delete from 表 where 条件;
--修改（不加where修改全部！）
update 表 set 字段=值 where 条件;
--查询
select * from 表 where 条件;
--聚合
sum() max() min() avg() count(*)
--排序 desc降序；分页 limit 偏移,条数；group by分组
```

1. 运算符：`and/or/in/between…and/like%通配符`。

## day09‑day10 Invoke跨线程、Settings本地配置、DLL动态链接库

1. Control.Invoke 跨线程更新UI⭐高频

   - `InvokeRequired`：true代表当前不是UI线程；

   ```
   if(label1.InvokeRequired)
   {
       label1.Invoke(new Action(()=> label1.Text="xxx"));
   }
   else label1.Text="xxx";
   ```

   - .NET Framework默认开启跨线程异常；.NET Core+默认关闭，但依然不允许子线程直接操作UI。

2. Setting本地配置

   - `Application`：只读，exe.config，全局；
   - `User`：可读可写，user.config，用户偏好；
   - `Properties.Settings.Default.xxx`读写；**赋值仅内存生效，必须调用Save()才写入硬盘**；`Reset()`恢复默认。

3. DLL动态链接库

   - 托管类库DLL：新建类库项目，类方法标记`public`；主项目添加项目引用，using命名空间new对象；
   - `[DllImport]`：调用C/C++原生非托管dll；**不能用于.NET托管dll**。

## day12 GDI+绘图

1. 绘图代码**必须写在Paint事件**；`e.Graphics`画布对象，不要存全局变量；
2. Pen画笔（空心）、Brush画刷（填充）、Font字体；**using释放非托管资源防内存泄漏**；
3. 常用：`DrawRectangle、FillRectangle、DrawEllipse、FillEllipse、DrawLine、DrawPolygon、DrawString`；
4. `g.SmoothingMode=AntiAlias`抗锯齿；
5. 重绘调用`控件.Invalidate()`，禁止直接手动调用Paint；
6. **双缓冲消除闪烁**自定义Panel

```
public class DoubleBufferPanel:Panel{
    public DoubleBufferPanel(){
        SetStyle(ControlStyles.UserPaint|ControlStyles.AllPaintingInWmPaint|ControlStyles.OptimizedDoubleBuffer,true);
        UpdateStyles();
    }
}
```

> 禁止`CreateGraphics()`，窗口遮挡最小化绘制消失。

## day13 递归函数、打字下落游戏

1. 递归：函数调用自身；**必须有终止条件，否则StackOverflow栈溢出**；先向下拆解，到达终止条件逐层回溯。
2. 打字下落游戏：动态生成Label；`KeyPreview=true`窗体捕获按键；`List<Dictionary<string,dynamic>>`管理多组【控件+Timer】对象；游戏结束Stop全部定时器，Remove控件，防止内存残留。

## day14‑day15 TCP‑串口‑Modbus工业通信

### TCP通信

1. `TcpListener`服务端；`TcpClient`客户端；`NetworkStream`网络字节流；
2. 字符串↔字节数组：`Encoding.UTF8.GetBytes() / GetString()`；
3. `ReadAsync()`返回`0`代表对端正常断开；
4. WinForm必须全部用`‑Async`异步，搭配`CancellationTokenSource`安全取消IO；**禁止同步Read/Accept阻塞UI**；
5. TCP是字节流，**无消息边界**；正式项目需要自定义分包协议。
6. 子线程收到数据更新UI必须`Invoke`。

### SerialPort串口

1. NuGet`System.IO.Ports`；参数：端口、波特率、校验位、数据位、停止位；
2. `sp.Open()`打开；`sp.BaseStream`拿流做异步读写；
3. 异常：`UnauthorizedAccessException`串口被占用；`IOException`串口不存在；
4. ⚠️用完必须`Close()+Dispose()`，否则串口锁死。

### Modbus协议

1. 角色：**主站(Master)上位机发起请求；从站(Slave)PLC/传感器，SlaveId：1‑247**。
2. 三类：Modbus‑RTU串口（工业485最常用）、Modbus‑ASCII极少用、Modbus‑TCP网口默认502。
3. 四类寄存器
   - Coils线圈：bool可读写输出；
   - Inputs离散输入：bool只读；
   - HoldingRegisters保持寄存器⭐最常用，ushort可读写；
   - InputRegisters输入寄存器：ushort只读采集值。
4. NuGet`NModbus4`；读写保持寄存器`ReadHoldingRegisters / WriteSingleRegister / WriteMultipleRegisters`。

## day16‑day17 温控设备监控综合上位机项目

### 技术栈

WinForm + Modbus‑RTU + MySQL + GDI+双缓冲仪表盘 + BindingList+INotifyPropertyChanged + 多Timer + 子窗体 + JSON导出

1. Modbus寄存器：0设备状态，1设定温度，2实际温度，3故障码。
2. 两个Timer分工
   - `TempTimer(400ms)`：模拟升降温逻辑，调用`Invalidate()`重绘仪表盘；
   - `DataTimer(500ms)`：周期读取寄存器更新界面表格；计数器每6次（3s）执行一次MySQL入库。
3. 实体`DeviceTempRecord`实现`INotifyPropertyChanged`，配合`BindingList`表格自动刷新。
4. 自定义双缓冲Panel消除GDI绘图闪烁。
5. 串口/Modbus用完必须释放资源；窗体关闭事件做资源清理。
6. 子窗体历史查询：`DateTimePicker`时间联动约束；`DataTable.Compute()`做最大、最小、平均聚合统计；`SaveFileDialog`导出JSON。
7. 日志：FlowLayoutPanel动态生成Label，警告文字标红。
8. 注意：示例SQL直接拼接字符串，正式项目必须参数化`AddWithValue`防注入。

------

# 高频面试/考试速记问答（背诵）

1. Q：InvokeRequired作用？子线程为什么不能直接操作UI？

   > A：判断当前线程是否UI线程；WinForm控件线程亲和性，控件属于创建它的UI线程；子线程用Invoke封送委托到UI线程执行。

2. Q：List与BindingList绑定表格区别？

   > A：List修改对象属性UI更新，Add/Remove集合界面不刷新；BindingList实现集合变更通知，增删元素UI自动刷新。

3. Q：INotifyPropertyChanged接口作用？

   > A：实体属性修改后触发通知，绑定控件自动刷新UI，实现数据双向绑定。

4. Q：Task的Result/await区别？

   > A：Result阻塞调用线程，UI线程直接卡死；await非阻塞等待，交出线程不卡界面。

5. Q：SerialPort打开常见两个异常？

   > A：UnauthorizedAccessException串口被占用；IOException串口设备不存在；用完务必Close释放。

6. Q：Modbus主站从站概念？哪个寄存器最常用？

   > A：主站：上位机软件主动读写；从站PLC/传感器；**保持寄存器HoldingRegisters最常用**。

7. Q：GDI画图闪烁怎么解决？

   > A：自定义双缓冲Panel，开启`OptimizedDoubleBuffer`，全部绘图先在内存画布完成再拷贝屏幕。

8. Q：递归必备条件？

   > A：函数调用自身；**必须有终止基线条件**，否则栈溢出StackOverflowException。

9. Q：Dock与Anchor优先级？

   > A：Dock优先级高于Anchor，设置Dock之后Anchor失效。

10. Q：Settings赋值后重启数据丢失为什么？

    > A：赋值仅修改内存，必须调用`Save()`才写入本地配置文件。

