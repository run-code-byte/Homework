# day12｜WinForm‑GDI+绘图、双缓冲消除闪烁 结构化总结

> 重点：Paint事件绘图机制、Pen画笔/Brush画刷、各类图形绘制、颜色透明、双缓冲自定义Panel消除闪烁、定时器+Invalidate动画；工业视觉用于画ROI感兴趣区域、标记缺陷框、表盘刻度。

## 1、GDI+绘图核心规则

1. **绘图代码必须写在控件的Paint事件内部**，参数`PaintEventArgs e`。
2. 通过`e.Graphics`拿到画布对象；**不要把Graphics保存成类全局变量**，窗体重绘会失效。
3. 坐标原点：控件左上角`(0,0)`，X向右增大，Y向下增大。
4. `g.SmoothingMode = SmoothingMode.AntiAlias`；开启**抗锯齿**，线条、圆弧边缘平滑。
5. `Pen`、`Brush`、`Font`属于非托管资源，**必须用using包裹自动释放，避免内存泄漏**。
6. 需要刷新重绘图形：调用`控件.Invalidate()`，触发`Paint`事件，不要直接手动调用Paint方法。

> ❌不推荐：`CreateGraphics()`，最小化、遮挡之后图形直接消失，只适合临时调试。

## 2、常用绘图API

### 画笔Pen（画空心轮廓：线、矩形、椭圆、多边形）

- `new Pen(颜色,宽度)`

| 方法                                    | 作用                          |
| --------------------------------------- | ----------------------------- |
| `g.DrawRectangle(pen,x,y,w,h)`          | 空心矩形                      |
| `g.DrawEllipse(pen,x,y,w,h)`            | 空心椭圆；宽高相等=圆形       |
| `g.DrawLine(pen,x1,y1,x2,y2)`           | 直线                          |
| `g.DrawPolygon(pen,Point[] pts)`        | 空心多边形，ROI四边形、三角形 |
| `g.DrawArc(pen,rect,起始角度,扫过角度)` | 圆弧、表盘刻度                |

### 画刷Brush（填充实心图形）

- `SolidBrush(Color.FromArgb(透明度,R,G,B))`，透明度0‑255，0完全透明，255不透明。

| 方法                | 作用            |
| ------------------- | --------------- |
| `g.FillRectangle()` | 填充实心矩形    |
| `g.FillEllipse()`   | 填充实心圆/椭圆 |
| `g.FillPolygon()`   | 填充实心多边形  |

### 绘制文字

```
using(Font font=new Font("微软雅黑",12))
using(Brush br=new SolidBrush(Color.Black))
using(StringFormat sf=new StringFormat())
{
    sf.Alignment=StringAlignment.Center;       //水平居中
    sf.LineAlignment=StringAlignment.Center;   //垂直居中
    g.DrawString("测试文本",font,br,x,y,sf);
}
```

### 颜色透明

`Color.FromArgb(Alpha,R,G,B)`，Alpha透明度：0完全透明，255不透明。

## 3、双缓冲消除画面闪烁⭐工业高频

> 频繁定时器刷新绘图会出现闪烁：默认先把画布背景抹白，再绘制图形，中间过程人眼可见。

### 自定义双缓冲Panel

```
public class DoubleBufferPanel : Panel
{
    public DoubleBufferPanel()
    {
        SetStyle(
            ControlStyles.UserPaint
            |ControlStyles.AllPaintingInWmPaint
            |ControlStyles.OptimizedDoubleBuffer,true);
        UpdateStyles();
    }
}
```

原理：全部绘制操作在**内存画布完成**，绘制结束一次性拷贝到屏幕，消除中间闪烁。 使用：设计器或者代码把普通`Panel`替换为`DoubleBufferPanel`。 动画更新图形：`panel.Invalidate()`触发Paint重绘。

## 4、动画实现流程（钟表/表盘案例）

1. 使用`System.Windows.Forms.Timer`定时器；`Tick`周期更新业务数据（秒数、角度）。
2. 定时器内部执行`panel.Invalidate()`，触发`Paint`事件。
3. Paint事件读取最新数据，完成全部绘图逻辑；**绘图逻辑只写在Paint里面，数据放在类字段保存**。

> 案例：钟表表盘、半圆温度仪表盘，三角函数`Math.Cos / Math.Sin`根据角度换算XY坐标绘制刻度、指针。

## 5、易错点

1. Pen、Brush、Font必须`using`释放，否则内存泄漏；`e.Graphics`系统自动管理，不要Dispose。
2. 绘图逻辑只写Paint事件；图形变化调用`Invalidate()`，禁止手动调用Paint。
3. 不要保存`e.Graphics`为全局变量；窗体重绘之后该对象失效，图形消失。
4. 频繁刷新绘图一定要开启双缓冲，否则画面严重闪烁。
5. 三角函数角度：**角度转弧度 角度\*Math.PI/180**，GDI+角度0度指向X轴向右，顺时针增加。
6. 不要用`CreateGraphics()`做持久绘图；窗口遮挡、最小化之后绘制内容直接消失。

## 6、工业视觉上位机拓展

1. GDI+在PictureBox / Panel绘制缺陷框、ROI感兴趣区域、标记点；矩形、多边形、文字标注检测结果。
2. 仪表盘UI，用DrawArc、三角函数绘制刻度指针。
3. 定时器+Invalidate实时刷新：实时展示相机点位、运动位置。
4. 透明度`FromArgb`画半透明缺陷覆盖层。

## 📝面试问答（对话式✨）

**Q1：GDI+绘图，为什么绘图代码要写在Paint事件？😃**

> A：窗体重绘（窗口移动、遮挡、最小化恢复）系统会自动触发Paint；如果写在别的地方，窗体重绘图形直接丢失。图形更新调用`Invalidate()`触发重绘。

**Q2：Pen、Brush为什么要用using？🤔**

> A：属于GDI+非托管资源，不释放会内存泄漏；using代码块结束自动Dispose释放资源。

**Q3：绘图画面闪烁怎么解决？原理是什么？**

> A：自定义双缓冲Panel，开启`OptimizedDoubleBuffer`；所有绘图先在内存画布完成，绘制完毕一次性拷贝屏幕，避免中间擦除背景的闪烁效果。

**Q4：Invalidate()的作用？能不能直接调用Paint？**

> A：`Invalidate()`标记控件需要重绘，系统消息循环调度执行Paint事件。**禁止直接调用Paint方法**，会破坏窗口消息机制。

**Q5：CreateGraphics()有什么坑？**

> A：直接绘制到屏幕，窗口遮挡、最小化之后绘制的内容消失，不适合业务持久绘图，仅临时调试。

> 工业视觉补充：视觉软件标记缺陷框、ROI区域大量使用GDI+的DrawRectangle、DrawPolygon。

如果你需要，我可以把 day01‑day12 WinForm全套合并成完整背诵复习文档。