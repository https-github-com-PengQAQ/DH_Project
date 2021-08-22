Stack = {
    stackTab = {}
}

--创建栈

function Stack:New()
    self:Init()
    --
    local t = {}
    setmetatable(t, {__index = self})
    return t
end

--栈数据初始化
function Stack:Init()
    self.stackTab = {}
end

--返回栈元素长度
function Stack:Count()
    local count = 0
    for k,v in pairs(self.stackTab) do
        count = count + 1
    end
    return count
end

--入栈
function Stack:Push(...)
    local args = {...}
    print(next(args))
    if next(args) then
        for i =1, #args do
            table.insert(self.stackTab,args[i])
        end
    end
end

--出栈(并移除)
--返回单条数据  or  数据表
function Stack:Pop(num)
    LogUtils.info(self)
    if not num then
        local result = self.stackTab[self:Count()]
        table.remove(self.stackTab)
        return result
    end
    assert(num>0,"参数必须为正整数")
    local popTab = {}
    for i = 1, num do
        table.insert(popTab,self.stackTab[self:Count()])
        table.remove(self.stackTab)
    end
    return popTab
end

--出栈(不移除)
--返回单条数据  or  数据表
function Stack:Peek(num)
    if not num then
        local result = self.stackTab[self:Count()]
        return result
    end
    assert(num>0, "参数必须为正整数")
    local peekTab = {}
    local count = 0
    local tempIndex = 0
    for i =1 ,num do
        tempIndex = (self:Count() - count) >= 0 and (self:Count() - count) or 0
        table.insert(peekTab,self.stackTab[tempIndex])
        count = count + 1
    end
    return peekTab
end

return Stack