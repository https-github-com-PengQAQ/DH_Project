Subject = {}
 
function Subject:new(o)
	o = o or {}
	setmetatable(o,self)
	self.__index = self
	return o
end
 
ConcreteSubject = Subject:new()
 
function ConcreteSubject:Attach(theconcreteobserver)
	if self.observers == nil then
		self.observers = {}
	end
	table.insert(self.observers,theconcreteobserver)
end
 
function ConcreteSubject:Detach(theconcreteobserver)
	for k, v in pairs(self.observers) do
		if v == theconcreteobserver then
			table.remove(self.observers,k)
			break
		end
	end
end
 
function ConcreteSubject:Notify(data)
	LogUtils.info("data = ")
	LogUtils.info(data)
	for _, v in pairs(self.observers) do
		LogUtils.info(data)
		v.Notify(data)
	end
end
