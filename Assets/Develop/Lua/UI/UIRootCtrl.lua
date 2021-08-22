

UIRootCtrl = {}
local this = UIRootCtrl

local string scenesNameByUIRoot = "prefab"
local string packageNameByUIRoot = "prefab/ui.ab"
local string assetNameByUIRoot = "Main.prefab"

local abManaggerClass = CS.ABFW.AssetBundleMgr 
local abManagerObj = abManaggerClass.GetInstance()

function UIRootCtrl.GetInstance()
	-- body
	return this
end

function UIRootCtrl.StartProcess()
	-- body
	LogUtils.info("why")
	abManagerObj:LoadAssetBundlePackage(scenesNameByUIRoot,packageNameByUIRoot,this.ProcessComplete)
	
end

function UIRootCtrl:ProcessComplete( ... )
	-- body

	local tempObj = abManagerObj:LoadAsset(scenesNameByUIRoot,packageNameByUIRoot,assetNameByUIRoot)
	LogUtils.info(tempObj)
	if tempObj ~= nil then
		local cloneObj = UE.Object.Instantiate(tempObj)
		CS.LuaComponent.Add(cloneObj,BaseUI)

		local startBtn = UE.GameObject.Find("StartBtn"):GetComponent(typeof(UE.UI.Button))

		startBtn.onClick:AddListener(this.P)

		require("BaseUI")
		--LogUtils.info(cloneObj:BaseUI.OnClose())
		--startBtn.onClick:AddListener(cloneObj:GetComponent(typeof(UIBase)).OnClose)
	end
end

function UIRootCtrl.P()
	-- body

	local tempObj = abManagerObj:LoadAsset(scenesNameByUIRoot,packageNameByUIRoot,"Game.prefab")
	local cloneObj = UE.Object.Instantiate(tempObj)
	CS.LuaComponent.Add(cloneObj,BaseUI)
	UE.SceneManager.LoadScene(2, UE.LoadSceneMode.Additive);
end
