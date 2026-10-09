# fxiday06|图书管理系统登录状态-02winform-11day 数据绑定



## 图书管理系统首页登录状态优化

使用工具控件ToolStripMenuItem

给按钮增加跳转页面



使用AntdUI的提示优化

```
AntdUI.Config.ShowInWindow = true;

AntdUI.Message.warn(this,"未登录，请点击左上角登录！",autoClose:1);
```



## 数据绑定

简单绑定：TextBox、label、CheckBox

把控件的属性和对象的属性进行绑定

注意不是对象的字段，一定是set的

对象的类要实现接口`INotifyPropertyChanged`

复杂绑定：DataGridView