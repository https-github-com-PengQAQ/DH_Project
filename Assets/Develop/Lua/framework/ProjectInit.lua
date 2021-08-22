

require("framework.CtrlManager")

ProjectInit = {}
local this = ProjectInit

function ProjectInit.Init()
	-- body
	this.ImportAllViews()

	CtrlManager.Init()

	CtrlManager.StartProcess(CtrlName.UIManager)

end

--导入引入项目中所有的视图层脚本
function ProjectInit.ImportAllViews()
    for i = 1, #ViewNames do
        require(tostring(ViewNames[i]))
    end
end