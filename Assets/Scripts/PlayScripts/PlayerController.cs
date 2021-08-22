using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("补偿速度")]
    public float lightSpeed;
    public float heavySpeed;
    public float SpSpeed;
    [Header("打击感")]
    public float shakeTime;
    public int lightPause;
    public float lightStrength;
    public int heavyPause;
    public float heavyStrength;
    public int SpPause;
    public float SpStrength;

    [Space]
    public float interval = 2f;
    private float timer,SlidingTimer,defenceTimer;
    private bool isAttack;
    private string attackType;
    private int comboStep;

    public float moveSpeed;
    public float slidingSpeed;
    public float jumpForce;
    new private Rigidbody2D rigidbody;
    private Animator animator;
    private float input;
    public bool isGround, Slidingflag , Invincible, isDefence , Defenceflag;
    public int heath;
    public GameObject player;
    public BoxCollider2D myFeet;


    [SerializeField] private LayerMask layer;

    [SerializeField] private Vector3 check;

    
    void Start()
    {
        isDefence = false;
        Invincible = false;
        Defenceflag = true;
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        //isGround = Physics2D.OverlapCircle(transform.position + new Vector3(check.x, check.y, 0), check.z, layer);
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
        animator.SetFloat("Horizontal", rigidbody.velocity.x);
        animator.SetFloat("Vertical", rigidbody.velocity.y);
        animator.SetBool("isGround", isGround);

        Move();
        Attack();
        Defence();

        if(Input.GetKeyDown(KeyCode.F))
        {
            rigidbody.gravityScale = 0;
            StartCoroutine(theLight());
        }
    }
    Vector3 foward;
    public GameObject lightning;
    //生成闪电
    IEnumerator theLight()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos = new Vector3(pos.x, pos.y, transform.position.z);
        Debug.Log(pos);
        Debug.Log(transform.position);
        Vector3 dir = (pos - transform.position).normalized;
        Debug.Log(dir);
        foward = new Vector3(1, 0, 0);
        float angle = Vector3.Angle(dir, foward) + 90;
        Quaternion qua = new Quaternion(0, 0, angle, 0);
        GameObject light = Instantiate(lightning);
        light.transform.position = transform.position;
        Vector3 lightNextPos = transform.position + dir * 0.5f;
        light.transform.position = lightNextPos;
        light.transform.rotation = Quaternion.Euler(0, 0, angle);

        StartCoroutine(updateMove(dir));
        yield return null;
    }
    Vector2 boxsize = new Vector2(0.05f, 0.05f);
    
    //逐帧位移
    IEnumerator updateMove(Vector3 dir)
    {
        //播放动画
        for(int i=0;i<10;i++)
        {
            float dis = 0.2f;
            Vector3 toNextPos = dir * dis + transform.position;
            Vector3 oripos = transform.position;
            transform.position = toNextPos;
            
            RaycastHit2D ir = Physics2D.BoxCast(transform.position, boxsize, 0, dir , 0.05f, 512);
            if(ir.collider != null)
            {
                Vector3 lastPos = transform.position - dir * dis;
                transform.position = lastPos;
                Debug.Log("8888888888888888888888888");
                break;
            }
            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(gra());
        yield return null;
        
    }

    IEnumerator gra()
    {
        yield return new WaitForSeconds(0.1f);
        rigidbody.gravityScale = 3;
    }
    void Move()
    {
        if (!isAttack)
            rigidbody.velocity = new Vector2(input * moveSpeed, rigidbody.velocity.y);
        else
        {
            if (attackType == "Light")
                rigidbody.velocity = new Vector2(transform.localScale.x * lightSpeed, rigidbody.velocity.y);
            else if (attackType == "Heavy")
            {
                Debug.Log("Heavy");
                rigidbody.velocity = new Vector2(transform.localScale.x * heavySpeed, rigidbody.velocity.y);
            }
                
            else if(attackType == "SP")
                rigidbody.velocity = new Vector2(transform.localScale.x * SpSpeed, rigidbody.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isGround)
        {
            rigidbody.velocity = new Vector2(0, jumpForce);
            animator.SetTrigger("Jump");
        }

        if(Input.GetKeyDown(KeyCode.O) && isGround && Slidingflag)
        {   
            Invincible = true;
            Slidingflag = false;
            SlidingTimer = interval;
            rigidbody.velocity = new Vector2(input * moveSpeed * 1.5f, rigidbody.velocity.y);
            animator.SetTrigger("Sliding");
        }
        if (SlidingTimer != 0)
        {
            SlidingTimer -= Time.deltaTime;
            if (SlidingTimer <= 0)
            {
                SlidingTimer = 0;
                Slidingflag = true;
            }
        }
        
        if (rigidbody.velocity.x < 0)
            transform.localScale = new Vector3(-0.5f, 0.5f, 1);
        else if (rigidbody.velocity.x > 0)
            transform.localScale = new Vector3(0.5f, 0.5f, 1);
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.J) && !isAttack)
        {
            isAttack = true;
            attackType = "Light";
            comboStep++;
            if (comboStep > 3)
                comboStep = 1;
            timer = interval;
            animator.SetTrigger("LightAttack");
            animator.SetInteger("ComboStep", comboStep);
        }
        if (Input.GetKeyUp(KeyCode.K) && !isAttack)
        {
            isAttack = true;
            attackType = "Heavy";
            comboStep++;
            if (comboStep > 3)
                comboStep = 1;
            timer = interval;
            animator.SetTrigger("HeavyAttack");
            animator.SetInteger("ComboStep", comboStep);
        }
        if (Input.GetKeyDown(KeyCode.L) && !isAttack)
        {
            isAttack = true;
            attackType = "SP";
            timer = interval;
            animator.SetTrigger("SPATK2");
            
        }


        if (timer != 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
                comboStep = 0;
            }
        }
    }

    public void AttackOver()
    {
        Debug.Log("over");
        isAttack = false;
        Debug.Log(isAttack);
    }

    public void GetHit()
    {
        if(Invincible)
        {

        }else
        {
            isAttack = false;

            animator.SetTrigger("Hurt");
            heath --;
        }
        
        if(heath <= 0 )
        {
            animator.SetTrigger("Die");
        }
    }

    void Defence()
    {
        if(Input.GetKeyDown(KeyCode.I) && Defenceflag)
        {
            isDefence = true;
            Defenceflag = false;
            animator.SetTrigger("Defence");
            defenceTimer = interval;
        }

        if(defenceTimer > 0)
        {
            defenceTimer -= Time.deltaTime;
            if(defenceTimer <= 0)
            {
                Defenceflag = true;
                defenceTimer = 0;
            }
        }
    }
    public void DefenceOver()
    {
        isDefence = false;
    }
    public bool getDefence()
    {
        return isDefence;
    }
    public void ToHell()
    {
        //Destroy(player);
    }

    public void CancelInvincible()
    {
        Invincible = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemyGround") || other.CompareTag("enemyFly") || other.CompareTag("Enemy"))
        {
            if (attackType == "Light")
            {
                //AttackSense.Instance.HitPause(lightPause);
                //AttackSense.Instance.CameraShake(shakeTime, lightStrength);
            }
            else if (attackType == "Heavy")
            {
                //AttackSense.Instance.HitPause(heavyPause);
                //AttackSense.Instance.CameraShake(shakeTime, heavyStrength);
            }
            else if(attackType == "SP")
            {
                //AttackSense.Instance.HitPause(SpPause);
                //AttackSense.Instance.CameraShake(shakeTime, SpStrength);
            }

            if (transform.localScale.x > 0)
                other.GetComponent<FSM>().GetHit(Vector2.right);
            else if (transform.localScale.x < 0)
                other.GetComponent<FSM>().GetHit(Vector2.left);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + new Vector3(check.x, check.y, 0), check.z);
    }
}