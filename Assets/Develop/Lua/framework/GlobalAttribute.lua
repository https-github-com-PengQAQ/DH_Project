
GlobalAttribute = BaseClass("GlobalAttribute")
local this = GlobalAttribute


--人物属性
local choose = {}	--近战为0，远程为1
local gold = {}		--金币
local life = {}		--生命值
local attack = {}   --攻击力
local speed = {}	--速度
local attackSpeed = {}	--攻击速度
local jumpCount = {}	--跳跃次数

--敌人属性

local enemyLife = {}	--敌人生命值
local enemyAttack = {}	--敌人攻击力
local isBoom = {}		--死亡效果
local coin = {}			--死亡掉落金币

function GlobalAttribute.init( ... )
	-- body
	--人物属性初始
	this.gold = 0
	this.life = 5
	this.attack = 1
	this.speed = 5
	this.attackSpeed = 1

	--怪物属性初始
	this.enemyLife = 3
	this.enemyAttack = 1
	this.isBoom = false
	this.coin = 1
end

function GlobalAttribute.initChoose(num)
	-- body
	this.choose = num
end