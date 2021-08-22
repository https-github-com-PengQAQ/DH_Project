using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : EnemyBase,IMotionInterfaces
{
    public float atance = 10f;
    bool isAttack;
    Vector3 front;
    Vector3 down;
    float x;
    
    /// <summary>
    /// 怪物初始化
    /// 
    /// </summary>
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isAttack = false;
        life = 3;
        speed = 1;
        attackRadius = 4f;
        front = new Vector3(1, 0, 0);
        down = new Vector3(0, -1, 0);
        x = transform.localScale.x;
    }

    protected override void idle()
    {
        
        /*
        Vector3 beg = transform.position + new Vector3(0, -0.1f, 0);
        
        Debug.DrawLine(beg, beg + front * 0.2f, Color.red);
        if(Physics2D.Raycast(beg, front, 0.2f, LayerMask.GetMask("Ground")))
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        Debug.DrawLine(beg, beg + (front + down).normalized * 0.5f);
        if (!Physics2D.Raycast(beg, front+down, 0.5f, LayerMask.GetMask("Ground")))
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        rigid.velocity = new Vector2(front.x * speed, rigid.velocity.y);
        Debug.DrawLine(beg, beg - down * 2.5f);
        
        if(Vector3.Distance(transform.position,Global.Player.transform.position)<= attackRadius && isAttack == false)
        {
            isAttack = true;
            StartCoroutine( Action());
        }
        if(transform.localScale.x * x < 0)
        { 
            front *= -1;
        }
        x = transform.localScale.x;
        */
    }

    /// <summary>
    /// 每个怪的攻击
    /// </summary>
    protected override IEnumerator Action()
    {
        /*
        animator.SetBool("isAttack", true);
        yield return new WaitForSeconds(0.5f);
        Vector3 dir = Global.Player.transform.position - transform.position;
        dir = dir.normalized;
        rigid.gravityScale = 0;
        rigid.AddForce(dir*200f , ForceMode2D.Force);
        yield return new WaitForSeconds(2f);
        isAttack = false;
        animator.SetBool("isAttack", false);
        rigid.gravityScale = 1;
        */
        yield return null;
    }

    private void Update()
    {
        if(!isAttack)
            idle();
    }
    public void Dead()
    {
        animator.SetTrigger("Dead");

    }
    public void isAlive()
    {

    }
}
