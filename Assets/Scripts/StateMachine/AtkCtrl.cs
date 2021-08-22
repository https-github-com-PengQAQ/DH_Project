using BulletHell;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
[Hotfix]
public class AtkCtrl : MonoBehaviour
{
    public FSM Enemy;
    List<int> list = new List<int>();
    [CSharpCallLua]
    public delegate void hit(List<int> l);
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player" || other.name == "Player(Clone)")
        {
            if(other.GetComponent<PlayerController>().getDefence())
            {
                Enemy.GetHit(Vector2.right);
            }else{
                hit a = LuaBehaviour.luaEnv.Global.Get<hit>("act");
                list.Add(0);
                list.Add(-1);
                a(list);
                list.Clear();
                //LuaBehaviour.luaEnv.DoString("UISubject:Notify({102,2})");
                other.GetComponent<PlayerController>().GetHit();
            }
        }
        if (other.name == "GunPlayer" || other.name == "GunPlayer(Clone)")
        {

            hit a = LuaBehaviour.luaEnv.Global.Get<hit>("act");
            list.Add(0);
            list.Add(-1);
            a(list);
            list.Clear();
            //LuaBehaviour.luaEnv.DoString("UISubject:Notify({102,2})");
            other.GetComponent<PlayerMovement>().GetHit();
        }

    }
}
