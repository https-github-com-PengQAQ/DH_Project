
Fade = {name = "Fade"}
local this = Fade

local image = 1
local speed = 3
function Fade:Start( ... )
	-- body
	local canvas = UE.GameObject.Find("Canvas").transform
	self.transform:SetParent(canvas,false)
	image = this:GetComponent(typeof(Image))
end

function Fade:Update( ... )
	-- body
	this.fade()
end

function Fade.fadeToClear( ... )
	-- body
	image.color = UE.Color.Lerp(image.color,UE.Color.clear,speed * UE.Time.delteTime)
end

function Fade.fadeToBlack( ... )
	-- body
	image.color = UE.Color.Lerp(image.color,UE.Color.black,speed * UE.Time.delteTime)
end


function Fade.fade( ... )
	-- body
	this.fadeToBlack()
	if image.color.a < 0.05f then
		fadeToClear()
	end
end


function sleep(n)
  local t = os.clock()
  while os.clock() - t <= n do
    -- nothing
  end
end

function Fade:ctor(obj)
    local o = {}
    setmetatable(o,self)
    self.__index = self
    return o
end
