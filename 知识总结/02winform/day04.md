# day04｜WinForm事件综合实战、常用业务案例、多窗体基础 结构化总结

> 承接day03鼠标键盘事件；重点：各类业务实战小案例、多控件共用事件方法、窗体生命周期与多窗体基础。

## 1、上节回顾

1. 事件参数：`MouseEventArgs`鼠标、`KeyEventArgs`键盘物理按键、`KeyPressEventArgs`字符按键。
2. `sender`为object，使用前需要`as`强制转换；转换失败得到null，建议做判空。
3. 辅助API
   - `控件.Focus()`：把控件设置为获得焦点（光标）
   - `控件.Visible`：控制显示隐藏
   - `comboBox.DroppedDown`：控制下拉框展开收起
   - `窗体.Close()`关闭窗体

## 2、高频实战案例

### ①键盘控制控件移动 + 边界限制

> 窗体设置`FormBorderStyle=None`去掉标题栏，避免坐标计算异常；增加边界判断，控件不能移出窗体可视区域。

- `KeyDown`监听W/A/S/D；修改控件`Location`；做最大最小坐标边界判断；ESC调用`this.Close()`关闭窗体。
- 新增逻辑：记录`StartTime`按下时间、`EndTime`松开时间，`TimeSpan`计算按键按下持续毫秒时长；用布尔flag开关，防止长按重复计数。

### ②KeyPress拦截指定字符输入

- 拦截某个按键：`e.Handled=true`取消本次输入；例如禁止输入字符`'4'`。

### ③PictureBox鼠标移入放大、移出复原

`MouseEnter`放大宽高；`MouseLeave`恢复原始尺寸。

### ④TextBox业务案例

1. 限制最大输入长度（TextChanged）
   - 判断文本`Text.Length`，超出则`Substring`截取；
   - `SelectionStart`手动设置光标位置，防止光标跳到文本开头。
2. 密码强度检测（TextChanged+正则）
   - 正则分别匹配数字、大写、小写；统计匹配种类，区分弱/中/强，同步修改Label文字与颜色。
3. 数字千分位格式化（TextChanged）
   - 先把原有逗号全部清除，解析数字，使用格式化字符串`ToString("#,#")`实现千分位；手动设置光标。
4. **输入自动全部转大写**：`ToUpper()`处理文本，重置光标。

### ⑤ListBox列表业务

1. 列表框实时过滤搜索
   - 数据源保存原始集合；`TextBox.TextChanged`拿到搜索关键字；`FindAll(item.Contains(关键字))`过滤；清空`Items`再`AddRange`赋值。
2. **获取选中项**：`SelectedItem`获取选中对象。

### ⑥下拉框二级联动

> 省‑市联动案例

1. 准备嵌套关系数据源，用`parent_id`建立父子关联；
2. 一级下拉框加载全部父级（省份，`parent_id=0`）；
3. 一级`SelectedIndexChanged`触发，拿到选中省份ID；
4. 根据`parent_id`筛选对应的子项（城市），赋值给第二个下拉框。

### ⑦多控件共用同一个事件处理函数

依靠`sender`区分是哪一个控件触发事件，判断`Name`属性执行不同逻辑。

```
private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
{
    ComboBox cbo = sender as ComboBox;
    if(cbo == null || cbo.SelectedIndex == -1) return;
    if(cbo.Name == "cboSort"){ /*排序*/ }
    else if(cbo.Name == "cboFilter"){ /*过滤*/ }
}
```

### ⑧坐标转换（拖拽绘图会用到）

| 方法                             | 作用                               |
| -------------------------------- | ---------------------------------- |
| `控件.PointToScreen(e.Location)` | 把控件内部坐标转为屏幕屏幕绝对坐标 |
| `Point.Offset(dx,dy)`            | 对点进行坐标偏移                   |
| `父容器.PointToClient(point)`    | 把屏幕坐标转为容器内部相对坐标     |

## 3、窗体操作（多窗体基础）

1. 添加新窗体：项目右键 → 添加 → Windows窗体，生成新的`.cs`窗体类。

2. 窗体核心方法

   | 方法                 | 说明                                 |
   | -------------------- | ------------------------------------ |
   | `窗体实例.Show()`    | 显示非模态窗体，可以来回切换多个窗口 |
   | `窗体实例.Hide()`    | 隐藏窗体，对象还在内存，没有销毁     |
   | `窗体实例.Close()`   | 关闭并释放窗体资源                   |
   | `Application.Exit()` | 完全退出整个应用程序，全部窗体关闭   |

### 窗体生命周期事件

| 事件          | 触发时机                                  | 典型用途                 |
| ------------- | ----------------------------------------- | ------------------------ |
| `Load`        | 窗体第一次加载显示**之前，仅执行1次**     | 初始化控件、加载配置数据 |
| `Shown`       | 窗体已经渲染、完全显示出来之后执行        | 窗体加载完成后执行操作   |
| `FormClosing` | 窗体正要关闭；`e.Cancel=true`可以阻止关闭 | 弹窗确认是否退出程序     |
| `FormClosed`  | 窗体已经关闭完毕                          | 释放资源、清理           |
| `Resize`      | 窗体大小发生改变                          | 做控件自适应布局         |

> ⚠️注意：`Load`阶段控件还没有完全渲染，部分绘图/坐标操作建议放到`Shown`。

## 4、易错点

1. `sender as 类型`，一定要判null，防止转换异常。
2. `KeyDown`长按会持续重复触发；需要布尔flag开关控制只执行一次逻辑。
3. TextBox在`TextChanged`修改Text之后，光标会跳到开头；需要手动设置`SelectionStart`。
4. `Hide()`只是隐藏窗体，对象仍然驻留内存；`Close()`才释放窗体资源。
5. 窗体`Load`事件执行时界面尚未渲染完成，部分绘图、坐标逻辑放到`Shown`。
6. 二级联动注意数据源父子关联字段；切换一级下拉要清空二级下拉的旧数据。

## 5、工业视觉上位机拓展

1. TextBox：参数输入框限制最大长度、数字格式化；密码/权限模块做强度校验。
2. ListBox+TextBox实现搜索过滤：设备列表、缺陷记录列表快速检索。
3. 二级联动：相机参数（选择相机型号，联动加载该型号可用分辨率列表）。
4. 多窗体：主窗体、弹窗、参数配置窗口；`Show()`打开子窗口；`FormClosing`退出确认。
5. 坐标转换：PictureBox图像上做鼠标拖拽ROI区域，PointToScreen / PointToClient。

## 📝面试问答

**Q1：Hide()和Close()窗体的区别？😃**

> A：`Hide()`只是把窗体隐藏，窗体对象依旧保存在内存，资源不释放；`Close()`关闭窗体，释放窗体资源。

**Q2：窗体Load与Shown事件区别？🤔**

> A：`Load`：窗体显示**之前执行，只运行一次**，适合初始化数据；此时界面还没有绘制完成； `Shown`窗体**已经完整显示渲染完成**，适合执行绘图、获取控件真实宽高等操作。

**Q3：多个不同控件绑定同一个事件处理函数，如何区分是谁触发？**

> A：通过`sender`，`as`强转为对应控件，判断`Name`属性区分来源。

**Q4：TextBox在TextChanged修改文本，光标跑到开头怎么解决？**

> A：修改完Text，手动设置`textBox.SelectionStart = textBox.Text.Length`把光标挪到末尾。

> 工业视觉补充：视觉上位机大量二级联动场景，例如选择相机型号，联动分辨率；参数输入框做长度、格式限制；子配置弹窗窗体使用Show()打开。

