# day10｜WinForm菜单、对话框、Timer定时器、数据绑定、DataGridView表格 结构化总结

> 重点：MenuStrip/ToolStrip菜单工具栏；各类文件对话框；Timer定时器；INotifyPropertyChanged数据双向绑定；DataGridView表格控件全套用法。

## 1、菜单栏与工具栏

### MenuStrip 主菜单栏

1. 在Text属性使用`&字母`设置Alt快捷键，例 `&文件`，Alt+F触发菜单。
2. 右键菜单→编辑项，可以设置图标、显示文字。

### ToolStrip 工具栏

- 放置在菜单栏下方，可添加按钮、下拉框、文本、分割线；快速调用常用功能。

## 2、文件对话框（弹窗选择文件/文件夹）

> 建议使用`using`包裹对象，自动释放资源，不需要手动Dispose()。

### ① OpenFileDialog 打开文件

| 重要属性           | 说明                                                    |
| ------------------ | ------------------------------------------------------- |
| `Filter`           | 文件过滤器，格式：`显示文本                             |
| `Multiselect`      | bool，是否允许多选文件                                  |
| `InitialDirectory` | 初始打开路径，常用`Application.StartupPath`程序运行目录 |
| `RestoreDirectory` | 记住上次打开的目录                                      |
| `FileName`         | 单选获取选中文件完整路径                                |
| `FileNames`        | 多选获取所有文件路径字符串数组                          |

```
using(OpenFileDialog ofd = new OpenFileDialog())
{
    ofd.Title = "选择文件";
    ofd.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
    ofd.Multiselect = true;
    if(ofd.ShowDialog() == DialogResult.OK)
    {
        string path = ofd.FileName;
    }
}
```

### ② SaveFileDialog 保存文件对话框

- `FileName` 默认文件名；`DefaultExt` 默认后缀；`AddExtension` 自动补后缀。
- `OverwritePrompt=true`，文件已存在弹出覆盖确认提示（默认开启）。

### ③ FolderBrowserDialog 选择文件夹

- `SelectedPath` 获取选中的文件夹路径；`Description`弹窗提示文字。

> `ShowDialog()`返回`DialogResult.OK`代表用户确认选择。

## 3、Timer WinForm窗体定时器（UI定时器）

> ⚠️**System.Windows.Forms.Timer，事件Tick运行在UI主线程，不新开子线程**。

1. 属性
   - `Interval`：触发间隔，单位**毫秒**。
2. 方法
   - `Start()`：启动；`Stop()`停止。
3. 事件：`Tick`，每间隔Interval就执行一次。

```
System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
timer.Interval = 20;
timer.Tick += Timer_Tick;
timer.Start();

private void Timer_Tick(object sender, EventArgs e)
{
    //UI操作，可以直接修改控件
}
```

> 区分：不是System.Timers.Timer，后者会跑在子线程，不能直接操作UI。

## 4、数据绑定

### ①简单绑定（单个控件属性绑定实体属性）

- 适用控件：TextBox、Label、CheckBox等单值控件。
- 前提条件：实体类实现 **INotifyPropertyChanged接口**。
- 在属性set里面调用 `PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(属性名)))`，通知UI刷新，实现双向同步。

绑定语法：

```
控件.DataBindings.Add("控件属性", 实体对象, "对象属性名");
```

### ②复杂绑定（集合绑定列表/表格控件）

适用控件：`DataGridView`、`ListBox`、`ComboBox`

1. `List<T>`：修改集合内部对象属性UI会更新；**直接Add/Remove集合，界面不会自动刷新**。
2. `BindingList<T>`：继承List，实现集合变更通知；Add/Remove，表格UI会自动同步刷新⭐表格绑定优先选它。

> 实体依旧建议实现`INotifyPropertyChanged`，单元格编辑可以同步实体对象。

## 5、DataGridView 表格控件⭐上位机高频

### 基础常用配置

```
dataGridView1.AllowUserToAddRows = false;     //关闭自动新增空白行
dataGridView1.AllowUserToDeleteRows = false;  //禁止用户删除行
dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //整行选中
dataGridView1.MultiSelect = false;            //禁止多选
dataGridView1.ReadOnly = true;                //只读不可编辑
dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; //隔行变色
```

### 列操作

1. 新增按钮列 `DataGridViewButtonColumn`，实现表格行内删除/编辑按钮。
2. `Columns["列名"].Visible = false;` 隐藏指定列；`Columns.Remove()`删除列；设置`Width`列宽。
3. `AutoSizeColumnsMode` 自动适配列宽。

### 行与单元格操作

- `Rows.Add()`新增空行；`Rows.RemoveAt(index)`删除指定行；`Rows.Clear()`清空全部行。
- 读写单元格：`Rows[行索引].Cells["列名"].Value`。
- `DataBoundItem`：获取行绑定的实体对象。

### 核心事件

| 事件               | 用途                                                         |
| ------------------ | ------------------------------------------------------------ |
| `CellClick`        | 单元格点击；可判断点击按钮列，执行编辑删除业务               |
| `SelectionChanged` | 选中行切换触发                                               |
| `CellEndEdit`      | 单元格编辑完成之后触发                                       |
| `DataError`        | 捕获绑定格式异常，阻止系统弹出报错弹窗；设置`e.ThrowException=false` |

## 6、易错点

1. WinForm的`Timer`运行在UI主线程，Interval间隔内如果业务耗时久，界面会卡顿。
2. `List<T>`绑定DataGridView，集合Add/Remove界面不会刷新；优先`BindingList<T>`。
3. 双向绑定实体**必须实现INotifyPropertyChanged接口**，不实现，实体修改不会同步UI。
4. 文件对话框使用using自动释放资源；判断返回值`ShowDialog() == DialogResult.OK`再拿路径。
5. DataGridView的`DataError`事件一定要处理，输入格式错误避免程序弹出异常弹窗。
6. `e.RowIndex <0`代表点击表头，表格业务要过滤掉，不要处理。

## 7、工业视觉上位机拓展

1. MenuStrip/ToolStrip做软件主菜单、快捷功能按钮。
2. OpenFileDialog打开图片、配置文件；SaveFileDialog保存检测报表；FolderBrowserDialog选择图片输出目录。
3. Timer定时器：周期刷新相机状态、实时刷新倒计时、实时刷新UI计数。
4. DataGridView展示缺陷列表、产品检测记录；行内按钮实现单条记录编辑删除；隔行变色提升可读性。
5. BindingList+INotifyPropertyChanged做表格双向绑定，实体与表格数据自动同步。

## 📝面试问答

**Q1：WinForm Forms.Timer和普通System.Timers.Timer区别？😃**

> A：`System.Windows.Forms.Timer` Tick事件跑在UI主线程，可以直接操作控件；如果业务耗时会造成界面卡顿。 System.Timers.Timer运行在子线程，不能直接访问UI，需要跨线程更新界面。

**Q2：List<T> 和 BindingList<T>绑定DataGridView区别？🤔**

> A：List修改对象属性UI可以更新；但是集合Add/Remove，表格不会自动刷新。 BindingList实现集合变更通知，增删集合元素表格UI自动刷新，表格绑定优先使用。

**Q3：INotifyPropertyChanged接口作用？**

> A：用于数据双向绑定；实体属性修改后，通过事件通知UI控件刷新，实现实体对象和控件同步更新。

**Q4：OpenFileDialog的Filter格式要注意什么？**

> A：格式：`显示文本|*.后缀|显示文本|*.后缀`，竖线分割，格式写错对话框筛选异常。

**Q5：DataGridView点击按钮列，为什么要判断 e.RowIndex>=0？**

> A：e.RowIndex小于0代表点击表头，表头没有业务数据，需要过滤，防止下标报错。

> 工业视觉补充：检测软件大量DataGridView展示缺陷数据；定时器轮询设备状态；对话框打开保存图片、报告文件。

