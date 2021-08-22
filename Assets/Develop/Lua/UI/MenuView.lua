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

MenuView={}
local this=MenuView
--定义变量
local transform



--说明:
--输入参数： obj 表示UI窗体对象。
function MenuView.Awake(obj)
    print("------- MainView.Awake  -----------");
    transform=obj.transform
    --初始化面板，查找按钮
    this.InitView()
end

--初始化面板，查找“按钮”
function MenuView.InitView()
    --print("UIRootView.InitView")
    --查找UI中按钮
    this.BtnContinue = transform:Find("BtnContinue")--返回transform
    this.BtnContinue = this.BtnContinue:GetComponent("UnityEngine.UI.Button") --返回Button类型
    this.BtnTomain = transform:Find("BtnTomain")
    this.BtnTomain = this.BtnTomain:GetComponent("UnityEngine.UI.Button") --返回Button类型
end

