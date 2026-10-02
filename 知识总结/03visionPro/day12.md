# day12｜WinForm集成VisionPro GigE相机、ToolBlock业务方案、VisionPro窗体控件 精简总结

> 重点：VS项目x64目标平台；`CogFrameGrabbers`枚举相机；`ICogAcqFifo`采集通道、Complete拍照回调；图像转Bitmap显示；加载vpp‑ToolBlock完成识别；WinForm工具箱导入VisionPro原生控件。

## 一、项目前置配置

1. 项目引用VisionPro全部程序集；
2. **项目属性‑生成‑目标平台必须改为 x64**，VisionPro库不支持AnyCPU/x86；
3. 注意：不要多余引入`Cognex.VisionPro.Interop`命名空间，会报异常。

## 二、WinForm调用GigE相机核心对象

1. `CogFrameGrabbers`：获取本机全部相机设备集合。

2. `ICogFrameGrabber`：单个相机对象，从集合按下标取。

3. ```
   ICogAcqFifo
   ```

   采集FIFO通道

   - `CreateAcqFifo(视频格式,像素格式,端口,自动准备)` 创建采集通道；
   - 设置曝光：`Acq.OwnedExposureParams.Exposure = 5.5`（浮点）；
   - `Acq.Complete`事件：**拍照完成回调事件**；
   - `StartAcquire()`：触发一次拍照；
   - `CompleteAcquireEx()`：取采集完成的`ICogImage`视觉图像对象。

4. `GetFifoState(out 等待数, out 就绪数, out busy)`，判断是否有已经拍完的图像。

### 图像格式转换

> VisionPro内部`ICogImage`不能直接给PictureBox显示。

1. `CogImageConvertTool`做图像转换；
2. `.ToBitmap()`方法转为`System.Drawing.Bitmap`，赋值给PictureBox。

## 三、完整业务流程：相机拍照 + 加载VPP‑ToolBlock识别

1. 提前在VisionPro QuickBuild调试算法，导出**ToolBlock的vpp文件**，放到程序输出目录。
2. `CogSerializer.LoadObjectFromFile()`加载vpp，强转为`CogToolBlock`。
3. 窗体关闭注意：`CTB.Dispose()`释放工具资源；VisionPro存在后台残留进程，示例用`Process.Kill()`强行退出（仅演示，正式项目谨慎使用）。
4. 点击按钮：获取相机，创建Acq采集通道，绑定Complete事件，调用`StartAcquire()`触发拍照。
5. Complete回调：拿到`ICogImage`，转Bitmap显示界面；把图像赋值给ToolBlock输入端口；调用`CTB.Run()`执行视觉算法；读取Outputs输出识别结果展示Label。

核心片段

```
CogFrameGrabbers Grabbers = new CogFrameGrabbers();
ICogFrameGrabber Grabber = Grabbers[0];
ICogAcqFifo Acq = Grabber.CreateAcqFifo("Generic GigEVision (Mono)",
    CogAcqFifoPixelFormatConstants.Format8Grey,0,true);
Acq.OwnedExposureParams.Exposure = 5.5;
Acq.Complete += Acq_Complete;
Acq.StartAcquire();
```

回调内部：

```
ICogImage Img = Acq.CompleteAcquireEx(new CogAcqInfo());
CogImageConvertTool CICT = new CogImageConvertTool();
CICT.InputImage = Img;
CICT.Run();
Bitmap bm = CICT.OutputImage.ToBitmap();
pictureBox1.Image = bm;
CTB.Inputs["OutputImage"].Value = Img;
CTB.Run();
label2.Text = CTB.Outputs["Count"].Value.ToString();
```

## 四、WinForm使用VisionPro原生控件

1. VS工具箱新建选项卡；
2. 从VisionPro安装目录`ReferencedAssemblies`，拖拽dll到选项卡，生成视觉控件；
3. 把控件拖入窗体；设置`控件.Subject = 对应工具实例`，实现控件与Acq/工具实例联动，界面可以直接像QuickBuild一样操作视觉工具。

## 五、易错点

1. ⚠️目标平台必须x64，否则VisionPro库直接报错无法运行。
2. 不要多余using`Cognex.VisionPro.Interop`，容易引发异常。
3. `ICogImage`不能直接在PictureBox显示，必须转Bitmap。
4. Complete是回调事件，图像获取写在事件内部，不要写在StartAcquire之后同步位置。
5. `Process.GetCurrentProcess().Kill()`是演示方案，正式上位机不能直接杀主进程，要规范Dispose释放VisionPro资源。

## 📝面试简答

**Q：WinForm调用VisionPro相机，目标平台为什么要设置x64？😃**

> A：VisionPro提供的托管库全部为64位，不支持x86/AnyCPU，不修改会加载失败。

**Q：ICogImage为什么不能直接赋值给PictureBox？🤔**

> A：`ICogImage`是VisionPro内部图像对象，不是.NET标准Bitmap；需要调用`ToBitmap()`转换成System.Drawing.Bitmap。

**Q：ICogAcqFifo的Complete事件作用？**

> A：相机图像采集完成之后触发的回调，在这里获取图像、执行视觉算法。

> 可以把 day01‑day12 VisionPro全部合并为完整背诵总文档。