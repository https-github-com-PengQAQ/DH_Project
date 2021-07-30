using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum PlayDir
{
	Left = 1,
	Right,
}

public class PlayerControl : MonoBehaviour
{


	public Rigidbody2D myRigidody;
	public float speed;         //速度
	public Vector3 moveSpeed;   //每一帧的移动速度
	public bool inputEnable;    //接受输入开关
	public Animator myAnimator; //动画
	public bool isGround;       //是否在地面
	public BoxCollider2D myFeet;
	public int jumpCount = 2;   //跳跃次数
	public bool jumpState;      //跳跃状态
	public float jumpPower;     //跳跃力
	public bool gravityEnable;  //重力开关
	public float rushtime;      //冲刺时间
	public bool isCanRush;      //冲刺开关
	public PlayDir nowDir;      //玩家现在的方向
	public GameObject attack;
								// Use this for initialization
	void Start()
	{
		myRigidody = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator>();
		myFeet = GetComponent<BoxCollider2D>();

		nowDir = PlayDir.Left;
		gravityEnable = true;
		inputEnable = true;
		isGround = true;
		jumpState = false;
		isCanRush = true;
	}

	// Update is called once per frame
	void Update()
	{
		LRMove();
		UpdateAnimatorState();
		Filp();
		Jump();
		Attack();
		//CheckGround();
		//Rush();
		UpdateGravity();

	}
	/// <summary>
	/// 重力更新
	/// </summary>
	void UpdateGravity()
	{
		if (!gravityEnable)
		{
			myRigidody.gravityScale = 0;
		}
		else
			myRigidody.gravityScale = 1;

	}
	public void Attack()
	{
		if (!inputEnable)
		{
			return;
		}
		if (Input.GetKeyDown(InputManager.Instance.attackKey))
		{
			myAnimator.SetBool("isAttack", true);
			attack.SetActive(true);
		}

	}
	/// <summary>
	/// 左右移动
	/// </summary>
	public void LRMove()
	{
		if (!inputEnable)
		{
			return;
		}

		float moveDir = Input.GetAxis("Horizontal");
		Vector2 playerVel = new Vector2(moveDir * speed, myRigidody.velocity.y);
		myRigidody.velocity = playerVel;


		bool playerHasXAxisSpeed = Mathf.Abs(myRigidody.velocity.x) > Mathf.Epsilon;

		myAnimator.SetBool("isWalk", playerHasXAxisSpeed);

	}

	/// <summary>
	/// 翻转并更新方向
	/// </summary>
	public void Filp()
	{
		bool playerHasXAxisSpeed = Mathf.Abs(myRigidody.velocity.x) > Mathf.Epsilon;
		if (playerHasXAxisSpeed)
		{
			if (myRigidody.velocity.x < -Mathf.Epsilon)
			{
				transform.localRotation = Quaternion.Euler(0, 180, 0);
				nowDir = PlayDir.Left;
			}

			if (myRigidody.velocity.x > Mathf.Epsilon)
			{
				transform.localRotation = Quaternion.Euler(0, 0, 0);
				nowDir = PlayDir.Right;
			}

		}
	}

	/// <summary>
	/// 跳跃
	/// </summary>
	void Jump()
	{
		if (!inputEnable)
		{
			return;
		}

		if (Input.GetKeyDown(InputManager.Instance.jumpKey))
		{
			Vector2 jumpVel = new Vector2(0.0f, jumpPower);

			if (isGround)
			{
				myRigidody.velocity = Vector2.up * jumpVel;
			}
			else if (jumpCount > 1)
			{
				myRigidody.velocity = Vector2.up * jumpVel;
				jumpCount--;
			}
		}

		//松开按键施加一个力将其按下
		if (Input.GetKeyUp(InputManager.Instance.jumpKey))
		{
			if (!isGround && myRigidody.velocity.y > Mathf.Epsilon && gravityEnable)
			{
				Vector2 jumpVel = new Vector2(0.0f, -1);
				myRigidody.velocity = Vector2.up * jumpVel;
			}
		}
	}

	/// <summary>
	/// 检测是否重新回到地面
	/// </summary>
	void CheckGround()
	{
		isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
		Debug.Log(isGround);
		if (isGround)   //重置跳跃
		{
			jumpCount = 2;
		}
		myAnimator.SetBool("isGround", isGround);

	}


	/// <summary>
	/// 冲刺函数
	/// </summary>
	void Rush()
	{
		if (!inputEnable)
		{
			return;
		}

		if (Input.GetKeyDown(InputManager.Instance.sprintKey) && isCanRush)
		{
			StartCoroutine(RushMove(rushtime));
			myAnimator.SetTrigger("IsRush");
			isCanRush = false;
		}
	}

	/// <summary>
	/// 冲刺携程
	/// </summary>
	IEnumerator RushMove(float time)
	{
		inputEnable = false;
		gravityEnable = false;
		myRigidody.velocity = new Vector2(myRigidody.velocity.x, 0);        //在Y方向的速度置为0
		if (nowDir == PlayDir.Left)         //方向向左时向左冲刺
		{
			myRigidody.velocity = new Vector2(speed, 0);
		}
		if (nowDir == PlayDir.Right)            //方向向右时向右冲刺
		{
			myRigidody.velocity = new Vector2(-speed, 0);
		}

		yield return new WaitForSeconds(time);
		inputEnable = true;
		gravityEnable = true;
	}

	void UpdateAnimatorState()
	{
		isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
        if (isGround == false)
        {
			;
		}

        if (isGround)   //重置跳跃
		{
			jumpCount = 2;
		}
		myAnimator.SetBool("isGround", isGround);
		if (isGround)
		{
			isCanRush = true;
			myAnimator.SetBool("isJump", false);
			//myAnimator.SetBool("IsRush", false);
		}
		else
		{
			myAnimator.SetBool("isJump", true);
		}
	}
	public void fun()
	{
		myAnimator.SetBool("isAttack", false);
		attack.SetActive(false);
	}
}
