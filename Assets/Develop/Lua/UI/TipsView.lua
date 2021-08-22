
TipsView={}
local this=TipsView
--定义变量
local transform



--说明:
--输入参数： obj 表示UI窗体对象。
function TipsView.Awake(obj)
    print("------- ChooseView.Awake  -----------");
    this.obj = obj
    this.animator = obj:GetComponent(typeof(UE.Animator))
    transform=obj.transform
    LogUtils.info(obj)
    --初始化面板，查找按钮
    this.InitView()
end

--初始化面板，查找“开始按钮”
function TipsView.InitView()
    --print("UIRootView.InitView")
    --查找UI中按钮
    this.tip = transform:Find("tip")--返回transform
    this.tip = this.tip:GetComponent(typeof(UE.UI.Text)) 
end

function TipsView.fun(tip)
    -- body
    LogUtils.info(tip)
    LogUtils.info(this.tip)
    this.obj:SetActive(true)
    this.tip.text = tip
    --this.animator.Play("UIFilp")
end

