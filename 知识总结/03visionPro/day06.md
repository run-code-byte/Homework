# day06｜VisionPro高级脚本CogToolBlock、自定义绘图、SearchMax工具 精简总结

> 重点：CogToolBlock高级脚本`GroupRun`、`ModifyLastRunRecord`；手动控制工具执行流程；代码创建各类图形叠加标注；SearchMax纹理模板匹配，与PMA对比。

## 一、上节回顾

1. OCVMax字体验证，校验印刷字符是否合格；OCRMax做文字识别。
2. CogIDTool：一维、二维码识别，切换码制参数。
3. 形态学：腐蚀、膨胀、开运算、闭运算；注意图像极性。
4. 预处理工具：直方图统计灰度、Sobel边缘提取、IPOneImage全能预处理；**IPTwoImageSubtract两张图像相减做缺陷检测**。

## 二、CogToolBlock高级脚本⭐工业重点

### 两个核心重写方法

1. **GroupRun**：Block每次运行最先执行

   - `return true`：交给VisionPro自动按顺序运行Block内部所有工具，脚本仅做前置逻辑。
   - `return false`：**关闭自动执行，脚本手动调用RunTool()控制工具执行顺序、条件分支**。
   - 获取/设置：`mToolBlock.Tools["工具名"]`获取工具实例；`Inputs["xxx"].Value`读输入；`Outputs["xxx"].Value`写输出。

   ```
   //手动运行工具
   mToolBlock.RunTool(mToolBlock.Tools["CogBlobTool1"],ref message,ref result);
   ```

2. ModifyLastRunRecord

   ：

   全部工具运行完毕、生成运行记录之后执行

   。

   - ✅唯一正确位置：在这里调用`AddGraphicToRunRecord()`，把脚本生成的图形（线、圆、文本）叠加到图像显示窗口。
   - 用途：自定义绘制标注，在图片上画框、文字、箭头。

### 脚本可创建的绘图对象

| 对象                 | 作用                          |
| -------------------- | ----------------------------- |
| `CogLineSegment`     | 线段，支持两端箭头            |
| `CogRectangle`       | 普通矩形                      |
| `CogRectangleAffine` | 旋转仿射矩形（PatMax匹配框）  |
| `CogCircle`          | 圆形                          |
| `CogPolygon`         | 多边形，可绘制Blob轮廓        |
| `CogGraphicLabel`    | 文本标签，显示数值、OK‑NG文字 |

> 使用套路：`GroupRun`循环业务逻辑，创建图形对象存到List集合；`ModifyLastRunRecord`遍历集合，统一添加到运行记录完成绘图。

### 实战案例1：多孔Blob，脚本标注每一个斑点面积

1. GroupRun拿到Blob工具结果，循环每一个斑点，创建`CogGraphicLabel`，把面积文本存入List。
2. ModifyLastRunRecord遍历List，将全部文本标签添加到图像记录。

### 实战案例2：卡尺检测溢胶，矩形标注溢胶区域

1. GroupRun遍历卡尺结果，判断宽度是否超出阈值，记录溢胶起止坐标。
2. 根据起止坐标生成红色矩形，存入List。
3. ModifyLastRunRecord把所有矩形绘制在图像上，标出溢胶位置。

## 三、SearchMax纹理匹配工具

> 和PMA(CogPMAlignTool)用法流程基本一致，同样支持旋转、缩放。

### PMA vs SearchMax对比

| PMA(PatMax)                            | SearchMax                                          |
| -------------------------------------- | -------------------------------------------------- |
| 基于**边缘轮廓特征**                   | 基于**彩色纹理归一化算法**                         |
| 只接收灰度图像                         | 支持彩色图像                                       |
| 适合零件轮廓特征，不适合纹理、印花图案 | 适合彩色纹理、印刷图案、彩色物体；支持一定歪斜畸变 |

> 适用场景：胶囊检测、杂志页面印刷图案识别。

## 四、作业

1. 多卡尺，高级脚本标注每个零件内孔高度；
2. 彩色书签识别，脚本在色块上标注对应颜色名称；
3. SearchMax识别杂志页面，脚本标注当前是第几页。

## 五、易错点

1. 自定义绘图**不要在GroupRun里面直接绘制图形**；图形必须在`ModifyLastRunRecord`调用`AddGraphicToRunRecord()`，否则图像窗口看不到标注。
2. `return false`关闭自动执行，需要自己调用`RunTool()`运行工具，否则Block内部工具不会跑。
3. SearchMax支持彩色图；PMA(PatMax)只能使用灰度图。
4. 批量绘图：图形对象存List，最后统一添加进运行记录，不要循环内直接AddGraphic。

## 📝面试简答

**Q：GroupRun return true和return false区别？😃**

> A：`return true`：VisionPro自动顺序执行Block内部全部工具，脚本只做前置逻辑； `return false`：关闭自动执行，开发人员手动调用`RunTool()`，可以实现条件分支、选择性运行工具。

**Q：高级脚本自定义画标注图形，写在哪个方法里面？为什么？🤔**

> A：写在`ModifyLastRunRecord`。该方法在所有工具执行完成、生成运行记录之后调用；只有在这里调用`AddGraphicToRunRecord()`，图形才可以正常显示在图像窗口。

**Q：PMA和SearchMax选型区别？**

> A：PMA基于边缘轮廓，输入灰度图，适合机械零件轮廓定位；SearchMax基于彩色纹理，支持彩图，适合印花、纹理、彩色图案识别。

> 需要的话我可以把VisionPro day01‑day06全套输出完整复习文档。