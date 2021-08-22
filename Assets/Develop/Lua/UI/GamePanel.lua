
GamePanel = {name = "GamePanel"}
local GamePanel = BaseClass("GamePanel",BaseUI)
local  this = GamePanel

function GamePanel:Awake(self,super)
	-- body
	--self.superAwake()
	local canvas = UE.GameObject.Find("Canvas").transform
	self.transform:SetParent(canvas,false)

end

function GamePanel:ToChoose( ... )
	-- body
	UIManager.PanelList:Count()
end

function GamePanel:ctor(obj)
    local o = {}
    setmetatable(o,self)
    self.__index = self
    return o
end
