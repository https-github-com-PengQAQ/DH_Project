using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace WaitForS
{

[Hotfix]
[LuaCallCSharp]
    public class Wait : MonoBehaviour
    {

        public void fun(float m)
        {
            Debug.Log("h213");
            StartCoroutine(WaitS(m));
            Vector3 a = new Vector3(0, 0, 0);
            transform.position =new Vector3(0, 0, 0);
            Time.timeScale = 0;
        }

        IEnumerator WaitS(float m)
        {
            yield return new WaitForSeconds(m);
            Debug.Log("hhh");
        }
    }
}