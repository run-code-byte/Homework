# day03｜VisionPro PMA高级参数、几何创建与测量、CogToolBlock脚本 精简总结

> 承接day02，重点：PMA搜索区域、精细/粗糙特征；各类几何创建、全套距离角度测量；**CogToolBlock脚本编写做业务逻辑判断（OK‑NG、条件分支）**；胶路检测实战案例。

## 一、上节快速回顾

1. 卡尺工具：测量边缘/边缘对，对比度阈值、极性、边缘对宽度。
2. `CogFixtureTool`：接收2D变换矩阵生成跟随工件姿态的局部坐标系；典型链路：灰度转换 → PMA模板匹配 → Fixture定位 → 后续测量工具。
3. Find查找：直接图像搜索特征；Fit拟合：对点集合数学计算几何图形。
4. 图形标签`CogCreateGraphicLabel`格式化输出：`{D:F2}`保留2位小数、`{I}`整型、`{B}`布尔、`{D:P}`百分比。

## 二、PMA（CogPMAlignTool）补充参数

1. 限定搜索区域
   - 工件出现位置比较集中时，设置ROI搜索区域，缩小查找范围，**提升运行速度**；可以查看左下角运行耗时评估优化效果。
2. 显示精细 / 显示粗糙
   - 显示精细：绿色框，查看细节特征；
   - 显示粗糙：黄色框，查看整体粗匹配特征。

## 三、几何图形创建工具

| 工具       | 功能说明                              |
| ---------- | ------------------------------------- |
| 创建椭圆   | 生成椭圆图形                          |
| 两点平分线 | 取两个点，绘制两点中间平分线          |
| 创建平行线 | 给定一条直线+一个点，过该点绘制平行线 |
| 创建垂直线 | 给定一条直线+一个点，过该点绘制垂直线 |
| 角平分线   | 两条相交直线，绘制夹角平分线          |
| 创建线段   | 自定义起点终点绘制线段                |

> 多用于构建辅助参考线，配合后续距离、角度测量。

## 四、全套几何测量工具

> 可测：夹角、点‑点、点‑线、点‑圆、点‑椭圆、线段‑圆、线段‑椭圆、线‑圆等各类最短距离。

1. 两条直线夹角；两点连线相对X轴的有向角度。

2. 距离大类：

   - 点到点；点到直线；点到线段；点到圆；点到椭圆

   - 线到圆、线到椭圆；线段到圆、线段到椭圆

     > 测量返回距离、角度结果，可以送给GraphicLabel标注在图像上。

## 五、CogToolBlock脚本（⭐重点，业务逻辑处理）

> `CogToolBlock`（Block工具）内部写C#脚本，实现**if条件判断、循环遍历结果、业务逻辑、输出OK/NG、控制标注颜色**，QuickBuild可视化工具做不到复杂判断时就用脚本。

### 使用步骤

1. 添加`CogToolBlock`；右键Add Output添加输出端口（字符串、颜色、数字等）。
2. 双击进入脚本编辑，重写`GroupRun`方法。
3. 通过`Inputs.xxx`读取输入端口数据；`Outputs.xxx`给输出端口赋值。
4. 修改输入输出后，**必须清空旧脚本，重新编写，否则新增端口在脚本中不生效**。
5. 脚本编译生成发行，保存vpp。

### 示例1：简单条件判断（数量判断输出OK/NG）

```
public override bool GroupRun(ref string message, ref CogToolResultConstants result)
{
    if (Inputs.Count == 4)
    {
        Outputs.ConvertString = "OK";
        Outputs.Color = Cognex.VisionPro.CogColorConstants.Yellow;
    }
    else
    {
        Outputs.ConvertString = "NG";
        Outputs.Color = Cognex.VisionPro.CogColorConstants.Blue;
    }
    return false;
}
```

### 示例2：胶路检测实战案例

遍历卡尺结果，判断断胶、溢胶、缺胶，输出文本结果。

```
public override bool GroupRun(ref string message, ref CogToolResultConstants result)
{
    string text = "";
    bool flag = true;
    foreach(CogFindLineResult item in Inputs.Results)
    {
        if (!item.Used)
        {
            text = "断胶";
            flag = false;
            break;
        }
        if (item.CaliperResults[0].Width > 17)
        {
            text = "溢胶";
            flag = false;
            break;
        }
        if (item.CaliperResults[0].Width < 15)
        {
            text = "缺胶";
            flag = false;
            break;
        }
    }
    if(flag) text = "OK";
    Outputs.Text = text;
    return false;
}
```

### 典型业务作业

1. 骰子：斑点统计点数，>20输出大，否则输出小；
2. 羊角零件：判断左右是否合格，输出OK‑NG；
3. 手机电池：识别正反面输出文字；
4. 书签识别：区分青蛙/鲜花/心形书签；
5. 硬币检测：统计各类硬币数量，计算总金额。

## 六、易错点

1. PMA缩小搜索ROI，工件位置集中场景用来提速，看左下角运行时间验证。
2. CogToolBlock脚本：新增/修改输入输出端口，**要清除旧脚本重写**，否则脚本识别不到新增端口。
3. 几何区分：创建类只画辅助图形；测量类得到距离、角度数值结果。
4. 脚本可以输出颜色，配合`CogCreateGraphicLabel`实现OK黄色、NG红色不同颜色标注。

## 📝面试简答

**Q：CogToolBlock脚本一般用来做什么？😃**

> A：QuickBuild可视化工具不方便做复杂业务逻辑时，在Block的GroupRun写C#脚本；做if条件判断、遍历工具结果、缺陷判断，输出OK/NG、文本、颜色等业务结果。

**Q：PMA模板匹配怎么提升运行速度？🤔**

> A：工件出现位置比较固定时，限定搜索ROI区域，缩小查找范围，降低搜索像素量，查看运行耗时评估优化。

**Q：修改CogToolBlock输入输出端口之后脚本不识别新增端口怎么办？**

> A：清除旧脚本代码，重新编写脚本再生成发行。

> 如果需要，我可以把VisionPro day01‑day03和WinForm全套合并为总复习文档。