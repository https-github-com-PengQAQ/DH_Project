---
--- UI根预设_显示脚本
---
---   功能：
---       查找本窗体中的按钮。（本视图层完成）
---       给按钮增加监听事件。（在对应的控制层完成）
---
--- Created by Administrator.
--- DateTime: 2019/5/28
---

MainView={}
local this=MainView
--定义变量
local transform



--说明:
--输入参数： obj 表示UI窗体对象。
function MainView.Awake(obj)
    print("------- MainView.Awake  -----------");
    transform=obj.transform
    --初始化面板，查找按钮
    this.InitView()
end

--初始化面板，查找“开始按钮”
function MainView.InitView()
    --print("UIRootView.InitView")
    --查找UI中按钮
    this.BtnStart = transform:Find("BtnStart")--返回transform
    LogUtils.info(this.BtnStart)
    this.BtnStart = this.BtnStart:GetComponent("UnityEngine.UI.Button") --返回Button类型
    this.BtnExit = transform:Find("BtnExit")
    this.BtnExit = this.BtnExit:GetComponent("UnityEngine.UI.Button") --返回Button类型
end

