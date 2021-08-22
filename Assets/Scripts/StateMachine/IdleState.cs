using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using static IdleState;

[Hotfix]
public class IdleState : IState
{
    private FSM manager;
    private Parameter parameter;

    private float timer;

    [CSharpCallLua]
    public delegate void enemyDeadOne(string name);
    public IdleState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("Idle");
    }

    public void OnUpdate()
    {
        timer += Time.deltaTime;

        if (parameter.getHit)
        {
            manager.TransitionState(StateType.Hit);
        }
        if (parameter.target != null) //&&
            // parameter.target.position.x >= parameter.ChaPoint1&&
            // parameter.target.position.x <= parameter.ChaPoint2)
        {
            manager.TransitionState(StateType.React);
        }
        if (timer >= parameter.idleTime)
        {
            manager.TransitionState(StateType.Patrol);
        }
    }

    public void OnExit()
    {
        timer = 0;
    }
}

public class PatrolState : IState
{
    private FSM manager;
    private Parameter parameter;
    // private Vector3 front = new  Vector3(1,0,0);
    // private Vector3 down = new Vector3(0,-1,0);
    private Vector3 beg;
    // private int patrolPosition;
    private float x = 1;

    public PatrolState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
        
    }
    public void OnEnter()
    {
        parameter.animator.Play("Walk");
        //parameter.FaceRight = true;
    }

    public void OnUpdate()
    {
        beg = manager.transform.position;
        parameter.rigidbody.velocity = new Vector2(manager.transform.localScale.x * parameter.moveSpeed,parameter.rigidbody.velocity.y);
        Debug.DrawLine(beg, beg + (parameter.front + parameter.down)*5f ,Color.red);
        if (!Physics2D.Raycast(beg, parameter.front + parameter.down,5f, LayerMask.GetMask("Ground")))
        {
            manager.transform.localScale = new Vector3(manager.transform.localScale.x * -1,manager.transform.localScale.y, manager.transform.localScale.z);
            parameter.front *= -1;
        }
        Debug.DrawLine(beg, beg + parameter.front * 1f, Color.red);
        if (Physics2D.Raycast(beg, parameter.front, 1f, LayerMask.GetMask("Ground")))
        {
            manager.transform.localScale = new Vector3(manager.transform.localScale.x * -1, manager.transform.localScale.y, manager.transform.localScale.z);
            parameter.front *= -1;
        }
        
        // manager.FlipTo(parameter.patrolPoints[patrolPosition]);

        // manager.transform.position = Vector2.MoveTowards(manager.transform.position,
        //     parameter.patrolPoints[patrolPosition].position, parameter.moveSpeed * Time.deltaTime);

        // if(parameter.FaceRight)
        // {
        //     parameter.rigidbody.velocity = new Vector2(parameter.moveSpeed,parameter.rigidbody.velocity.y);
        //     if(manager.transform.position.x > parameter.PatPoint2)
        //     {
        //         manager.transform.localScale = new Vector3(-1,1,1);
        //         parameter.FaceRight = false;
        //     }
        // }
        // else
        // {
        //     parameter.rigidbody.velocity = new Vector2(-parameter.moveSpeed,parameter.rigidbody.velocity.y);
        //     if(manager.transform.position.x < parameter.PatPoint1)
        //     {
        //         manager.transform.localScale = new Vector3(1,1,1);
        //         parameter.FaceRight = true;
        //     }
        // }

        if (parameter.getHit)
        {
            manager.TransitionState(StateType.Hit);
        }
        if (parameter.target != null) //&&
            // parameter.target.position.x >= parameter.ChaPoint1 &&
            // parameter.target.position.x <= parameter.ChaPoint2)
        {
            manager.TransitionState(StateType.React);
        }
        // if (manager.transform.position.x - parameter.PatPoint1 < .1f)
        // {
        //      manager.TransitionState(StateType.Idle);
        // }
        // if (parameter.PatPoint2 - manager.transform.position.x < .1f)
        // {
        //      manager.TransitionState(StateType.Idle);
        // }
    }

    public void OnExit()
    {
        // patrolPosition++;

        // if (patrolPosition >= parameter.patrolPoints.Length)
        // {
        //     patrolPosition = 0;
        // }
    }
}

public class ChaseState : IState
{
    private FSM manager;
    private Parameter parameter;

    public ChaseState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("Walk");
    }

    public void OnUpdate()
    {
        manager.FlipTo(parameter.target);

        if (parameter.target)
        {
            manager.transform.position = Vector2.MoveTowards(manager.transform.position,
            parameter.target.position, parameter.chaseSpeed * Time.deltaTime);
        }
        if(manager.transform.localScale.x < 0)
        {
            parameter.front = new Vector3(-1,0,0);
        }else
        {
            parameter.front = new Vector3(1,0,0);
        }

        if (parameter.getHit)
        {
            manager.TransitionState(StateType.Hit);
        }
        if (parameter.target == null)// ||
            // manager.transform.position.x < parameter.ChaPoint1 ||
            // manager.transform.position.x > parameter.ChaPoint2)
        {
            manager.TransitionState(StateType.Idle);
        }
        if (Physics2D.OverlapCircle(parameter.attackPoint.position, parameter.attackArea, parameter.targetLayer))
        {
            manager.TransitionState(StateType.Attack);
        }
    }

    public void OnExit()
    {

    }
}

public class ReactState : IState
{
    private FSM manager;
    private Parameter parameter;

    private AnimatorStateInfo info;
    public ReactState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("React");
    }

    public void OnUpdate()
    {
        info = parameter.animator.GetCurrentAnimatorStateInfo(0);

        if (parameter.getHit)
        {
            manager.TransitionState(StateType.Hit);
        }
        if (info.normalizedTime >= .95f)
        {
            manager.TransitionState(StateType.Chase);
        }
    }

    public void OnExit()
    {

    }
}

public class AttackState : IState
{
    private FSM manager;
    private Parameter parameter;

    private AnimatorStateInfo info;
    public AttackState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("Attack");
    }

    public void OnUpdate()
    {
        info = parameter.animator.GetCurrentAnimatorStateInfo(0);
        if (parameter.getHit)
        {
            manager.TransitionState(StateType.Hit);
        }
        if (info.normalizedTime >= .95f)
        {
            manager.TransitionState(StateType.Chase);
        }
    }

    public void OnExit()
    {

    }

}

public class HitState : IState
{
    private FSM manager;
    public Parameter parameter;

    private AnimatorStateInfo info;
    public HitState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("Hit");
        parameter.health--;
    }

    public void OnUpdate()
    {
        info = parameter.animator.GetCurrentAnimatorStateInfo(0);

        if (parameter.health <= 0)
        {
            manager.TransitionState(StateType.Death);
        }
        if (info.normalizedTime >= .95f)
        {
            parameter.target = GameObject.FindWithTag("Player").transform;

            manager.TransitionState(StateType.Chase);
        }
    }

    public void OnExit()
    {
        parameter.isHit = false;
        parameter.getHit = false;
    }
}

public class DeathState : IState
{
    private FSM manager;
    private Parameter parameter;

    public DeathState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        
        enemyDeadOne a = LuaBehaviour.luaEnv.Global.Get<enemyDeadOne>("enemyDeadOne");
        if (manager.name == "Boss" || manager.name == "Boss(Clone)")
            a("Boss");
        else
            a("notBoss");
        //a();
        

        parameter.animator.Play("Dead");
    }

    public void OnUpdate()
    {

    }

    public void OnExit()
    {
        parameter.animator.Play("Exit");
    }
}