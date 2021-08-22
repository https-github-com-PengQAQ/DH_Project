
require("UI.MainPanel")
require("UI.LodingPanel")
require("UI.MainView")
require("UI.ChooseView")
require("UI.GameView")
require("UI.MenuView")
require("UI.TipsView")
UIManager = {}
local this = UIManager

local PanelList = List:New()
local panelStack = Stack:New()

local string scenesNameByUIRoot = "ui"
local string packageNameByUIRoot = "ui/ui.ab"
UIPrefab = {"Main.prefab","Game.prefab","Loding.prefab","Stop.prefab","Tips.prefab","Choose.prefab","Shop.prefab","Through.prefab","Dead.prefab"}
local abManaggerClass = CS.ABFW.AssetBundleMgr 
local abManagerObj = abManaggerClass.GetInstance()
function UIManager.GetInstance()
	-- body
	return this
end
function UIManager.StartProcess()
	-- body
	abManagerObj:LoadAssetBundlePackage(scenesNameByUIRoot,packageNameByUIRoot,this.ProcessComplete)
end

function UIManager:ProcessComplete( ... )
	-- body
	for k,prefabName in pairs(UIPrefab) do
		local prefab = abManagerObj:LoadAsset(scenesNameByUIRoot,packageNameByUIRoot,prefabName)
		if prefab ~= nil then
			local cloneObj = UE.Object.Instantiate(prefab)
			if prefab == "Through.prefab" then
				CS.LuaComponent.Add(cloneObj,Fade)
			end
			CS.LuaComponent.Add(cloneObj,Main)
			List.Add(PanelList,cloneObj)
			LogUtils.info(cloneObj.gameObject)
		end
	end

	for k,obj in pairs(PanelList) do
		LogUtils.info(obj)
		if k ~= 1 then
			obj.gameObject:SetActive(false)
		end
	end

	panelStack:Push(PanelList[1])
	
	this:AddButtonEvent()

end


function UIManager:AddButtonEvent( ... )

	--为每个面板的button加事件
	LogUtils.info("buuton")
	--Main
	MainView.Awake(PanelList[1])
	local btn1 = MainView.BtnStart
	local btn2 = MainView.BtnExit
	btn1.onClick:AddListener(this.StartGame)
	btn2.onClick:AddListener(this.ExitGame)

	--Choose
	LogUtils.info(PanelList)
	LogUtils.info(PanelList[6])
	ChooseView.Awake(PanelList[6])
	local btn1 = ChooseView.BtnKnife
	local btn2 = ChooseView.BtnGun
	btn1.onClick:AddListener(this.Choose1)
	btn2.onClick:AddListener(this.Choose2)

	--Game
	GameView.Awake(PanelList[2])
	local btn = GameView.BtnMenu
	btn.onClick:AddListener(this.ToMenu)
	

	--Menu
	MenuView.Awake(PanelList[4])
	local btn1 = MenuView.BtnContinue
	local btn2 = MenuView.BtnTomain
	btn1.onClick:AddListener(this.GameContinue)
	btn2.onClick:AddListener(this.Tomain)


	--Tips
	TipsView.Awake(PanelList[5])

end


--开始游戏
function UIManager.StartGame( ... )
	-- body
	--UIManager.Loding()
	--GameManager.GameStart()

	PanelList[1].gameObject:SetActive(false)
	PanelList[6].gameObject:SetActive(true)
end

--退出游戏
function UIManager.ExitGame( ... )
	-- body
	--App.clearAll()
	UE.Application.Quit()
end


--选择武器
--近战
function UIManager.Choose1()
	-- body
	GlobelChoose = 0
	UIManager.Loding()
	GameManager.GameStart()
	PanelList[6].gameObject:SetActive(false)
	PanelList[2].gameObject:SetActive(true)
end
--远程
function UIManager.Choose2( ... )
	-- body
	GlobelChoose = 1
	UIManager.Loding()
	GameManager.GameStart()
	PanelList[6].gameObject:SetActive(false)
	PanelList[2].gameObject:SetActive(true)
end

--暂停界面
function UIManager.ToMenu( ... )
	-- body
	--时间暂停
	UE.Time.timeScale = 0
	PanelList[4].gameObject:SetActive(true)
end

--游戏继续
function UIManager.GameContinue( ... )
	-- body
	UE.Time.timeScale = 1
	PanelList[4].gameObject:SetActive(false)
end


--返回主界面
function UIManager.Tomain( ... )
	-- body
	
	PanelList[2].gameObject:SetActive(false)
	PanelList[4].gameObject:SetActive(false)
	PanelList[1].gameObject:SetActive(true)
	UE.Time.timeScale = 1
end

--玩家死亡游戏结束
function UIManager.GameOver( ... )
	-- body
	PanelList[2].gameObject:SetActive(false)
	PanelList[9].gameObject:SetActive(true)
end
--加载面板
function UIManager.Loding( ... )
	-- body
	PanelList[3].gameObject:SetActive(true)
end
function UIManager.Loding1( ... )
	-- body
	PanelList[3].gameObject:SetActive(false)
end

--过场面板
function UIManager.ThroughBegin( ... )
	-- body
	PanelList[8].gameObject:SetActive(true)
end

function UIManager.ThroughEnd( ... )
	-- body
	PanelList[8].gameObject:SetActive(false)
end