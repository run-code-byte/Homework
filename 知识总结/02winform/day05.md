# day05｜WinForm实战：二级联动、事件复用、全选反选、窗体、第三方UI库 结构化总结

> 承接day04，重点：下拉框二级联动、多控件共用事件、CheckBox全选反选、坐标转换、窗体生命周期、AntdUI第三方UI库。

## 1、上节回顾

1. 控件位置大小：`Width`、`Height`；`Location`（Point类型，相对于父容器）、`Left`、`Top`。
2. 鼠标事件：`e.Location`鼠标相对控件坐标。
3. 开关思想：布尔变量标记状态，解决长按键盘重复执行逻辑。
4. 文本框光标：`SelectionStart` 获取/设置光标位置；修改Text后要重置光标。
5. ListBox / ComboBox：`Items`集合；`Add`、`AddRange`、`Clear`。

## 2、核心实战案例

### ① 下拉框二级联动

业务：省份‑城市联动。

1. 数据源：`List<Dictionary<string,dynamic>>`，使用`parent_id`维护父子关系；

2. 一级ComboBox加载父项（`parent_id=0`省份）；

3. 绑定

   ```
   SelectedIndexChanged
   ```

   ；选中省份后，根据省份id筛选出对应的子城市集合，赋值给第二个下拉框。

   > 拓展作业：改用`Dictionary<string,List<string>>`结构实现，key省份，value城市数组。

### ② 多控件复用同一个事件处理方法

1. 多个ComboBox绑定同一个事件函数；
2. 使用`sender as ComboBox`拿到触发控件；判空；
3. 通过控件`Name`属性区分来源，执行不同业务逻辑。

```
private void Change(object sender, EventArgs e)
{
    ComboBox cb = sender as ComboBox;
    if(cb==null||cb.SelectedIndex==-1) return;
    if(cb.Name=="PriceCb")
    {
        MessageBox.Show("价格排序");
    }
    else if(cb.Name=="TimeCb")
    {
        MessageBox.Show("时间排序");
    }
}
```

### ③ 下拉框换主题（自定义实体类绑定下拉）

1. 自定义简单实体`BcColor`，保存颜色名称+`Color`对象；
2. 把名称加载到ComboBox；
3. 选中后根据名称找到对应Color，修改窗体`BackColor`背景色。

### ④ CheckBox 全选 / 反选 / 半选⭐高频

1. 把多个子复选框放在同一个`Panel`容器；

2. 全选复选框使用`CheckState`三态枚举：`Checked`选中、`Unchecked`未选中、`Indeterminate`**半选（部分选中）**。

3. 子复选框

   ```
   CheckedChanged
   ```

   事件：

   - `All()`：判断**全部选中**；
   - `Any()`：判断**至少有一个选中**；
   - 根据两个布尔值设置全选框的`CheckState`。

4. 全选框`CheckStateChanged`：如果不是半选状态，遍历Panel内部CheckBox，统一设置Checked状态。

> 关键API

```
//筛选容器里面所有CheckBox
List<Control> childList = ChildPan.Controls.OfType<Control>().ToList();
bool isAll = childList.All(item => (item as CheckBox).Checked);
bool isAny = childList.Any(item => (item as CheckBox).Checked);
```

### ⑤ 拖拽相关坐标转换

| 方法                             | 功能说明                          |
| -------------------------------- | --------------------------------- |
| `控件.PointToScreen(e.Location)` | 控件内部坐标 → **屏幕绝对坐标**   |
| `Point.Offset(dx,dy)`            | 对Point点做X/Y偏移                |
| `父容器.PointToClient(point)`    | 屏幕坐标 → **父容器内部相对坐标** |

## 3、窗体相关

1. **新建窗体**：项目右键 → 添加 → Windows窗体，生成新Form类。
2. 窗体常用方法

```
form.Show();     //非模态显示，可切换多个窗口
form.Hide();     //隐藏窗体，对象还在内存，不释放
form.Close();    //关闭窗体，释放资源
Application.Exit(); //退出整个应用程序，全部窗口关闭
```

1. 窗体生命周期事件

   | 事件          | 触发时机                              | 用途                                   |
   | ------------- | ------------------------------------- | -------------------------------------- |
   | `Load`        | 窗体第一次显示**之前，仅执行一次**    | 初始化数据、加载配置；界面尚未渲染完成 |
   | `Shown`       | 窗体已经完整渲染显示出来              | 绘图、获取控件真实宽高                 |
   | `FormClosing` | 窗体正要关闭；`e.Cancel=true`阻止关闭 | 退出确认弹窗                           |
   | `FormClosed`  | 窗体已经关闭完毕                      | 资源释放、跳转其他窗体                 |
   | `Resize`      | 窗体大小改变                          | 做控件自适应布局                       |

> 重点区分：`Hide()`仅隐藏，不释放；`Close()`才释放窗体资源。

## 4、第三方UI库 AntdUI

1. NuGet包管理器搜索安装`AntdUI`；开源WinForm美化控件库。
2. 使用方式和原生控件几乎一致，提供美化输入框、按钮、表格等；适合快速做美观上位机界面。
3. 参考文档：官方gitee文档。

## 5、易错点

1. 二级联动切换一级下拉，**一定要先清空二级下拉Items**，否则旧数据残留。
2. 全选逻辑：半选`Indeterminate`状态，点击全选框的时候要跳过处理，避免反复覆盖子复选框。
3. `OfType<T>()`筛选容器内指定类型控件；遍历Controls不要直接强转，防止里面有其他类型控件报错。
4. `Load`事件界面还没渲染完成，不要做绘图、获取控件实际宽高；放到`Shown`。
5. `Hide()`不等于关闭；多次Show隐藏过的窗体，窗体对象还存在；Close之后窗体对象销毁，不能再次Show。

## 6、工业视觉上位机拓展

1. **二级联动**：选择相机型号，联动该型号支持的分辨率；选择工位联动检测方案。
2. 全选反选：缺陷记录勾选批量删除、批量导出报表。
3. 多窗体：主界面、参数配置弹窗、日志弹窗；`Show()`打开子窗口。
4. 坐标转换：PictureBox图像ROI拖拽，大量使用`PointToScreen / PointToClient`。
5. AntdUI：快速美化工控软件界面，替代原生丑陋控件。

## 📝面试问答

**Q1：CheckBox的CheckState三种状态分别是什么？全选场景半选状态什么时候出现？😃**

> A：`Checked`全部选中；`Unchecked`全部未选；`Indeterminate`半选，容器内**一部分子复选框勾选，一部分没有勾选**时。

**Q2：Hide()和Close()窗体区别？🤔**

> A：`Hide()`窗体只是隐藏，对象驻留内存，资源不释放，还可以再次Show；`Close()`销毁窗体对象，释放资源，关闭之后不能再调用Show。

**Q3：二级下拉联动实现思路？**

> A：①数据源使用parent_id维护父子关系；②一级下拉加载父数据；③绑定SelectedIndexChanged；选中父项拿到id，筛选对应子数据赋值给二级下拉框，赋值前清空二级下拉旧项。

**Q4：多个控件绑定同一个事件，sender怎么处理？**

> A：`sender as 控件类型`做类型转换，判空；通过控件Name区分不同控件，执行不同业务。

> 工业视觉补充：批量操作缺陷、批量勾选工位经常写全选反选逻辑；相机参数大量二级联动；弹窗子窗体用Show。

