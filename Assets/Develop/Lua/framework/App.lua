local App = {}
function App.init()
    
    require("app.functions")
    require("Common.Main")
    require("app.Global")
    

    --为了任意场景都能够跑，这里的init直接在lua虚拟机创建的时候初始化
    collectgarbage("setpause", 100)
    collectgarbage("setstepmul", 5000)

    App.startGame()
end

--第一次进入游戏
function App.startGame()
    LogUtils.info("开始游戏")

    require("framework.ProjectInit")
    ProjectInit.Init()

    --UIManager:showUI("Main")
    --require("Player.PlayerControl")
    --require("UI.Main")
    
    --local Player = UE.GameObject.Find("Player")
    --local x = CS.LuaComponent.Add(Player,PlayerCon)

    
    -- require("UI.GameModel")
    -- local  s = ConcreteSubject:new()
    -- local x = GameModel.GetInstance()
    -- s:Attach(x)
    -- s:Notify()
end

-- function App.init()
--     -- body
--     require("framework.ProjectInit")
--     ProjectInit.Init()
-- end


--游戏运行时快速重启
function App.restartGame()
    App.clearAll()
    App.init()
    --下面是重启游戏逻辑
end

--保持lua库模块不要动，快速重启UI的代码以及UI界面
function App.restartUI( )
    --不需要卸载的模块
    local whitelist = {
        ["string"] = true,
        ["io"] = true,
        ["pb"] = true,
        ["os"] = true,
        ["debug"] = true,
        ["table"] = true,
        ["math"] = true,
        ["package"] = true,
        ["coroutine"] = true,
        ["pack"] = true,
    }
    App.clearModules(whitelist)
    App.init()
end




function App.clearAll()
    App.clearResourceCache()
    --不需要卸载的模块
    local whitelist = {
        ["string"] = true,
        ["io"] = true,
        ["pb"] = true,
        ["os"] = true,
        ["debug"] = true,
        ["table"] = true,
        ["math"] = true,
        ["package"] = true,
        ["coroutine"] = true,
        ["pack"] = true,
    }
    App.clearModules(whitelist)
end

function App.clearModules(whitelist)
    --清理LuaBehaviour中缓存的Lua
    CS.LuaBehaviour.clearCache()
    local __g = _G
    setmetatable(__g, {})
    --卸载已加载的Lua模块
    for p, _ in pairs(package.loaded) do
        if not whitelist[p] then
            package.loaded[p] = nil
        end
    end
end

--业务需求，清理所有资源缓存
function App.clearResourceCache()
    --资源回收

end


return App
