--日志上传在error模块做
local dhlog = {}
local DHLogManager = CS.DHLogManager

local function getPrintString( ... )
	local result = ""
	local paramCount = select('#', ...)
	for i = 1, paramCount do
		local v = select(i, ...)
		result = result .. tostring(v) .. "\t"
	end
	return result
end

function dhlog.print(...)
	if DEBUG then
    	dhlog.info(getPrintString(...))
    end	
end

function dhlog.printError(...)
	dhlog.error(getPrintString(...))
end

function dhlog.printWarning(...)
	if DEBUG then
    	dhlog.warning(getPrintString(...))
    end
end

function dhlog.info(msg,color)
	if DEBUG then
		msg = dhlog.obj2String(msg)
		DHLogManager.info(msg,color)
	end
end

function dhlog.error(msg)
	msg = dhlog.obj2String(msg)
	DHLogManager.error(msg)
end

function dhlog.warning(msg)
	msg = dhlog.obj2String(msg)
	DHLogManager.warning(msg)
end

function dhlog.obj2String(msg)
	local str = ""
	if type(msg) == "table" then
		local cache = {}
		for k, v in pairs(msg) do
			str = string.format("[%s] = ",k)
			if type(v) == "table" then
				str = str .. dhlog.obj2String(v)
			else
				str = str .. tostring(v)
			end
			table.insert(cache,str)
		end
		str = "{" .. table.concat(cache," ,") .. "}"
	else
		str = tostring(msg)
	end
	return str
end

return dhlog