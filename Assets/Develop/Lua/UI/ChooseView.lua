
ChooseView={}
local this=ChooseView
--定义变量
local transform



--说明:
--输入参数： obj 表示UI窗体对象。
function ChooseView.Awake(obj)
    print("------- ChooseView.Awake  -----------");
    transform=obj.transform
    LogUtils.info(obj)
    --初始化面板，查找按钮
    this.InitView()
end

--初始化面板，查找“开始按钮”
function ChooseView.InitView()
    --print("UIRootView.InitView")
    --查找UI中按钮
    this.BtnKnife = transform:Find("BtnKnife")--返回transform
    LogUtils.info(this.BtnKnife)
    this.BtnKnife = this.BtnKnife:GetComponent("UnityEngine.UI.Button") --返回Button类型
    
    this.BtnGun = transform:Find("BtnGun")--返回transform
    this.BtnGun = this.BtnGun:GetComponent("UnityEngine.UI.Button") --返回Button类型
end

