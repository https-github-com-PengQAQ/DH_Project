﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
[Hotfix]
[LuaCallCSharp]
public enum StateType
{
    Idle, Patrol, Chase, React, Attack, Hit, Death
}

[Serializable]
public class Parameter
{
    public int health;
    public float moveSpeed;
    public float chaseSpeed;
    public float idleTime;
    //public Transform[] patrolPoints;
    //public Transform[] chasePoints;
    public Transform target;
    public LayerMask targetLayer;
    public Transform attackPoint;
    public float attackArea;
    public Animator animator;
    public bool getHit,isHit;
    public Rigidbody2D rigidbody;
    public Vector3 front,down;
}

public class FSM : MonoBehaviour
{

    private IState currentState;
    private Dictionary<StateType, IState> states = new Dictionary<StateType, IState>();
    public Parameter parameter;
    public GameObject obj;

    void Start()
    {

        states.Add(StateType.Idle, new IdleState(this));
        states.Add(StateType.Patrol, new PatrolState(this));
        states.Add(StateType.Chase, new ChaseState(this));
        states.Add(StateType.React, new ReactState(this));
        states.Add(StateType.Attack, new AttackState(this));
        states.Add(StateType.Hit, new HitState(this));
        states.Add(StateType.Death, new DeathState(this));

        TransitionState(StateType.Idle);

        parameter.front = new Vector3(1,0,0);
        parameter.down = new Vector3(0,-1,0);
       
        parameter.animator = transform.GetComponent<Animator>();
        parameter.animator.Play("Born");
    }

    void Update()
    {

        currentState.OnUpdate();

        if (parameter.isHit)
        {
            parameter.getHit = true;
        }
    }

    public void TransitionState(StateType type)
    {
        if (currentState != null)
            currentState.OnExit();
        currentState = states[type];
        currentState.OnEnter();
    }

    public void FlipTo(Transform target)
    {
        if (target != null)
        {
            if (transform.position.x > target.position.x)
            {

                transform.localScale = new Vector3(-0.5f, 0.5f, 1);
            }
            else if (transform.position.x < target.position.x)
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 1);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            parameter.target = other.transform;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            parameter.target = null;
        }
    }

     private void OnDrawGizmos()
     {
         Gizmos.DrawWireSphere(parameter.attackPoint.position, parameter.attackArea);
     }

    public void GetHit(Vector2 direction)
    {
        transform.localScale = new Vector3(-direction.x * 0.5f, 0.5f, 1);
        parameter.isHit = true;
    }

    public void Die()
    {
        Destroy(obj);
    }
}