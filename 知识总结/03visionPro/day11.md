# day11｜GigE相机、棋盘格标定、越疆Dobot机械臂SDK、九点标定 精简总结

> 重点：GigE相机配置回顾；棋盘格标定；越疆Dobot机械臂C#‑DLL二次开发（连接、回零、PTP运动、吸盘、指令队列）；**九点标定（手眼标定，图像像素坐标转机械臂世界坐标）**。

## 一、上节回顾

1. GigE相机：网卡同网段，巨型帧MTU=9014；多种图像格式Mono8/Mono10/Mono12/RGB8；4种触发模式。
2. `CogCalibCheckerboardTool`棋盘格标定：像素坐标转为真实物理毫米坐标，矫正镜头畸变。

## 二、GigE相机要点（复习）

1. 电脑网卡IP和相机**同一网段，前三段一致，末位不同**。
2. 巨型帧MTU设置≥8000‑9014，防止图像大包传输丢包、花屏。
3. 图像格式选型：绝大多数工业检测优先使用 **Mono8灰度图**。
4. 触发模式：
   - 手动：调试单次拍照；
   - 自由运行：连续不停拍照；
   - **硬件自动**：产线常用，外部光电传感器每触发一次拍一张；
   - 硬件半自动：仅响应一次外部触发，拍完停止。

## 三、棋盘格标定 CogCalibCheckerboardTool

1. 直接比例换算像素→毫米，**无法消除镜头畸变，误差大**。
2. 使用金属/陶瓷棋盘格标定板，`CogCalibCheckerboardTool`。
3. 建立**像素坐标 ↔ 物理毫米坐标映射，矫正镜头畸变**，后续测量直接输出真实物理尺寸。

## 四、越疆Dobot机械臂 C# SDK开发

### 1、环境部署

1. 官网下载Dobot C# Demo，提取DobotDll、CPlusDll下全部8个库文件。
2. VS项目：【显示所有文件】，把虚线的dll文件**包含到项目**；设置属性：复制到输出目录。
3. 修改cs源码命名空间，与项目命名空间保持一致。
4. 硬件接线：USB转串口连接电脑；设备管理器查看COM口号；上电，绿灯正常，红灯代表报警。

### 2、核心API

#### ①连接机械臂

```
StringBuilder fwType=new StringBuilder(128);
StringBuilder version=new StringBuilder(128);
int ret = DobotDll.ConnectDobot("COM3",115200,fwType,version);
// ret=0连接成功；非0失败
```

- 波特率固定：115200；出参使用`StringBuilder`接收固件、版本。

#### ②断开

```
DobotDll.DisconnectDobot();
```

#### ③回零

```
HOMECmd homeCmd=new HOMECmd();
UInt64 cmdIndex=0;
int ret=DobotDll.SetHOMECmd(ref homeCmd,false,ref cmdIndex);
// false=加入队列；true=立即执行；cmdIndex指令编号
```

#### ④PTP点位运动

- `ptpMode=0`：**MoveJ关节运动**，各轴同步转动，轨迹柔和；
- `ptpMode=1`：**MoveL直线运动**，末端严格走直线；
- x/y/z单位mm；rHead末端旋转角度，单位°。

```
PTPCmd ptpCmd=new PTPCmd();
ptpCmd.ptpMode=0;
ptpCmd.x=200;ptpCmd.y=0;ptpCmd.z=80;ptpCmd.rHead=0;
UInt64 cmdIndex=0;
int ret=DobotDll.SetPTPCmd(ref ptpCmd,false,ref cmdIndex);
```

#### ⑤读取机械臂当前姿态

```
Pose pose=new Pose();
int ret=DobotDll.GetPose(ref pose);
// pose.x/y/z/rHead 获取实时坐标
```

#### ⑥吸盘真空控制

```
//参数：enableCtrl，suck吸气，isQueued入队
DobotDll.SetEndEffectorSuctionCup(true,true,false,ref cmdIndex);
//suck=true开启吸气；false释放
```

#### ⑦指令队列整套流程（多任务）

1. `SetQueuedCmdStopExec()`：停止队列执行（急停）
2. `SetQueuedCmdClear()`：**清空指令队列**
3. 循环添加多个运动、吸盘命令，第二个参数`true`代表加入队列
4. `SetQueuedCmdStartExec()`：启动队列，机械臂自动依次执行。

#### ⑧清除报警（红灯）

```
DobotDll.ClearAllAlarmsState();
```

> 机械臂红灯报警，需要调用该接口清除报警才能继续运行。

### 关键注意

1. 调用DobotDll底层C++ DLL，结构体必须加`ref`引用传递。
2. `UInt64 cmdIndex`每条指令必须分配指令编号。
3. 返回`ret ==0`代表调用成功；非0代表调用出错。

## 五、九点标定（手眼标定⭐视觉抓取核心）

> 业务场景：VisionPro得到图像里面工件像素坐标，**转换成机械臂基座坐标系下X/Y/Z坐标，机械臂实现抓取**。

1. 原理：采集9组对应点：【图像像素坐标】+【该点对应的机械臂实际坐标】。

2. VisionPro工具记录图像点，同时记录机械臂移动到该位置的真实世界坐标。

3. 完成矩阵变换标定；后续视觉输出的像素点经过矩阵换算，直接给到机械臂运动指令。

   > 棋盘格标定：图像内部像素转毫米；**九点标定：图像坐标系 ↔ 机械臂基座坐标系（跨设备坐标转换）**。

## 六、易错点

1. Dobot库dll文件，必须设置属性复制到输出目录，运行才可以找到dll。
2. 机械臂红灯，调用`ClearAllAlarmsState()`清除报警。
3. 区分两个标定：
   - 棋盘格标定：**单张图片内部**，像素↔图像物理毫米；
   - 九点标定：**相机图像 ↔ 机械臂基座世界坐标，用于视觉抓取**。
4. 队列模式：多步抓取放料，先Clear清空队列，添加全部指令，再StartExec启动执行。

## 📝面试简答

**Q：MoveJ(MoveL)区别？😃**

> A：MoveJ（ptpMode=0）关节运动，各个轴同步旋转，路径柔和；MoveL（ptpMode=1）直线运动，末端严格走直线轨迹。

**Q：棋盘格标定和九点标定分别干什么？🤔**

> A：棋盘格标定：矫正镜头畸变，把图片内像素转为图片内毫米物理尺寸； 九点手眼标定：建立【相机图像坐标】和【机械臂基座坐标】的变换矩阵，视觉检测坐标送给机械臂做抓取。

**Q：机械臂指令队列的执行流程？**

> A：停止队列 → Clear清空旧任务 → 循环添加运动/吸盘指令入队 → StartExec启动队列自动执行。

> 如果你需要，我可以把 VisionPro day01‑day11整套完整背诵文档输出。