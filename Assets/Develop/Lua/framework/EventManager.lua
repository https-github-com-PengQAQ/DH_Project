

EventManager = BaseClass("EventManager", Observer)
local this = EventManager

local EventList = List:New()

function EventManager.Notify(data)
	-- body
	LogUtils.info("Observer data = ")
	LogUtils.info(data)
	LogUtils.info("事件触发:")
	EventList[data[1]-100](data[2])
end

function EventManager.GetInstance( ... )
	-- body
	return this
end

function EventManager.init( ... )
	-- body

	--添加到事件列表
	List.Add(EventList,this.IncreasePlayerAttack)
	List.Add(EventList,this.IncreasePlayerLife)
	List.Add(EventList,this.IncreaseEnemyAttack)
	List.Add(EventList,this.IncreaseEnemyLife)
	List.Add(EventList,this.EnemyDeadEvent)
	List.Add(EventList,this.Light)

end

--增加人物攻击力
function EventManager.IncreasePlayerAttack(data)
	-- body
	GlobalAttribute.attack = Global.attack + data
	LogUtils.info("增加人物攻击力")
end



--增加人物生命值
function EventManager.IncreasePlayerLife(data)
	-- body
	LogUtils.info(GlobalAttribute)
	GlobalAttribute.life = GlobalAttribute.life + data

	--通知
	UISubject:Notify({0,-1})
	TipsView.fun("生命值变化")
	LogUtils.info("增加人物生命值")
	LogUtils.info(GlobalAttribute.life)
end

function EventManager.Light( data )
	-- body
	--通知
	--UISubject.Notify({0,1})
	TipsView.fun("闪电来咯")
	LogUtils.info("闪电来咯")
end

--增加怪物攻击力
function EventManager.IncreaseEnemyAttack(data)
	-- body
	GlobalAttribute.enemyAttack = GlobalAttribute.enemyAttack + data
	LogUtils.info("增加怪物攻击力")
end

--增加怪物生命值
function EventManager.IncreaseEnemyLife(data)
	-- body
	GlobalAttribute.enemyLife = GlobalAttribute.enemyLife + data
	LogUtils.info("增加怪物生命值")
end

--增加怪物死亡事件
function EventManager.EnemyDeadEvent(data)
	-- body
	GlobalAttribute.isBoom = true 
	LogUtils.info("增加怪物死亡事件")
end


