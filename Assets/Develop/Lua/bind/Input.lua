local App = require("framework.App")
function luaUpdate()
    --PC平台
    if  UE.Application.platform == UE.RuntimePlatform.WindowsEditor or UE.Application.platform == UE.RuntimePlatform.OSXEditor then
        if UE.Input.GetKeyDown(UE.KeyCode.F1)then
            CS.LuaBehaviour.fastRestartUI()
        elseif UE.Input.GetKeyDown(UE.KeyCode.F2) then
            CS.LuaBehaviour.fastRestart()
        end
    end
end