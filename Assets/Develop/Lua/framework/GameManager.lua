local GameManager = BaseClass("GameManager", Singleton)
local this = GameManager

--地图
local string scenesName = "map"
local string packageName = "map/map.ab"
local MapPathList = {"Map1.prefab","Map2.prefab","Map3.prefab","Map4.prefab","Map5.prefab","Map6.prefab","Map7.prefab","Map8.prefab","Map9.prefab","Map10.prefab","Map11.prefab","Map12.prefab","Map13.prefab","Map14.prefab","Map15.prefab","BossMap.prefab","ToBoss.prefab"}
local MapList = List:New()
--怪物
local string enemyName = "enemy"
local string enemy = "enemy/enemy.ab"
local enemyPathList = {"EnemyNight.prefab","Boss.prefab"}

local enemyGroundList = List:New()	--地面敌人
local enemyFlyList = List:New()		--天上敌人
local enemyBossList = List:New()	--Boss
--人物
local string playerName = "player"
local string player = "player/player.ab"

--资源管理器
local abManaggerClass = CS.ABFW.AssetBundleMgr 
local abManagerObj = abManaggerClass.GetInstance()


local maps = {}
function GetInstance( ... )
	-- body
	return this
end


function GameManager.GameStart( ... )
	-- body
	
	--加载地图AB包
	abManagerObj:LoadAssetBundlePackage(scenesName,packageName,this.ProcessComplete)
	
end

--加载地图回调函数
function GameManager:ProcessComplete( ... )

	--生成地图列表
	for k, map in pairs(MapPathList) do
		local mapObj = abManagerObj:LoadAsset(scenesName,packageName,map)
		--local m = UE.GameObject.Find("Map")
		--local mapInstance = UE.Object.Instantiate(mapObj,m.transform)
		List.Add(MapList,mapObj)

	end
	
	--随机地图
	LogUtils.info("jjjjjjjj")
	
	--加载怪物AB包
	LogUtils.info(enemyName)
	abManagerObj:LoadAssetBundlePackage(enemyName,enemy,this.InstantiateEnemy)
	--abManagerObj:LoadAssetBundlePackage(playerName,player,this.InstantiatePlayer)
end


--加载怪物回调函数
function GameManager:InstantiateEnemy( ... )

	-- body
	for k, obj in pairs(enemyPathList) do
		LogUtils.info(obj)
		local eObj = abManagerObj:LoadAsset(enemyName,enemy,obj)
		LogUtils.info(eObj)
		--初始化怪物属性
		--eObj = this.EnemyAIint(eObj)
		if eObj:CompareTag("enemyGround") == true then
			List.Add(enemyGroundList,eObj)
		elseif eObj:CompareTag("enemyFly") == true then
			List.Add(enemyFlyList,eObj)
		else
			List.Add(enemyBossList,eObj)
		end
	end
	
	LogUtils.info("iiiiiiiiiiiiiiiiiiiii")
	LogUtils.info(enemyGroundList)
	this.SortMap()
    --加载人物AB包
	abManagerObj:LoadAssetBundlePackage(playerName,player,this.InstantiatePlayer)
end

--根据层数初始化怪物属性 --todo
function GameManager.EnemyAIint(enemyObj)
	-- body
	LogUtils.info(enemyObj:GetComponent(typeof(CS.FSM)).parameter.health)

	if enemyObj.name == "Boss" then
		enemyObj:GetComponent(typeof(CS.FSM)).parameter.health = 10 * GameFloor
	else
		enemyObj:GetComponent(typeof(CS.FSM)).health = GlobalAttribute.enemyLife * GameFloor
	end
	return enemyObj
end


--加载人物回调函数
function GameManager:InstantiatePlayer( ... )

	-- body
	LogUtils.info(GlobelChoose)
	local p
	if GlobelChoose == 0 then
		p = abManagerObj:LoadAsset(playerName,player,"Player.prefab")
		LogUtils.info(p)
	else
		p = abManagerObj:LoadAsset(playerName,player,"GunPlayer.prefab")
		LogUtils.info(p)
	end
	Player = UE.Object.Instantiate(p)


	local roomP = UE.GameObject.Find("RoomGenerate")

	local script = roomP:GetComponent(typeof(CS.Map.RoomGenerator))


	local xpos = script.playeRoom.roomxPosition
	local ypos = script.playeRoom.roomyPosition
	local pos = Vector2.New(xpos,ypos)
	
	
	Player.transform.position = script.rooMap[pos].roomInfo.startPos.position
	LogUtils.info(script.rooMap[pos].roomInfo.startPos.localPosition)


	maps = script.rooMap



	this.CameraFollow(pos)


	UIManager.Loding1()


	local input = UE.GameObject.Find("InputManager")
	CS.LuaComponent.Add(input,MapGameManager)
	MapGameManager.init(script.rooMap[pos].roomInfo)
	this.ChooseRoomToBossRoom()
end

--第一次随机生成地图
function GameManager.SortMap( ... )

	local roomP = UE.GameObject.Find("RoomGenerate")
	local script = roomP:GetComponent(typeof(CS.Map.RoomGenerator))
	script.player = Player
	
	--向地图加预制体

	--向地图加敌人预制体
	for k,v in pairs(MapList) do
		if v.name == "ToBoss" then
			break
		end
		LogUtils.info(v)
		LogUtils.info(v:CompareTag("BossRoom"))
		if v:CompareTag("BossRoom") == false then
			--给地面加
			LogUtils.info(v:GetComponent(typeof(CS.RoomIdentity)).enemyGround.Length)

			for j=1, v:GetComponent(typeof(CS.RoomIdentity)).enemyGround.Length do

				--local r = math.floor(UE.Random.RandomRange(1, enemyGroundList.Count()))

				LogUtils.info(enemyGroundList[1])
				--LogUtils.info(enemyGroundList[r])
				v:GetComponent(typeof(CS.RoomIdentity)).enemyGround[j-1] = enemyGroundList[1]
			end
			LogUtils.info("fly")
			--给天上加
			LogUtils.info(v:GetComponent(typeof(CS.RoomIdentity)).enemyFly.Length)
			for j=1, v:GetComponent(typeof(CS.RoomIdentity)).enemyFly.Length do
				--local r = math.floor(UE.Random.RandomRange(1, enemyFlyList.Count()))

				v:GetComponent(typeof(CS.RoomIdentity)).enemyFly[j] = enemyFlyList[1]
			end
		else
			v:GetComponent(typeof(CS.RoomIdentity)).Boss = enemyBossList[1]
		end
	end

	LogUtils.info(MapList)
	script.wallType.WallL = MapList[4]:GetComponent(typeof(CS.RoomIdentity))
	script.wallType.WallR = MapList[12]:GetComponent(typeof(CS.RoomIdentity))
	script.wallType.WallU = MapList[15]:GetComponent(typeof(CS.RoomIdentity))
	script.wallType.WallD = MapList[1]:GetComponent(typeof(CS.RoomIdentity))
	script.wallType.WallLR = MapList[6]:GetComponent(typeof(CS.RoomIdentity))
	script.wallType.WallLU = MapList[10]:GetComponent(typeof(CS.RoomIdentity))
	script.wallType.WallLD = MapList[5]:GetComponent(typeof(CS.RoomIdentity))
	script.wallType.WallUR = MapList[13]:GetComponent(typeof(CS.RoomIdentity))
	script.wallType.WallUD = MapList[3]:GetComponent(typeof(CS.RoomIdentity))
	script.wallType.WallRD = MapList[2]:GetComponent(typeof(CS.RoomIdentity))
	script.wallType.WallLUR = MapList[9]:GetComponent(typeof(CS.RoomIdentity))
	script.wallType.WallLUD = MapList[11]:GetComponent(typeof(CS.RoomIdentity))
	script.wallType.WallURD = MapList[14]:GetComponent(typeof(CS.RoomIdentity))
	script.wallType.WallLRD = MapList[7]:GetComponent(typeof(CS.RoomIdentity))
	script.wallType.WallALL = MapList[8]:GetComponent(typeof(CS.RoomIdentity))
	script.wallType.Boss = MapList[15]:GetComponent(typeof(CS.RoomIdentity))

	script:SortMap(MapList)
end

--后面生成地图
function GameManager.nextSortMap( ... )
	-- body
	LogUtils.info(CameraFollow.flag)
	CameraFollow.flag = false
	LogUtils.info(CameraFollow.flag)
	local roomP = UE.GameObject.Find("RoomGenerate")
	local script = roomP:GetComponent(typeof(CS.Map.RoomGenerator))
	script.player = Player

	script:SortMap(MapList)
	maps = script.rooMap
	local xpos = script.playeRoom.roomxPosition
	local ypos = script.playeRoom.roomyPosition
	local pos = Vector2.New(xpos,ypos)
	Player.transform.position = script.rooMap[pos].roomInfo.startPos.position
	LogUtils.info(pos)
	ChangeMap(pos)
	CameraSetPos(pos)
end


--将镜头跟随脚本加到MainCamera中
function GameManager.CameraFollow(pos)

	MainCamera = UE.GameObject.Find("Main Camera")

	require("CameraFollow")

	CameraSetPos(pos)

	CS.LuaComponent.Add(MainCamera,CameraFollow)
	UIManager.Loding1()
end

--进入下一层
function GameManager:NextGame( ... )
	-- body
	--地图重新生成
	this.nextSortMap()
	--数据更新

end

--进入下一个房间，改变当前房间信息
function ChangeMap(pos)
	-- body
	MapGameManager.init(maps[pos].roomInfo)

end

--改变镜头限制
function  CameraSetPos(pos)
	-- body
	LogUtils.info(pos)
	CameraFollow.SetPos(maps[pos].roomInfo)
end

--选择一个房间生成去boss房的传送门
function GameManager.ChooseRoomToBossRoom( ... )
	-- body
	local door = UE.Object.Instantiate( MapList[17])
	local r = math.floor(UE.Random.RandomRange(15, 20))

	LogUtils.info(r)
	local theChooseRoom = UE.GameObject.Find("Rooms").transform:GetChild(r):GetComponent(typeof(CS.RoomIdentity))

	LogUtils.info(theChooseRoom)

	door.transform.position = theChooseRoom.startPos.position
end

--去Boss房间
function ToBossRoom( ... )
	-- body
	local roomP = UE.GameObject.Find("RoomGenerate")
	LogUtils.info(roomP)
	local script = roomP:GetComponent(typeof(CS.Map.RoomGenerator))

	LogUtils.info(script)
	LogUtils.info(script.BoosRoom)
	local BossMap = script.BoosRoom
	MapGameManager.init(BossMap)
	Player.transform.position = BossMap.startPos.position
	CameraFollow.SetPos(BossMap)
end
return GameManager