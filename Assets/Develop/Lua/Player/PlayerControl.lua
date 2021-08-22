


PlayerCon = {name = "PlayerCon"}

local PlayerControl = BaseClass("PlayerControl", Player)
local  this = PlayerControl

local rigibody
local inputEnable
local animator 
local isGround
local gravityEnable
local attack
local feet
local jumpState
local nowDir = 0
local transform
local ray
function PlayerCon:Awake(self)
	-- body
	rigibody = self:GetComponent(typeof(UE.Rigidbody2D))
	animator = self:GetComponent(typeof(UE.Animator))
	feet = UE.GameObject.Find("MyFeet"):GetComponent(typeof(UE.CapsuleCollider2D))
	LogUtils.info(feet)
	transform = self:GetComponent(typeof(UE.Transform))

	inputEnable = true
	isGround = true
	jumpState = false
	speed = 10
	life = 1
	jumpCount = 2
	jumpPower = 2
    attack = 1
end


function PlayerCon:Update(self)
	-- body
	PlayerControl:LRMove()
	PlayerControl:Jump()
	PlayerControl:Attack()
	PlayerControl:Filp()
	PlayerControl:UpdateAnimatorState()
	PlayerControl:test()
end

function PlayerControl:test()
	if UE.Input.GetKeyDown(UE.KeyCode.O) then
		local ob1 = ObjPool:OutPool("Spider")
		local ob2 = ObjPool:OutPool("Spider")
		if ob1 == ob2 then
			LogUtils.info("true")
		end
		--LogUtils.info(ob1 == ob2)
		--ob.transform.position = UE.GameObject.Find("Player").transform.position
	end
end

function PlayerControl:Attack()
	-- body
	if UE.Input.GetKey(UE.KeyCode.K) then
		animator:SetBool("isAttack",true)
	else
		animator:SetBool("isAttack",false)
	end


end


function PlayerControl:Jump()
	-- body
	if inputEnable == false then
		return nil
	end
	if UE.Input.GetKeyDown(UE.KeyCode.Space) then
		local jumpVel = jumpPower
		if isGround == true then
			rigibody.velocity = UE.Vector2(rigibody.velocity.x,jumpVel)
		elseif jumpCount > 1 then
			rigibody.velocity = UE.Vector2(rigibody.velocity.x,jumpVel)
			jumpCount = jumpCount-1
		end

		UISubject:Notify({1,-20})
	end
end



--左右移动
function PlayerControl:LRMove()
	-- body
	if inputEnable == false then
		return nil
	end
	local moveDir = UE.Input.GetAxis("Horizontal")

	local Vector2 = UE.Vector2
	local playerVel = {moveDir * speed, rigibody.velocity.y}

	rigibody.velocity = UE.Vector2(playerVel[1],playerVel[2])

	local  playerHasXAxisSpeed = UE.Mathf.Abs(rigibody.velocity[0]) > UE.Mathf.Epsilon
	animator:SetBool("isWalk",playerHasXAxisSpeed)

end

--转向
function PlayerControl:Filp()
	-- body
	local playerHasXAxisSpeed = UE.Mathf.Abs(rigibody.velocity.x) > UE.Mathf.Epsilon;
	if playerHasXAxisSpeed == true then
		if rigibody.velocity.x < -UE.Mathf.Epsilon then
			
			transform.localRotation = UE.Quaternion.Euler(0, 180, 0)
			noDir = 1
		else
			transform.localRotation = UE.Quaternion.Euler(0, 0, 0)
			noDir = 0
		end
	end

end

--
function PlayerControl:UpdateAnimatorState()
	-- body

	isGround = feet:IsTouchingLayers(LayerMask.GetMask("Ground"))
	
	if isGround == true then
		jumpCount = 2
		animator:SetBool("isJump", false)
	else
		animator:SetBool("isJump", true)
	end
	animator:SetBool("isGround",isGround)

end

function PlayerCon:ctor(obj)
    local o = {}
    setmetatable(o,self)
    self.__index = self
    return o
end