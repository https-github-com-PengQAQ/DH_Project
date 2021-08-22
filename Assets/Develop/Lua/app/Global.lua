
require "framework.Common.BaseClass"

--初始化全局变量别名，不要轻易改变调用顺序

UE = CS.UnityEngine
DT = CS.DG.Tweening
LU = CS.LuaUtil
SDK = CS.SDKManager

--项目中用到的控制层脚本名称
CtrlName={
            UIManager="UIManager",
            GameCtrl="GameCtrl"
         }
--项目中用到的视图层脚本名称
ViewNames={
            "MainView","ChooseView","GameView"
}

--观察者模式
-- ConcreteSubject = {}
-- ConcreteObserver = {}
require("framework.Subject")
require("framework.Observer")

Singleton = require("framework.Common.Singleton")

LogUtils = require("framework.LogUtils")

GameManager = require("framework.GameManager")

require("framework.MapGameManager")

--UIModel 和 UIView
require("UI.GameModel")
require("UI.GameView")
--事件管理者
require("framework.EventManager")
EventManager.init()

--全局属性
require("framework.GlobalAttribute")
LogUtils.info(GlobalAttribute)
GlobalAttribute.init()
GlobalAttribute.initChoose(0)
GlobalEnemy = 5



--对象池
ObjPoolClass = CS.Pool.ObjPool
ObjPool = ObjPoolClass.Instance




Player = {}
MainCamera = {}
require("CameraFollow")



--事件被观察者
EventSubject = ConcreteSubject:new()

EventSubject:Attach(EventManager.GetInstance())



--UI被观察者
UISubject = ConcreteSubject:new()
UISubject:Attach(GameModel.GetInstance())

--c#call lua
function act(data)
	-- body
	local s = {data[0],data[1]}
	LogUtils.info(s)
	LogUtils.info(s)
	UISubject:Notify(s)
end

--当前房间怪物死亡个数
localEnemyCount = 0

function enemyDeadOne(name)
	-- body
	if name ~= "Boss" then
		localEnemyCount = localEnemyCount + 1
	else
		GameManager.NextGame()
	end
end

--层级
GameFloor = 1
-- DEBUG = CS.InitParams.DEBUG --为了让日志还能工作，先暂时这样写
-- CNDEBUG = CS.InitParams.CNDEBUG and DEBUG --如果调试标签关了 这个标签也不应该开启
-- CHDEBUG = CS.InitParams.CHDEBUG and DEBUG --如果调试标签关了 这个标签也不应该开启
-- SKIPSTORY = CS.InitParams.SKIPSTORY and DEBUG --如果调试标签关了 这个标签也不应该开启
-- LAST_VSN_STAGE = CS.InitParams.LAST_VSN_STAGE or 0

-- LoginPlugin = CS.SDK.Plugins.LoginPlugin
-- SystemPlugin = CS.SDK.Plugins.SystemPlugin

-- DataConst = require("data.Const")
-- local luaSche = require("common.LuaScheduler")
-- SchedulerManager = luaSche.new()

-- Platform = require("framework.Platform")

-- GameHelper = require("common.helper.GameHelper")

-- ItemHelper = require("common.helper.ItemHelper")
-- HotUpdateHelper = require("framework.hotupdate.HotUpdateHelper")

-- RedDotHelper = require("common.helper.RedDotHelper")

-- AudioHelper = require("common.helper.AudioHelper")
-- ProtoConfigs = require("network.ProtoConfigs")

-- RM = require("ui.controls.resources.ResourcesManager")

-- PM = require("ui.controls.resources.PoolManager")

-- SC = require("ui.controls.SceneManager")

-- LM = require("ui.controls.LoadingManager")

-- AM = require("ui.controls.AudioManager")

-- TM = require("ui.controls.TutorialManager")

-- UDM = require("data.UserDataManager")


-- UIMC = require("ui.controls.UIMessageCenter")


-- UIHelper = require("common.helper.UIHelper")

-- GotoHelper = require("common.helper.GotoHelper")

-- UserHelper = require("common.helper.UserHelper")

-- PLM = require("common.payment.PaymentManager")

-- SDKGlobalListener = require("common.SDKGlobalListener")

-- --在所有的global的manager里，因为大多数情况下都是网络事件触发一系列行为，所以约定NM处于一个主动管理其它manager的位置，最后初始化
-- NM = require("network.NetManager")
-- NM:init()

-- InputManager = require("ui.controls.InputManager")
-- CustomerServiceHelper = require("common.helper.CustomerServiceHelper")



-- LTH = require("common.localize.LocalizeHelper")

-- ER = require("ui.controls.ErrorReporter")
-- TimeReporter = require("ui.controls.TimeReporter")

-- PinyinHelper = require("common.helper.PinyinHelper")

