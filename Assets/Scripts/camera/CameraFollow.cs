using G;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
[Hotfix]
[LuaCallCSharp]
public class CameraFollow : MonoBehaviour
{
    public float smooth;    //摄像机平滑度
    Vector3 pos;
    public Transform minXPos = null;
    public Transform maxXPos = null;
    public Transform minYPos = null;
    public Transform maxYPos = null;

    private void Start()
    {
        Global.Player = GameObject.Find("Player");
        

    }
    private void Update()
    {
        Follow();
    }
    public void SetPos(RoomIdentity room)
    {
        minXPos = room.left;
        maxXPos = room.right;
        minYPos = room.down;
        maxYPos = room.up;
    }
    private void Follow()
    {
        pos = new Vector3(Global.Player.transform.position.x, Global.Player.transform.position.y, transform.position.z);
        if(pos != transform.position)
        {

            float height = GetComponent<Camera>().orthographicSize;
            float width = height * Screen.width / Screen.height;
            pos.x = Mathf.Clamp(pos.x, minXPos.position.x + width, maxXPos.position.x - width);
            pos.y = Mathf.Clamp(pos.y, minYPos.position.y + height, maxYPos.position.y - height);
            
            transform.position = Vector3.Lerp(transform.position, pos, smooth);
            
        }
    }
    
}
