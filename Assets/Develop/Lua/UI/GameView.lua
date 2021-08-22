
GameView={}
GameView = BaseClass("GameView",Observer)
local this=GameView
--定义变量
local transform
local lifeList = List:New()
local maxLife = 10
--说明:
--输入参数： obj 表示UI窗体对象。
function GameView.Awake(obj)
    print("------- GameView.Awake  -----------");
    transform=obj.transform
    LogUtils.info(obj.name)
    --初始化面板，查找按钮
    this.InitView()
end

--初始化面板，查找“开始按钮”
function GameView.InitView()
    --print("UIRootView.InitView")
    --查找UI中按钮
    this.BtnMenu = transform:GetChild(0):GetChild(0)--返回transform
    LogUtils.info(this.BtnMenu)
    this.BtnMenu = this.BtnMenu:GetComponent("UnityEngine.UI.Button") --返回Button类型
    
    --查找UI中血条

    LogUtils.info("thisasdasd")
    this.Life = GlobalAttribute.life
    LogUtils.info(this.Life )
    this.BaseLife()

    --查找UI中金币
    this.Coin = transform:GetChild(0):GetChild(1):GetChild(1)

    this.Coin = this.Coin:GetComponent("UnityEngine.UI.Text")
    LogUtils.info(this.Coin)
end

--UIView层在数据层更新后刷新

function GameView.BaseLife()
    -- body
    LogUtils.info(transform:GetChild(0):GetChild(1):GetChild(2))
    this.lifes = transform:GetChild(0):GetChild(1):GetChild(2)
    for i=1, maxLife do
        LogUtils.info(this.lifes.transform:GetChild(i-1).gameObject)
        List.Add(lifeList,this.lifes.transform:GetChild(i-1).gameObject)
    end


    for k,obj in pairs(lifeList) do

        if k > this.Life then
            break
        end
        obj.gameObject:SetActive(true)
    end
end

--刷新生命值
function GameView.RefreshLife()
    -- body
    LogUtils.info(this.Life)
    LogUtils.info(GameModel.life)
    this.Life = GameModel.life
    local flag = true
    for k,obj in pairs(lifeList) do

        if k <= this.Life then
            obj.gameObject:SetActive(true)
        else
            obj.gameObject:SetActive(false)
        end

    end
end


--刷新金币
function GameView.RefreshCoin()
    -- body
    this.Coin.text = GameModel.coin
    LogUtils.info(this.Coin)
end