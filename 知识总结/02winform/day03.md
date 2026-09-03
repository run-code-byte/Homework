# day03｜WinForm事件编程、事件参数、常用实战案例 结构化总结

> 承接day02容器与Controls集合；重点：各类事件参数、鼠标/键盘/焦点事件、大量上位机常用实战案例。

## 1、上节回顾

1. 容器

   - 简单容器：`Form`、`Panel`、`GroupBox`、`TabControl`
   - 布局容器：`FlowLayoutPanel`流式、`TableLayoutPanel`表格、`SplitContainer`分割面板

2. **Controls集合**：容器子控件集合，`Add`/`Remove`/`Clear`/`IndexOf`，`控件.Parent`获取父容器。

3. 事件三要素：

   事件源、事件类型、事件处理方法

   - 绑定：`控件.事件 += 方法`；解绑：`控件.事件 -= 方法`；同一个事件可以绑定多个处理方法。

## 2、各类事件参数对象

### ① 鼠标事件 MouseEventArgs

| 属性        | 说明                                       |
| ----------- | ------------------------------------------ |
| `e.X / e.Y` | 鼠标相对于控件客户区坐标                   |
| `e.Button`  | 鼠标按键：`MouseButtons.Left/Right/Middle` |
| `e.Clicks`  | 点击次数，单击1，双击2                     |
| `e.Delta`   | 鼠标滚轮滚动值                             |

### ② 键盘 KeyEventArgs（KeyDown / KeyUp）

| 属性                      | 说明                                                |
| ------------------------- | --------------------------------------------------- |
| `e.KeyCode`               | 物理按键枚举 `Keys.Enter`、`Keys.Escape`、`Keys.F1` |
| `e.Control / Shift / Alt` | 判断是否按下修饰键                                  |
| `e.Handled`               | true 取消本次按键处理                               |
| `e.SuppressKeyPress`      | 更强，抑制字符输入                                  |

### ③ KeyPressEventArgs（KeyPress，字符按键）

| 属性             | 说明                             |
| ---------------- | -------------------------------- |
| `e.KeyChar`      | 得到输入字符，退格为`(char)8`    |
| `e.Handled=true` | **拦截字符，不让字符进入文本框** |

### ④ FormClosingEventArgs 窗体关闭

| 属性            | 说明                                    |
| --------------- | --------------------------------------- |
| `e.Cancel=true` | 取消关闭窗体，阻止退出程序              |
| `e.CloseReason` | 获取窗体关闭原因（用户点X、系统关机等） |

### ⑤ CancelEventArgs（Validating校验事件）

| 属性            | 说明                               |
| --------------- | ---------------------------------- |
| `e.Cancel=true` | 阻止焦点离开当前控件，用于表单校验 |

### ⑥ 焦点事件执行顺序

`GotFocus` 获取焦点 → 用户操作 → `Validating`(校验) → `Validated`(校验成功) → `Leave`真正失去焦点。

## 3、高频实战案例（工业上位机常用）

### 案例1：Label模拟网页超链接（MouseEnter / MouseLeave）

鼠标移入变色+下划线，移出恢复样式。

```
private void lab2_MouseEnter(object sender,EventArgs e)
{
    lab2.ForeColor = Color.Purple;
    lab2.Font = new Font("Microsoft YaHei UI",9F,FontStyle.Underline,GraphicsUnit.Point);
}
private void lab2_MouseLeave(object sender,EventArgs e)
{
    lab2.ForeColor = Color.Blue;
    lab2.Font = new Font("Microsoft YaHei UI",9F,FontStyle.Regular,GraphicsUnit.Point);
}
```

### 案例2：输入框失去焦点手机号正则校验（Leave事件）

```
private void TextBox1_Leave(object sender, EventArgs e)
{
    TextBox tb = sender as TextBox;
    string content = tb.Text;
    if(Regex.IsMatch(content,@"^1[1-9]\d{9}$"))
    {
        labT.Visible = true; //校验成功提示
    }
    else
    {
        labF.Visible = true; //失败提示
    }
}
```

### 案例3：获取/失去焦点，控件高亮（GotFocus / Leave）

获得焦点修改背景色边框，失去焦点恢复；用于参数输入框视觉提示。

### 案例4：下拉框获得焦点自动展开 DroppedDown

```
private void ComboBox1_GotFocus(object sender, EventArgs e)
{
    ComboBox cb = sender as ComboBox;
    cb.DroppedDown = true;
}
private void ComboBox1_Leave(object sender, EventArgs e)
{
    ComboBox cb = sender as ComboBox;
    cb.DroppedDown = false;
}
```

### 案例5：焦点拦截，输入框不能为空，禁止光标离开

> 输入为空时，调用`tb.Focus()`强制拿回光标。

```
private void Tb1_Leave(object sender, EventArgs e)
{
    TextBox tb = sender as TextBox;
    if(string.IsNullOrEmpty(tb.Text))
    {
        tb.Focus();
        label1.Visible = true;
    }
}
```

### 案例6：回车键提交表单（KeyUp + Keys.Enter）

```
private void TextBox1_KeyUp(object sender, KeyEventArgs e)
{
    if(e.KeyCode == Keys.Enter)
    {
        MessageBox.Show("模拟提交");
    }
}
```

### 案例7：ESC按键关闭窗体

```
private void KeyTest_KeyDown(object sender, KeyEventArgs e)
{
    if(e.KeyCode == Keys.Escape)
    {
        this.Close();
    }
}
```

### 案例8：Ctrl组合快捷键（Ctrl+C复制、Ctrl+S保存）

```
private void TextBox1_KeyDown(object sender, KeyEventArgs e)
{
    if(e.Control && e.KeyCode == Keys.C)
        MessageBox.Show("复制");
    if(e.Control && e.KeyCode == Keys.S)
        MessageBox.Show("保存");
}
```

### 案例9：文本框只允许输入数字（KeyPress拦截非法字符）⭐上位机参数输入高频

```
private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
{
    //不是数字字符直接拦截
    if (e.KeyChar < '0' || e.KeyChar > '9')
    {
        e.Handled = true;
    }
}
```

### 案例10：键盘WASD移动控件位置

> 将窗体`FormBorderStyle=None`去掉标题栏，防止坐标偏移；修改控件`Location`实现移动。

## 4、易错点

1. `sender`是object类型，必须强制转型`sender as 控件类型`使用。
2. `KeyPress`拿到的是**字符**；`KeyDown/KeyUp`拿到物理按键`KeyCode`枚举。
3. `e.Handled = true`在`KeyPress`拦截字符；`KeyEventArgs.Handled`拦截按键消息。
4. `Validating`事件`e.Cancel=true`可以阻止焦点离开，比Leave+Focus更优雅，避免死循环。
5. 同一个事件可以绑定多个方法，也可以`-=`解绑事件。
6. `DroppedDown`控制ComboBox下拉框是否展开。

## 5、工业视觉上位机拓展

1. **KeyPress拦截**：参数文本框，只允许输入数字/小数，防止非法硬件参数。
2. 快捷键：ESC关闭弹窗，Ctrl+S保存参数，Enter确认输入，WASD模拟移动物体。
3. `GotFocus/Leave`：参数输入框高亮，给操作工视觉反馈。
4. 鼠标事件`MouseMove`配合PictureBox，获取图像像素坐标。
5. 表单校验优先`Validating`事件，校验失败阻止焦点切换。

## 📝面试问答

**Q1：KeyDown与KeyPress的区别？😃**

> A：`KeyDown/KeyUp`拿到**物理按键KeyCode**，可以识别Ctrl、Shift、F1‑F12；`KeyPress`拿到输入字符，适合拦截文本框输入字符。

**Q2：想让TextBox只能输入数字，怎么做？🤔**

> A：绑定`KeyPress`事件；判断`e.KeyChar`，非数字字符设置`e.Handled=true`拦截输入。

**Q3：Leave事件校验输入，tb.Focus()拿回光标会出现焦点死循环，怎么优化？**

> A：优先用`Validating`事件，设置`e.Cancel=true`，框架自动阻止焦点离开，不需要手动调用Focus，避免死循环。

**Q4：sender参数是什么？事件可以解绑吗？**

> A：sender是触发事件的控件对象，object类型需要强转；可以使用`控件.事件 -= 方法名`解绑事件。

> 工业视觉补充：视觉上位机大量文本框用来输入相机曝光、坐标阈值；经常做键盘输入拦截、快捷键、表单校验。

