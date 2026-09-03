# day02｜WinForm容器、代码动态创建控件、Controls集合、事件编程 结构化总结

> 承接day01 WinForm基础，重点：容器嵌套布局、代码动态创建控件、Controls集合、事件驱动编程，工业上位机高频知识。

## 1、上节回顾

基础控件：`Button`、`Label`、`TextBox`、`CheckBox`、`RadioButton`、`ComboBox`、`ListBox`、`RichTextBox`、`DateTimePicker`、`PictureBox`。 控件分为**普通控件**与**容器控件**；容器可以嵌套控件，实现分组。

## 2、容器控件

### ①简单容器（不会自动排布子控件，子控件依靠`Location`/`Dock`/`Anchor`）

1. **Form（根容器）**

- `Text`窗体标题；`MaximizeBox`/`MinimizeBox`显示最大化最小化按钮；

- ```
  StartPosition
  ```

  窗体启动位置：

  - `CenterScreen`：屏幕居中；
  - `CenterParent`：父窗体居中，多用于子弹窗；
  - `Manual`：由Location决定位置。

1. **Panel**：无边框无标题；`AutoScroll=true`内容溢出出现滚动条。
2. **GroupBox**：带边框+标题，视觉模块分组，**无滚动条**。
3. **TabControl选项卡**：多标签页切换；`TabPages`标签集合；`Multiline`标签多行显示；`Alignment`设置标签上下左右位置。

> RadioButton单选互斥规则：**只在同一个容器内部互斥**；多组单选，放到不同Panel/GroupBox。

### ②布局容器（接管子控件位置，子控件Location基本失效）

1. **FlowLayoutPanel流式布局**：控件自动水平/垂直排列，空间不足自动换行；子控件`Anchor`、`Dock`全部失效；`FlowDirection`流向；`WrapContents`是否换行；`Padding`内边距。

2. **TableLayoutPanel表格布局**：网格单元格布局；支持像素、百分比、自适应尺寸；支持`RowSpan`/`ColumnSpan`单元格合并；**一个单元格只能放一个控件，多个控件要嵌套Panel**。

3. SplitContainer分割容器

   ：可拖动分割条，分为

   ```
   Panel1
   ```

   、

   ```
   Panel2
   ```

   ；

   - `SplitterDistance`分割条位置；`SplitterWidth`分割条粗细；
   - `Panel1MinSize`/`Panel2MinSize`设置面板最小尺寸；
   - `IsSplitterFixed`固定分割条禁止拖动；`Panel1Collapsed`折叠面板。

### 布局两个核心属性

1. `Dock`：把控件贴靠父容器四边；**Dock优先级高于Anchor，设置Dock后Anchor失效**。

2. ```
   Anchor
   ```

   锚点：绑定父容器四边；窗体缩放，控件跟随拉伸或者保持角落位置；

   - `Anchor=Bottom,Right`：控件固定在右下角，适合确定、取消按钮。

> 💡实战：容器大量嵌套。示例：外层SplitContainer →左侧放TreeView；右侧TabControl；Tab页内部TableLayoutPanel做表单。

## 3、代码动态创建、管理控件（Controls集合）

1. 控件本质就是类，可以`new`实例化；**new完不会自动显示，必须加入容器的Controls集合**。

```
Button btn = new Button()
{
    Location = new Point(200,100),
    Size = new Size(100,40),
    Text = "按钮"
};
this.Controls.Add(btn); //添加到窗体
```

1. `Control`是**所有控件的基类**，所有控件都可以用Control接收。

### Controls容器集合常用成员

| 成员                     | 功能                                   |
| ------------------------ | -------------------------------------- |
| `Add(ctl)`               | 添加单个控件                           |
| `AddRange(ctl数组)`      | 批量添加控件                           |
| `Remove(ctl)`            | 删除指定控件对象                       |
| `RemoveAt(index)`        | 按下标删除控件                         |
| `Clear()`                | 清空容器全部子控件                     |
| `GetChildIndex(ctl)`     | 获取控件下标                           |
| `SetChildIndex(ctl,idx)` | 修改控件Z‑Order下标层级                |
| `Contains(ctl)`          | 判断容器是否包含该控件                 |
| `Controls[index]`        | 按下标获取控件                         |
| `Controls["控件Name"]`   | 按Name属性查找控件                     |
| `ctl.Parent`             | 获取控件所属父容器，主窗体Parent为null |

> 注意：**一个控件同一时间只能属于一个父容器**；Add到另一个容器会自动从旧容器移除。

## 4、事件编程（WinForm事件驱动）

### 事件三要素

1. **事件源**：触发事件的控件对象；
2. **事件类型**：行为，点击、鼠标移动、文本变更；
3. **事件处理方法**：触发之后执行的函数。

绑定语法：`控件.事件 += 事件处理方法;`

```
btn.Click += Btn_Click;
private void Btn_Click(object sender, EventArgs e)
{
    //sender：object，触发事件的控件对象，强制转换使用
    //e：事件参数，携带事件附加信息
}
```

弹窗提示：`MessageBox.Show("内容","标题",MessageBoxButtons.YesNo,MessageBoxIcon.Question)`；返回`DialogResult`枚举。

### 高频常用事件

#### 通用事件（绝大多数控件可用）

| 事件                          | 触发时机             | 用途                     |
| ----------------------------- | -------------------- | ------------------------ |
| `Click`                       | 鼠标左键单击         | 按钮点击业务逻辑         |
| `MouseDown/MouseUp/MouseMove` | 鼠标按下、松开、移动 | 绘图、获取鼠标坐标、拖拽 |
| `MouseEnter/MouseLeave`       | 鼠标进入/离开控件    | 悬浮样式切换             |
| `KeyDown/KeyUp`               | 键盘按下松开         | 捕获快捷键               |
| `KeyPress`                    | 字符按键             | 拦截非法字符输入         |
| `GotFocus`                    | 控件获得焦点         | 输入框提示处理           |
| `LostFocus / Leave`           | 失去焦点             | 输入完成做校验           |

#### 专项控件高频事件

1. `TextBox`：`TextChanged`⭐每输入一个字符就触发；实时过滤、实时计数。
2. `ComboBox / ListBox`：`SelectedIndexChanged`⭐选中项切换触发；联动加载数据。

#### 输入控件事件执行顺序

`GotFocus` → 用户操作 → `Validating`（失去焦点前校验，可e.Cancel=true阻止离开） → `Validated`校验通过 → `Leave`真正失去焦点。

### 事件参数对象

1. `MouseEventArgs`鼠标事件：`e.X`、`e.Y`坐标；`e.Button`区分左右中键；`e.Delta`鼠标滚轮。
2. `KeyEventArgs`：`e.KeyCode`物理按键；`e.Control/Shift/Alt`判断修饰键；`e.Handled=true`拦截按键。
3. `KeyPressEventArgs`：`e.KeyChar`字符；`e.Handled=true`拦截字符输入。
4. `FormClosingEventArgs`窗体关闭：`e.Cancel=true`取消关闭窗体。
5. `CancelEventArgs`校验事件：`e.Cancel=true`阻止焦点切换。

## 5、易错点

1. `Dock`优先级高于`Anchor`，设置Dock，Anchor会被忽略。
2. 布局容器`FlowLayoutPanel`、`TableLayoutPanel`，子控件`Location`基本失效，容器接管布局。
3. RadioButton互斥范围仅限于**同一个容器**，多组单选要放在不同Panel/GroupBox。
4. 代码new出来的控件，**必须调用Controls.Add()才会显示到界面**。
5. 一个控件只能归属一个父容器，重复Add会自动脱离原来容器。
6. `sender`是object类型，需要强制转型回对应控件类型。
7. `Validating`做表单校验，设置`e.Cancel=true`可以阻止焦点离开，防止非法数据。

## 6、工业视觉上位机拓展

1. 动态生成控件：运行时动态生成按钮、图片框，用于动态显示多个缺陷点位。
2. `SplitContainer`：左侧参数面板，右侧PictureBox图像显示，视觉软件标准布局。
3. `TableLayoutPanel`用来整齐排布大量参数输入框。
4. 鼠标事件`MouseMove`，在PictureBox获取图像坐标；
5. 表单大量使用`Validating`做输入校验，防止非法硬件参数输入。

## 📝面试问答

**Q1：Dock和Anchor的区别，优先级？😃**

> A：Dock把控件贴靠父容器四边；Anchor锚定父容器边角，窗体缩放控件跟随拉伸。**Dock优先级高于Anchor，设置Dock后Anchor失效。**

**Q2：RadioButton怎么做多组互斥单选？🤔**

> A：同一个容器内RadioButton自动互斥；多组单选放到不同Panel/GroupBox容器。

**Q3：代码new Button之后为什么界面看不到？**

> A：new只是创建对象；必须调用`容器.Controls.Add(btn)`加入容器集合，界面才渲染显示。

**Q4：事件里面sender参数是什么？**

> A：sender是object类型，代表**触发本次事件的控件对象**，需要强制转换成对应控件类型使用。

**Q5：Validating事件作用？**

> A：控件将要失去焦点时触发；设置`e.Cancel=true`，阻止焦点离开，用于表单输入校验，拦截非法参数。

> 工业视觉补充：上位机经常动态生成控件展示多个缺陷；PictureBox结合MouseMove获取图像像素坐标做检测交互。

