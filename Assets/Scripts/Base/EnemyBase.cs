using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public static int life;
    public static float speed;
    public static float attackSpeed;
    public static float attackRadius;
    public Rigidbody2D rigid;
    public Animator animator;

    private void Start()
    {
        
    }
    protected virtual void idle()
    {

    }

    protected virtual void hurt()
    {

    }
    public void Filp()
    {
        Vector3 front = new Vector3(-1, 0, 0);
        
    }

    protected virtual IEnumerator Action()
    {
        yield return null;
    }
}
public interface IMotionInterfaces
{
    void Dead();
}
