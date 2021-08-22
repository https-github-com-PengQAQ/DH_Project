
TraceableObject = BaseClass("TraceableObject")
local this = TraceableObject

function TraceableObject:New()
	-- body
	this.ob = {}	--可回溯物体
	this.pos = {}	--记录的位置信息
	this.sprite = {}--记录的图片信息
	return this
end
