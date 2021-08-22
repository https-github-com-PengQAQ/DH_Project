using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
[Hotfix]

public class toBossRoom : MonoBehaviour
{

    [CSharpCallLua]
    private delegate void toBossFun();
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && collision.CompareTag("Player"))
        {
            toBossFun a = LuaBehaviour.luaEnv.Global.Get<toBossFun>("ToBossRoom");
            a();
        }
    }
}
