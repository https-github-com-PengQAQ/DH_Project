using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Map;
using XLua;
public class ToNextRoom : MonoBehaviour
{
    //public ToNextRoom[] nextPosList;
    private bool isCanCollided = true;
    private void Start()
    {
        
    }

    private void LateUpdate()
    {
        isCanCollided = true;
    }
    [CSharpCallLua]
    private void OnTriggerEnter2D(Collider2D other)
    {

        if ((other.name == "Player(Clone)" || other.name == "GunPlayer(Clone)") && isCanCollided)
        {
            //GameObject.Find("Canvas").gameObject.transform.Find("Through").gameObject.SetActive(true);

            //nextPosList = Object.FindObjectsOfType<ToNextRoom>();
            GameObject.Find("RoomGenerate").GetComponent<RoomGenerator>().switchRoom(this.name);
                isCanCollided = false;
        }
    }
    


}

