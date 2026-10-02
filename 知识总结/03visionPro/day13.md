# day13｜VisionPro‑WinForm联合编程：相机硬件触发、4种集成模式、CogRecordDisplay显示控件 精简总结

> 重点：相机自动/半自动硬件触发；4套业务集成写法（自定义Acq对象、VisionPro编辑控件、VPP有无相机工具）；`CogRecordDisplay`专用视觉显示控件，原图/带标注图像保存。

## 一、相机硬件触发模式

### 1、Auto自动触发（产线常用）

```
Acq.OwnedTriggerParams.TriggerEnabled = true;
Acq.OwnedTriggerParams.TriggerModel = CogAcqTriggerModelConstants.Auto;
```

- 无需反复调用`StartAcquire()`；
- 硬件光电传感器每来一次触发信号，自动完成一次拍照，触发Complete回调。

### 2、Semi半自动触发

```
Acq.OwnedTriggerParams.TriggerEnabled = true;
Acq.OwnedTriggerParams.TriggerModel = CogAcqTriggerModelConstants.Semi;
```

- **每次拍照前必须调用StartAcquire()进入等待状态**；
- 收到一次硬件信号，拍一张，之后结束等待；下次拍照要再次`StartAcquire()`。

> 区别总结

- 自动Auto：开启后持续待命，外部信号来就拍，产线流水线首选。
- 半自动Semi：StartAcquire之后只响应一次外部触发，拍完结束。

## 二、四种VisionPro‑WinForm集成方案

> 前置：项目目标平台x64；引用VisionPro程序集；加载`.vpp(ToolBlock)`使用`CogSerializer.LoadObjectFromFile`。

### 方案1：VPP内部**无相机工具**，代码新建`ICogAcqFifo`相机对象

流程：

1. 代码创建`CogFrameGrabbers`获取相机，`CreateAcqFifo()`生成采集通道Acq；
2. 绑定`Acq.Complete`拍照完成回调；
3. 按钮调用`StartAcquire()`触发拍照；
4. Complete回调拿到`ICogImage`图像；赋值给ToolBlock输入图像；`CTB.Run()`运行算法；读取输出结果；
5. 图像转Bitmap交给PictureBox显示。

### 方案2：VPP内部**无相机工具**，使用VS工具箱VisionPro编辑控件`CogAcqFifoEditV21`

1. 窗体拖入`CogAcqFifoEditV21`控件；
2. `Acq = cogAcqFifoEditV21.Subject as CogAcqFifoTool`拿到工具实例；
3. 订阅`Acq.Ran`、`Operator.Complete`回调事件；
4. 触发采集，回调获取图像，送给ToolBlock执行算法。

### 方案3：VPP**内部自带CogAcqFifoTool相机工具**，代码外部创建Acq对象赋值给VPP内部相机

1. LoadObjectFromFile加载带相机的vpp；从CTB.Tools取出内部`InnerAcq`；
2. C#代码新建`ICogAcqFifo`采集实例；
3. `InnerAcq.Operator = Acq`，把外部相机对象赋值给VPP内部相机工具；
4. `StartAcquire()`触发拍照，调用`CTB.Run()`执行整套算法。

### 方案4：VPP自带相机工具，使用VisionPro编辑控件绑定Subject

1. 加载vpp，取出内部`CogAcqFifoTool`；
2. `cogAcqFifoEditV21.Subject = InnerAcq`把控件绑定vpp内部相机工具；
3. 订阅`Subject.Ran`事件，触发采集后直接执行ToolBlock。

> 关闭窗体示例中`Process.GetCurrentProcess().Kill()`仅教学演示；**正式项目禁止直接杀主进程，调用Dispose释放VisionPro资源**。

## 三、CogRecordDisplay⭐VisionPro专用显示控件

> 对比PictureBox：无需手动转Bitmap，原生支持VisionPro图像、图形标注叠加、ROI、实时流、保存带标注图片。

1. 显示原始视觉图像：

```
cogRecordDisplay1.Image = Img;
cogRecordDisplay1.Fit(); //图像自适应窗口
```

1. 开启相机实时预览：

```
cogRecordDisplay1.StartLiveDisplay(Acq, false);
cogRecordDisplay1.StopLiveDisplay(); //停止实时画面
```

1. 显示工具运行结果（包含绘制的标注、框、文字）

```
cogRecordDisplay1.Record = CTB.CreateLastRunRecord().SubRecords[0];
```

### 图像保存

1. 只保存原始像素图（**不带任何绘图标注**）

```
cogRecordDisplay1.Image.ToBitmap().Save(@"xxx.png");
```

1. 保存**带所有画框、文字标注**的结果图⭐工业报告输出

```
cogRecordDisplay1.CreateContentBitmap(CogDisplayContentBitmapConstants.Display).Save(@"xxx.jpg");
```

## 四、易错点

1. Auto自动硬件触发：**不要循环反复StartAcquire**，开启TriggerEnabled后硬件信号自动触发拍照。
2. Semi半自动：**每拍一张，都要重新调用StartAcquire()**等待外部信号。
3. `CogRecordDisplay.Image`放原始图像；`Record`放带算法绘图标注的运行记录。
4. `CreateContentBitmap()`才能把画框、文字标注一并保存到图片；直接ToBitmap()只存原图，标注丢失。
5. 示例代码`Process.Kill()`仅教学，正式项目调用工具对象Dispose()释放资源。

## 📝面试简答

**Q：Auto自动触发与Semi半自动硬件触发区别？😃**

> A：Auto自动触发，开启后持续待命，硬件信号来直接拍照，适合流水线产线；Semi半自动每次响应外部触发前都要调用StartAcquire，仅响应一次，拍完结束等待。

**Q：CogRecordDisplay保存图片，为什么保存出来没有画框标注？🤔**

> A：调用`Image.ToBitmap()`拿到原始图像，标注属于运行Record绘制层，不会包含；需要`CreateContentBitmap()`，把界面所有绘图标注渲染进位图再保存。

**Q：WinForm集成VisionPro有哪几类VPP相机集成方式？**

> A：①VPP无相机，代码新建Acq采集；②VPP无相机，使用VisionPro编辑控件；③VPP自带相机，外部代码Acq赋值给VPP内部工具；④VPP自带相机，编辑控件绑定VPP内部Subject。

