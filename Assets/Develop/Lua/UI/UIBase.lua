--[[
-- UI基类
]]
BaseUI = {name = "BaseUI"}
local UIBase = BaseClass("UIBase")
local  this = UIBase
local buttonList = List:New()

function BaseUI:Awake(self)
	-- body
	local canvas = UE.GameObject.Find("Canvas").transform
	self.transform:SetParent(canvas,false)
	LogUtils.info("UIBASE AWAKE")
end

--打开UI
function BaseUI.OnOpen(self)
	-- body
	local canvasGroup = self.canvasGroup
	canvasGroup.alpha = 1
	canvasGroup.blocksRaycasts = true
end

function BaseUI:OnClose(self, x)
	-- body
	LogUtils.info("Close")
	LogUtils.info(self)

	--local canvasGroup = this:GetComponent(typeof(CanvasGroup))
	--canvasGroup.alpha = 0
	--canvasGroup.blocksRaycasts = false
end

--隐藏UI
function BaseUI.OnHide(self)
	-- body
	self.canvasGroup.alpha = 0
end 

--重新打开UI
function BaseUI.OnResume(self)
	-- body
	local canvasGroup = self.canvasGroup
	canvasGroup.alpha = 1
	canvasGroup.blocksRaycasts = true
end

function BaseUI:ctor(obj)
    local o = {}
    setmetatable(o,self)
    self.__index = self
    return o
end