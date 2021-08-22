Observer = BaseClass("Observer")
 
function Observer:new()
	o = {}
	setmetatable(o,self)
	self.__index = self
	return o
end
 
ConcreteObserver = Observer:new()
 
function ConcreteObserver:new()
	o = {}
	setmetatable(o,self)
	self.__index = self
	return o
end





