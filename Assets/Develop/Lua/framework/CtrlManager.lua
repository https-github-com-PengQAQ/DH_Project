


require("UI.UIManager")
CtrlManager = {}
local this = CtrlManager

local ctrlList = {}

function CtrlManager.Init()
	-- body
	ctrlList[CtrlName.UIManager] = UIManager.GetInstance()

	--ctrlList[CtrlName.GameCtrl]=GameCtrl.GetInstance()
end

function CtrlManager.GetCtrlInstance(ctrlName)
	-- body

	return ctrlList[ctrlName]
end

function CtrlManager.StartProcess(ctrlName)
	-- body

	local ctrlObj = CtrlManager.GetCtrlInstance(ctrlName)
	LogUtils.info(ctrlObj)
	if ctrlObj ~= nil then
		LogUtils.info("zheli")
		ctrlObj.StartProcess()

	end
end

