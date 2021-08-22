using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : EnemyBase
{
    /*
    public float minRadius = 3f;
    private void Start()
    {
        speed = 2f;
    }
    protected override void idle()
    {
        if(transform.position.x > Global.Player.transform.position.x)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        if(Vector3.Distance(transform.position, Global.Player.transform.position) >= minRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, Global.Player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            StartCoroutine(Action());
        }
    }

    protected override IEnumerator Action()
    {
        return base.Action();
    }

    protected override void hurt()
    {
        base.hurt();
    }
    private void Update()
    {
        idle();
    }
    public void Dead()
    {
        throw new System.NotImplementedException();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    */
}
