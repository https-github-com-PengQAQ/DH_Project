local SceneManager = BaseClass("SceneManager", Singleton)

local function __init(self)
	-- body
	--当前场景
	self.current_scene = nil
	--场景对象
	self.scenes = {}
end

local function CoInnerSwitchScene(self,sceneNmae)
	-- body
	--打开Loding界面
	UIManager:showUI("Loding")

	--初始化场景
	local logic_scene = self.scenes[sceneNmae]
	if logic_scene == nil then
	end
end = 1