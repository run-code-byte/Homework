# day01｜WinForm 桌面开发知识结构化总结

> 适用：工业视觉上位机WinForm开发，VS控制台之后GUI桌面入门。

## 一、WinForm基础概念

1. **WinForm全称**：Windows Form，.NET平台Windows桌面GUI技术，C#开发，只能运行于Windows系统。
2. **特点**：可视化拖拽控件开发；控件事件驱动；访问本地文件、串口、USB硬件友好；对Win7老旧工控机兼容性好。
3. 开发流程
   1. VS新建【Windows窗体应用】项目
   2. 设计器拖拽控件，设置控件属性、绑定事件
   3. 在`Form1.cs`编写业务事件代码
   4. 调试运行测试程序

### ✨主流应用场景（工业上位机重点）

1. **工厂产线上位机**：对接PLC、视觉相机、扫码枪；3C/半导体流水线检测；MES车间客户端；WMS仓库系统。
2. **硬件调试工具**：VisionPro/Halcon视觉调试软件；串口/TCP‑PLC调试助手；传感器、温控仪器数据展示。
3. **内部运维小工具**：日志分析、批量文件处理、Excel导入导出、配置编辑器。
4. **单机进销存、收银软件；教学模拟仿真；老政务内网存量维护项目**。

### ✅适合 / ❌不适合使用WinForm

| 适合WinForm场景                        | 不适合WinForm场景            |
| -------------------------------------- | ---------------------------- |
| 只部署Windows，工厂内网、工控机Win7    | 需要跨平台 Windows/Mac/Linux |
| 对接串口、相机、PLC各类硬件            | 面向互联网大众用户、移动端   |
| 优先稳定，界面不用华丽炫酷             | 高度自定义动画、复杂UI效果   |
| 大量表格DataGridView、打印、Office交互 | 手机平板移动端软件           |

### 📌同类技术简单对比

- **WPF**：Direct渲染，UI高度自定义；学习成本更高
- **MAUI**：.NET新一代跨平台，长期替代WinForm/WPF
- **AvaloniaUI**：跨平台桌面Windows/Linux/Mac
- **Electron**：前端写桌面（VSCode/钉钉），内存占用大

## 二、WinForm项目文件结构

| 文件                | 作用                                                         |
| ------------------- | ------------------------------------------------------------ |
| `Program.cs`        | 程序入口，`[STAThread]`，`Application.Run(new Form1())`启动主窗体 |
| `Form1.cs`          | 分部类`partial class Form1:Form`，**自己写业务、事件处理代码** |
| `Form1.Designer.cs` | 设计器自动生成；控件实例化、属性、布局；**不要手动修改**     |

> `partial` 分部类：同一个类拆分多个cs文件，编译合并为完整类；WinForm窗体依靠partial拆分业务代码和自动生成布局代码。

### Program.cs核心入口代码

```
internal static class Program
{
    [STAThread] //UI线程标记，WinForm必须
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1()); //启动主窗体
    }
}
```

### Form窗体类

```
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent(); //Designer里面自动生成，初始化所有控件布局
    }
}
```

> `InitializeComponent()`：实例所有控件，设置Location、Size、Text、颜色，把控件加入窗体`Controls`集合。

## 三、基础常用控件

> 控件：界面积木；Form是根容器；控件可以通过【工具箱】拖拽，也可以完全C#代码动态new创建。

| 控件             | 名称           | 核心常用属性                                                 |
| ---------------- | -------------- | ------------------------------------------------------------ |
| `Button`         | 按钮           | `Text`显示文字；`Name`变量名；`Location`位置；`Size`大小；`BackColor`背景色；`ForeColor`文字颜色；`Visible`显示隐藏 |
| `Label`          | 标签静态文本   | `Text`；`AutoSize`自动适配文字大小；`BorderStyle`边框样式    |
| `TextBox`        | 文本输入框     | `Text`内容；`Multiline`多行；`ReadOnly`只读；`PasswordChar`密码掩码；`PlaceholderText`提示文字 |
| `CheckBox`       | 复选框多选     | `Text`；`Checked`是否勾选；`ThreeState`三态                  |
| `RadioButton`    | 单选框         | `Text`；`Checked`；**同一个容器内自动互斥**                  |
| `ComboBox`       | 下拉框         | `Items`选项集合；`Text`；`DropDownStyle`模式（可编辑/只读下拉） |
| `DateTimePicker` | 日期时间选择器 | `Value`选中时间；`Format`时间格式                            |
| `ListBox`        | 列表框         | `Items`；`SelectionMode`单选/多选模式                        |
| `RichTextBox`    | 富文本框       | 支持不同字体颜色排版；`ReadOnly`只读                         |
| `PictureBox`     | 图片框         | `Image`图片对象；`SizeMode`图片缩放模式                      |

> PictureBox的SizeMode
>
> - `Zoom`：按比例缩放，不变形完整显示图片（上位机视觉看图最常用）
> - `StretchImage`：拉伸会变形
> - `AutoSize`：控件跟随图片大小
> - `CenterImage`：原图居中，超出裁剪

## 四、容器控件（控件嵌套分组）

> 容器可以存放其他控件；Form本身就是根容器；分为简单容器、布局容器。 重点两个布局属性：
>
> 1. **Dock**：贴靠父容器边缘，Dock优先级高于Anchor。
> 2. **Anchor锚点**：绑定父容器四边；窗体缩放时，控件跟随拉伸/移动。

### ①简单容器（不会自动排列子控件，子控件依靠Location/Dock/Anchor）

1. Form 窗体（根容器）
   - `Text`窗体标题；`StartPosition`窗体启动位置：`CenterScreen`屏幕居中；`CenterParent`子窗口父窗体居中；
   - `MaximizeBox` / `MinimizeBox`是否显示最大化最小化按钮。
2. **Panel面板**：无边框，分组控件；`AutoScroll=true`内容超出出现滚动条。
3. **GroupBox**：带标题、边框，视觉分组。
4. **TabControl选项卡**：多标签页切换；`TabPages`标签集合。

### ②布局容器（接管子控件位置，子控件Location基本失效）

1. **FlowLayoutPanel流式布局**：子控件自动水平/垂直排列，空间不足自动换行；子控件`Anchor、Dock`失效。
2. **TableLayoutPanel表格布局**：网格单元格布局；支持行列百分比、像素、自动尺寸；单元格要放多个控件，必须嵌套Panel。
3. **SplitContainer分割容器**：可拖动分割条，分成Panel1、Panel2；`SplitterDistance`分割条位置；可设置面板最小大小、折叠面板。

> 💡开发实战技巧：容器**大量嵌套组合**。例：外层SplitContainer →左侧TreeView；右侧TabControl；TabPage内部TableLayoutPanel做表单。

## 五、易错点

1. `Form1.Designer.cs`是自动生成，禁止手动修改；改控件使用设计器或者在Form1.cs业务代码操作。
2. `Dock`优先级高于`Anchor`，设置Dock后Anchor会被忽略。
3. `FlowLayoutPanel / TableLayoutPanel`布局容器，子控件Location基本无效，由容器规则管理。
4. RadioButton单选互斥范围**仅限于同一个容器**；想要多组单选，要放到不同Panel/GroupBox里面。
5. PictureBox看图优先使用`SizeMode.Zoom`，防止图片拉伸变形（视觉上位机看图高频）。
6. `[STAThread]`特性不能去掉，WinForm UI程序必须。

## 六、拓展（工业视觉上位机）

1. 硬件调试界面大量使用`Panel、GroupBox`做功能模块分组；
2. 参数表单大量用`TableLayoutPanel`整齐排布标签、输入框；
3. `SplitContainer`分割：左侧参数，右侧图像显示（PictureBox）；
4. PictureBox的Zoom模式用于相机图像预览；
5. TabControl分页：【参数设置】、【图像检测】、【日志】分开；
6. Anchor/Dock合理设置，窗体拉大缩小，控件自适应窗体。

## 📝面试问答

**Q1：WinForm项目中partial分部类的作用？😃**

> A：把一个窗体类拆分成两个文件，`Form1.cs`写自己业务代码；`Form1.Designer.cs`存放设计器自动生成控件布局代码，编译合并成完整类，互不干扰。

**Q2：Dock与Anchor区别，优先级？🤔**

> A：Dock把控件贴靠父容器四边；Anchor锚定父容器边缘，窗体缩放控件跟随拉伸。**Dock优先级高于Anchor，设置Dock，Anchor就失效。**

**Q3：RadioButton怎么实现多组互斥单选？**

> A：同一个容器内RadioButton自动互斥；多组就要分别放到不同Panel或者GroupBox容器。

**Q4：PictureBox显示图片SizeMode Zoom作用？工业视觉看图为什么选Zoom？**

> A：Zoom将图片按比例缩放完整放进控件，**不会拉伸变形**；相机图像预览，保证图像不变形完整显示。

**Q5：WinForm适合什么项目？什么场景不适合？**

> A：适合Windows内网工控上位机，对接PLC、相机硬件，追求稳定；不适合跨平台、移动端、互联网面向大众软件。

> 工业视觉补充：实际上位机界面经常嵌套多层容器；SplitContainer+TableLayoutPanel+TabControl组合完成整套界面布局。

