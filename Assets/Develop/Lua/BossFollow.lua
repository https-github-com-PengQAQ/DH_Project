BossFollow = BaseClass("BossFollow")

local this = BossFollow

require("TraceableObject")

function BossFollow:Awake( ... )
	-- body
	this.tb = TraceableObject:New()
	tb.ob = Player
end

function function_name( ... )
	-- body
end