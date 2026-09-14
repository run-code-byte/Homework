# day11｜WinForm 文件对话框、INotifyPropertyChanged双向数据绑定、DataGridView表格进阶 结构化总结

> 承接day10，重点：三类文件对话框、简单/复杂双向绑定、DataGridView高级用法，工业上位机表格高频考点。

## 1、文件对话框

> 推荐`using`包裹实例，自动释放资源，避免手动`Dispose()`。`ShowDialog()`返回`DialogResult.OK`代表用户确认选择。

### OpenFileDialog（打开文件）

| 属性               | 说明                                                      |
| ------------------ | --------------------------------------------------------- |
| `Filter`           | 文件过滤器，格式：`显示文本|*.后缀|显示文本|*.后缀`       |
| `Multiselect`      | 是否多选文件                                              |
| `InitialDirectory` | 初始打开目录，常用 `Application.StartupPath` 程序运行目录 |
| `RestoreDirectory` | 记住上次打开的目录                                        |
| `FileName`         | 单选获取完整路径；`FileNames` 多选获取路径数组            |

### SaveFileDialog（保存文件）

- `FileName`默认文件名；`DefaultExt`默认后缀；`AddExtension`自动补后缀；
- `OverwritePrompt=true`，文件存在弹出覆盖提示（默认开启）。

### FolderBrowserDialog（选择文件夹）

- `SelectedPath`拿到选中文件夹路径；`Description`弹窗提示文字。

## 2、数据绑定

### 2.1 简单绑定（单控件：TextBox、Label、CheckBox）

1. **核心条件：实体类必须实现 INotifyPropertyChanged 接口**
2. 属性setter内部触发：`PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(属性名)))`，通知UI刷新，实现双向同步。
3. 绑定语法：

```
控件.DataBindings.Add("控件属性", 实体对象, "对象属性名");
```

> Label做双向绑定需要额外传参数：`DataSourceUpdateMode.OnPropertyChanged`。

### 2.2 复杂绑定（集合绑定，DataGridView / ListBox / ComboBox）

数据源可选：`List<T>`、`BindingList<T>`、`DataTable`

1. `List<T>`：修改对象内部属性UI会更新；**集合Add/Remove，表格界面不会自动刷新**。

2. ```
   BindingList<T>
   ```

   ⭐表格优先使用：实现集合变更通知，增删元素UI自动刷新。

   > 配套实体建议实现`INotifyPropertyChanged`，单元格编辑修改属性同步到实体。

## 3、DataGridView 进阶

### 基础配置

```
dataGridView1.AllowUserToAddRows = false;      //关闭自动新增空白行
dataGridView1.AllowUserToDeleteRows = false;   //禁止用户删除行
dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //整行选中
dataGridView1.MultiSelect = false;             //禁止多选
dataGridView1.ReadOnly = true;                 //单元格只读
dataGridView1.EnableHeadersVisualStyles = false;//关闭系统主题，自定义表头颜色生效
dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; //隔行变色
dataGridView1.AutoGenerateColumns = false;     //关闭自动生成列，手动定义列
```

### 列操作

1. 按钮列 `DataGridViewButtonColumn`：表格行内编辑、删除按钮；`UseColumnTextForButtonValue=true`统一显示按钮文字。
2. `Columns["列名"].Visible=false`隐藏列；`Columns.Remove()`删除列；设置`Width`列宽。
3. `AutoSizeColumnsMode`设置列自动适配宽度。

### 行与单元格

1. **绑定模式下，不要直接调用Rows.Add()**；解除`DataSource=null`后，才可以手动添加行。
2. 单元格读写：`Rows[行索引].Cells["列名"].Value`
3. `DataBoundItem`：获取当前行绑定的实体对象。

### 常用事件

| 事件               | 作用                                                         |
| ------------------ | ------------------------------------------------------------ |
| `CellClick`        | 单元格点击；**e.RowIndex<0代表点击表头，业务代码要过滤**     |
| `SelectionChanged` | 选中行切换触发                                               |
| `CellEndEdit`      | 单元格编辑完成触发                                           |
| `DataError`        | 捕获绑定格式异常；设置`e.ThrowException=false`屏蔽系统报错弹窗 |

## 4、易错点

1. 文件对话框务必判断`ShowDialog() == DialogResult.OK`，再读取路径；using自动释放资源。
2. 双向绑定实体不实现`INotifyPropertyChanged`，修改实体属性UI不会自动更新。
3. `List<T>`绑定表格，Add/Remove集合界面不会刷新；优先`BindingList<T>`。
4. 修改表头背景色，需要设置`EnableHeadersVisualStyles=false`，否则系统主题会覆盖自定义颜色。
5. 绑定模式下不能直接`Rows.Add()`，必须先把`DataSource=null`解除绑定，才能手动操作行。
6. CellClick事件要过滤`e.RowIndex<0`表头点击，防止下标越界异常。

## 5、工业视觉上位机拓展

1. OpenFileDialog打开图片、配置；SaveFileDialog导出检测报表；FolderBrowser设置图片输出目录。
2. DataGridView展示缺陷、产品检测记录；按钮列做行内删除编辑；隔行变色提高可读性。
3. BindingList + INotifyPropertyChanged，表格与实体双向同步，做参数配置界面。

## 📝面试问答（对话式✨）

**Q1：List 和 BindingList 绑定DataGridView有什么区别？😃**

> A：List修改实体属性UI可以更新；但是集合Add、Remove不会自动刷新表格UI。 BindingList实现集合变更通知，增删集合元素，表格UI自动刷新，表格绑定优先选用。

**Q2：INotifyPropertyChanged接口的用途？🤔**

> A：实现属性变更通知；实体属性发生修改时，触发事件通知绑定的UI控件刷新，完成双向数据同步。

**Q3：DataGridView设置表头背景色，颜色不生效是什么原因？**

> A：需要设置`EnableHeadersVisualStyles=false`，关闭系统视觉样式，自定义表头颜色才会生效。

**Q4：DataGridView绑定DataSource之后，为什么不能直接Rows.Add新增行？**

> A：绑定数据源模式，行由数据源控制；想要手动Rows.Add，必须设置`DataSource=null`解除绑定。

**Q5：CellClick事件为什么要判断e.RowIndex >= 0？**

> A：`e.RowIndex < 0`代表点击了表头，表头不存在业务数据，直接处理会造成下标异常，需要过滤。

> 工业视觉补充：缺陷列表表格几乎都用BindingList绑定；对话框用于图片、报表导入导出。

> 如果你需要，我可以把day01‑day11整套WinForm合并为完整背诵复习文档。