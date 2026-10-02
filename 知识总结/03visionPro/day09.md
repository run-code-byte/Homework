# day09｜VisionPro VS联合调试、图像拼接、PostAcquisitionRefInfo采集后回调、相机硬件接线 精简总结

> 重点：VS附加进程调试VisionPro脚本；`CogCopyRegionTool`图像拼接；采集后回调`PostAcquisitionRefInfo`；工业相机、光电传感器、光源硬件接线。

## 一、VS联合调试VisionPro脚本

> 用途：打断点、单步调试VisionPro内部C#高级脚本，排查脚本逻辑bug。 操作步骤：

1. 新建VS空桌面项目，删除入口窗体启动代码。
2. 修改`.csproj`项目配置：指定`StartAction`，设置`StartProgram`为VisionPro程序路径。
3. 保存重新加载项目；启动VisionPro并打开作业vpp。
4. VS菜单：调试 → **重新附加到进程**，选择VisionPro进程。
5. VisionPro脚本切换到【调试】模式，取消注释断点调试代码，生成。
6. 运行VisionPro工具块，自动跳入VS断点，单步调试脚本。

## 二、CogCopyRegionTool 图像复制/图像拼接

1. 工具作用：复制图像指定区域，粘贴到另一张目标图像指定位置；用于**多张局部小图拼成一张大图**（零件太大相机视野装不下，分多次拍摄拼接）。
2. 关键参数
   - `DestinationImage`：目标画布图像，需要预先`Allocate()`分配宽高内存；
   - `DestinationImageAlignmentX/Y`：粘贴到目标图的坐标；
   - `ImageAlignmentEnabled`：开启图像对齐。

## 三、PostAcquisitionRefInfo 采集后回调脚本⭐相机采集流程回调

> 回调函数：**一张图像相机采集完成之后立刻执行**。

```
public override bool PostAcquisitionRefInfo(ref ICogImage image, ICogAcqInfo info)
```

- `return true`：将当前采集图像送入后续工具，执行定位、测量、缺陷检测；
- `return false`：**跳过本次图像检测，不运行算法，直接触发下一次相机拍照采集**。

### 图像拼接实战脚本思路

1. 定义全局计数器、`CogCopyRegionTool`工具对象。
2. count=1：创建空白大目标画布，分配2倍宽高；
3. count=2/3/4：修改粘贴对齐X/Y坐标，把每一张采集图贴到大画布不同位置；
4. count等于4（4张全部采集粘贴完毕）：把拼接完成的大图赋值给`image`，`return true`，送入算法检测；计数器归零；
5. 未集齐全部图片：`return false`，不检测，继续拍取下一张。

> 业务场景：分4次采集图像，在回调脚本完成拼接，拼接完成才跑视觉检测逻辑。

## 四、工业视觉项目完整工作流程

1. 需求沟通，硬件选型（相机、镜头、光源），评估方案可行性。
2. 设备采购，电气搭建硬件环境，视觉负责相机相关调试。
3. 使用客户真实OK/NG零件，现场拍摄图片，开发VisionPro算法程序。
4. 部署到产线现场，使用实物测试验证。
5. 测试通过，正式上线投入生产。

## 五、硬件接线（相机、光电传感器、光源）

### 线材颜色定义

1. 相机线缆
   - PWR_DC橙色：电源正极
   - 灰色、绿色：电源负极GND
   - 黄色：输入信号线（接收外部触发信号）
2. 光电感应器
   - 棕色：正极；蓝色：负极GND；黑色：输出信号线
3. 电源适配器
   - 数字标识黑线：正极；斑马纹黑线：负极
4. 电源绿色插头
   - TR2：信号接收；COM：负极公共端

### 接线规则

- **所有正极接在一起；所有负极GND接在一起；信号线按功能对接。**
- 接线完成：相机指示灯点亮，可程序控制光源开关。

## 六、课后作业

1. 齿轮缺齿检测；
2. 6张骰子图像拼接，拼接完成统计骰子点数；
3. 图像拼接练习。

## 七、易错点

1. `PostAcquisitionRefInfo`返回`false`代表跳过本次图像检测，直接继续采集下一张，**不会执行后续任何检测工具**。
2. 图像拼接，目标`DestinationImage`必须预先`Allocate(宽,高)`分配内存，否则粘贴报错。
3. VS调试VisionPro必须【附加到进程】，不是直接启动VS项目。
4. 硬件接线：共地！所有设备GND负极接在一起，否则触发信号不稳定。

## 📝面试简答

**Q：PostAcquisitionRefInfo回调返回true和false区别？😃**

> A：`return true`：采集到的图像交给后面视觉工具执行检测；`return false`：放弃当前图片，跳过检测，相机直接采集下一张图像。

**Q：CogCopyRegionTool图像拼接，目标图像要做什么操作？🤔**

> A：需要提前调用`Allocate(宽度,高度)`，预先分配目标画布内存，多张小图依次粘贴到此画布。

**Q：VS如何调试VisionPro高级脚本？**

> A：修改csproj配置，VS附加到VisionPro进程；脚本切换调试模式，运行工具块触发断点，单步调试。

**Q：工业硬件接线为什么所有设备GND要接在一起？**

> A：共地，保证电平信号参考基准一致，避免光电触发信号不稳定、乱触发。

> 需要的话，我可以把VisionPro day01‑day09全部汇总为完整背诵文档。