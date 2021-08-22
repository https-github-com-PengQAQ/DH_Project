
Loding = {name = "Loding"}
local LodingP = BaseClass("LodingP",BaseUI)
local  this = LodingP

function Loding:Awake(self,super)
	-- body
	local canvas = UE.GameObject.Find("Canvas").transform
	self.transform:SetParent(canvas,false)
	LogUtils.info("UIBASE AWAKE")
end

function Loding:ctor(obj)
    local o = {}
    setmetatable(o,self)
    self.__index = self
    return o
end