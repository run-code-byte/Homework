# day01｜VisionPro康耐视机器视觉 精简总结

> 工业视觉Cognex VisionPro，9.x/10.x版本；QuickBuild拖拽开发 + C#.NET‑API二次开发；与WinForm上位机联合开发。

## 一、VisionPro基础介绍

1. **两套开发模式**

- QuickBuild：图形化拖拽搭积木，快速调试验证视觉流程；
- C# .NET API二次开发：导出vpp工具块，嵌入WinForm/WPF上位机，对接PLC、机器人、MES、数据库，工业项目最终交付主流方案。
- 可选深度学习模块VisionPro DeepLearning（ViDi），处理传统算法难以搞定的复杂缺陷。

1. **核心能力**

- **定位引导**：PatMax模板匹配，工件旋转、遮挡、光照变化下输出X/Y坐标、角度，给机械手抓取/点胶；
- **测量**：卡尺、圆拟合实现亚像素测量孔径、间隙、角度，对比公差；
- **缺陷检测**：划痕、溢胶、缺料、脏污，输出OK/NG，流水线剔除不良；
- **识别追溯**：一维码、二维码、OCR字符识别，对接MES追溯产品。

1. **主流视觉软件横向对比**

| 软件         | 厂商         | 优点                                                         | 缺点                                                         | 适用场景                                         |
| ------------ | ------------ | ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------------------ |
| VisionPro    | 康耐视Cognex | PatMax定位极强；.NET C#友好；Fixture坐标系；产线稳定性高；拖拽+代码双模式；正版授权贵；加密狗部署成本高 | 中文资料少                                                   | 汽车、半导体、医疗；C#上位机一体化、高稳定性项目 |
| Halcon       | MVTec德国    | 算子极丰富；3D视觉强；运行版成本低                           | HDevelop自成语法，C#集成需要封装                             | 深度算法开发、复杂3D测量项目                     |
| VisionMaster | 海康国产     | 全中文、上手快、价格低，国产硬件打通                         | 复杂AI缺陷能力偏弱                                           | 国内中小型2D项目，预算有限                       |
| OpenCV       | 开源免费     | 免费，适合学习底层原理                                       | **无工业工程化封装**，无PatMax，IO/PLC全部自己写，产线落地风险高 | 学习算法、科研原型，不直接产线交付               |

> 选型口诀： 学底层原理→OpenCV；复杂3D测量→Halcon；C#上位机+高端制造→VisionPro；国内预算有限快速落地→海康VisionMaster。

1. 算法选型：

- 特征固定（圆孔、边角）：PatMax、Blob、卡尺，传统算法速度快可控；
- 形变、纹理杂乱、缺陷无固定形状：深度学习AI训练样本。

## 二、软件安装与DPI缩放问题

1. 安装前关闭杀毒；安装完成重启电脑。
2. **高分屏界面错乱**：右键程序图标→属性→兼容性→更改高DPI设置，替代高DPI缩放，修复界面显示异常。

## 三、QuickBuild程序架构

```
程序(Application)` → 多个`Job作业` → Job内部多个`工具Tool
```

- 程序、Job、单个工具均可保存为`.vpp`文件，C#代码加载调用；
- `Image Source`图像源：本地图片 / 相机实时采集图像。

## 四、常用工具大类

1. **定位模板类**：PatMax（CogPMAlignTool）模板匹配；Blob斑点分析。
2. **标定坐标系**：棋盘格标定、N点标定、Fixture工具（动态坐标系，定位后把后续工具切换到工件局部坐标系）。
3. **颜色工具**：颜色提取、颜色分割、颜色匹配，处理彩色图像。
4. **几何工具**：创建点/线/圆/椭圆；查找、拟合；相交；距离、夹角测量。
5. **识别验证**：CogIdTool读码、CogOCRMax字符识别、OCV字符校验。
6. **图像处理**：灰度转换、阈值、滤波、边缘Sobel、图像加减、ROI复制、直方图统计。

### PatMax（CogPMAlignTool）模板匹配⭐重点

> 基于边缘轮廓特征，**不依赖像素灰度**，抗光照、旋转、缩放。

- 三种算法模式
  - `PatMax`：精度高，2D平面工件首选；
  - `PatQuick`：速度更快，适合低质量图像；
  - `PatFlex`：适合弯曲形变物体，精度下降。

1. 工作流程：加载训练图 → 绘制模板ROI，设置模板原点 → 设置查找参数（角度范围、缩放、接受阈值、最大查找个数） → **训练模板**。
2. 注意：**PMAlign接收灰度图像；彩色图前面要加灰度转换工具**。
3. **掩膜Mask**：训练时屏蔽模板内部干扰纹理、条纹，被掩膜区域不参与特征匹配。
4. **建模器**：自动提取不规则轮廓，省去手动画ROI。
5. 输出结果：匹配分数、X/Y坐标、旋转角度。

## 五、Blob斑点分析 CogBlobTool⭐高频

> 基于灰度阈值分割，识别连通像素区域；获取斑点数量、位置、面积、长宽、方向。

1. 典型用途：圆孔计数、焊点、瑕疵检测、颗粒统计。
2. 处理流水线：**图像分割 → 连通性分析 → 形态学操作 → 特征过滤 → 输出结果**。
3. 四种分割阈值模式
   - 硬‑固定阈值：固定灰度分割；
   - 硬‑相对阈值：适合光照变化场景，按灰度百分比；
   - 硬‑动态阈值：图像直方图自动计算阈值；
   - 软阈值：区间过渡，区分边界过渡像素。
4. 特征过滤：按面积、长宽、圆度等过滤，保留目标斑点，过滤噪声干扰；可多级Blob串联多次过滤。

## 六、WinForm C#集成VisionPro（加载vpp方案）

1. QuickBuild把Job/工具块导出为`.vpp`文件；
2. VS项目添加引用：VisionPro安装目录`ReferencedAssemblies`下全部Cognex类库dll；
3. 把vpp文件放到程序输出目录；
4. 核心代码流程：
   1. `CogImageFileTool`读取图片，转为VisionPro内部图像对象；
   2. `CogSerializer.LoadObjectFromFile()`加载vpp方案，强转为`CogToolBlock`；
   3. 给ToolBlock输入端口赋值图像；
   4. 调用`DTB.Run()`执行视觉方案；
   5. 读取`DTB.Outputs["输出名"].Value`拿到视觉结果（数量、坐标、角度等）。

```
CogImageFileTool CIFT = new CogImageFileTool();
CIFT.Operator.Open(filePath, CogImageFileModeConstants.Read);
CIFT.Run();
//加载vpp
string vppPath = Path.Combine(Directory.GetCurrentDirectory(),"vpps","xxx.vpp");
CogToolBlock tb = (CogToolBlock)CogSerializer.LoadObjectFromFile(vppPath);
tb.Inputs["OutputImage"].Value = CIFT.OutputImage;
tb.Run();
var res = tb.Outputs["Results_Count"].Value;
```

## 七、易错点

1. PatMax(PMA)输入需要灰度图，彩色图像必须先灰度转换；
2. 高分屏运行QuickBuild界面错乱，修改程序兼容性DPI缩放；
3. vpp路径注意相对路径，发布后路径找不到视觉方案；
4. Blob分割选对阈值模式；光照波动优先使用相对阈值；
5. 掩膜Mask用于屏蔽模板内部干扰纹理；建模器自动提取不规则模板轮廓。

## 八、工业视觉拓展

1. Fixture工具：工件定位成功后，动态更新坐标系，后续测量工具自动跟随工件旋转偏移；
2. 上位机流程：相机采集图像 → C#传入vpp工具块 → PatMax定位 → Blob/卡尺测量 → 结果输出给PLC；
3. 传统算法解决不了多变缺陷，启用VisionPro DeepLearning深度学习模块。

## 📝面试简答

**Q1 PatMax算法特点？😃**

> A：基于边缘轮廓特征，不依赖像素灰度；抗光照、旋转、部分遮挡；输出坐标角度；需要灰度图像。有PatMax高精度、PatQuick高速、PatFlex形变模式。

**Q2 Blob斑点分析一般步骤？🤔**

> A：图像阈值分割 → 连通区域分析 → 形态学处理 → 按面积/圆度等特征过滤 → 获取斑点数量、位置、面积等结果；适合颗粒、圆孔、焊点检测。

**Q3 VisionPro C#二次开发流程？**

> A：QuickBuild调试视觉流程导出vpp；VS添加Cognex引用；CogSerializer加载vpp，给输入端口传入图像，Run执行，读取Outputs输出视觉结果。

**Q4掩膜Mask作用？**

> A：模板训练时屏蔽ROI内部干扰纹理，被mask区域不参与特征匹配，消除内部条纹、图案干扰。

> 如果你需要，我可以把 day01‑day17 WinForm全套 + day01 VisionPro合并成一份超级总复习文档。