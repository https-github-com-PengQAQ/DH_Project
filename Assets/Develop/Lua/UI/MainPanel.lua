
Main = {name = "Main"}
local Mainp = BaseClass("Mainp",BaseUI)
local  this = Mainp

function Main:Awake(self,super)
	-- body
	--self.superAwake()
	local canvas = UE.GameObject.Find("Canvas").transform
	self.transform:SetParent(canvas,false)
	LogUtils.info("UIBASE AWAKE")
end

function Main:ToChoose( ... )
	-- body
	UIManager.PanelList:Count()
end

function Main:ctor(obj)
    local o = {}
    setmetatable(o,self)
    self.__index = self
    return o
end
