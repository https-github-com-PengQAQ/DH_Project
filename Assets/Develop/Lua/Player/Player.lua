
--人物属性类

local Player = BaseClass("Player")


--速度
local speed
--生命值
local life
--跳跃次数
local jumpCount
--跳跃力
local jumpPower
--g攻击力
local attack

local function __init(self)
	-- body
	speed = 1
	life = 1
	jumpCount = 2
	jumpPower = 2
    attack = 1

end

local function isAive(self)
	-- body
	local isAive = nil
	if life <= 0 then
		isAive = false
	end
	return isAive
end

Player.__init = __init
Player.isAive = isAive

return Player