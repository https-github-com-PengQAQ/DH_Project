CameraFollow = {name = "CameraFollow"}
--CameraFollow = BaseClass("CameraFollow")
local  this = CameraFollow
local smooth
local pos 



local height
local width
function CameraFollow:Awake()
	-- body
	smooth = 50

	this.flag = true
	--
	MainCamera:GetComponent(typeof(UE.Camera)).orthographicSize = 2.5
	height = MainCamera:GetComponent(typeof(UE.Camera)).orthographicSize
	width = height * UE.Screen.width / UE.Screen.height
end
function CameraFollow:Update(self)
	-- body
	--LogUtils.info(this.flag)
	if this.flag == false then
		return
	end
	pos = UE.Vector3(Player.transform.position.x, Player.transform.position.y, MainCamera.transform.position.z)

	if pos ~= MainCamera.transform.position then
		pos.x =  UE.Mathf.Clamp(pos.x, this.left.position.x + width, this.right.position.x - width)
		pos.y = UE.Mathf.Clamp(pos.y, this.down.position.y + height, this.up.position.y - height)
		MainCamera.transform.position = UE.Vector3.Lerp(MainCamera.transform.position, pos, smooth)
	end

end


function CameraFollow.SetPos( room)
	-- body

	LogUtils.info(room)
	this.up = room.up
	this.down = room.down
	this.right = room.right
	this.left = room.left
	LogUtils.info(this.left.position.x)
end
function CameraFollow:ctor(obj)
    local o = {}
    setmetatable(o,self)
    self.__index = self
    return o
end