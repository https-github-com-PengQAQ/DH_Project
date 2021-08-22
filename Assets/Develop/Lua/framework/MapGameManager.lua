MapGameManager = {name = "MapGameManager"}
local this = MapGameManager

local localMap
local EnemyCount 
local offsetTime
local sFlag = false
function MapGameManager.init(map)
	-- body
	LogUtils.info("mmmmmmmmmmmmmmmmmmmmm")
	this.localMap = map:GetComponent(typeof(CS.RoomIdentity))
	LogUtils.info(this.localMap)
	this.localMap.bo = 2 
	this.flag = this.localMap.flag



	CameraFollow.flag = true
	offsetTime = 100
end

function MapGameManager:Update( ... )
	-- body
	this.GameStart()

	--单向板向下
	if UE.Input.GetKeyDown(UE.KeyCode.S) then
		this.localMap:mapGameEnd()


	end

	if sFlag == true then
		offsetTime = offsetTime - 1
		if offsetTime <= 0 then
			this.localMap.pe.rotationalOffset = 0
			offsetTime = 100
			sFlag = false
		end
	end

	if localEnemyCount >= this.localMap.count and this.flag ~= 2 then
		this.localMap:mapGameEnd()
		localEnemyCount = 0
	end



	--判断玩家是否死亡
	if GameView.Life <= 0 then
		UIManager.GameOver()
	end
end

function MapGameManager.GameStart( ... )
	-- body
	--如果是第一次进这个房间

	if this.localMap.isFirst == true then
		this.localMap:mapGameStart()
		LogUtils.info("jinlai l")
		if this.flag == 0 then

			EventSubject:Notify({106,-1})
		end
	end

end


function MapGameOver( ... )
	-- body
	this.localMap.mapGameEnd()
end


function MapGameManager:ctor(obj)
    local o = {}
    setmetatable(o,self)
    self.__index = self
    return o
end