using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    public GameObject Door1,Door2,Door3,Door4; // 传送门

    public bool room1,room2,room3,room4; // 判断四个方向是否有房间

    public int doorNumber; // 周围房间数量

    public int stepToStart; // 到起始房间的步数
    
    public int roomxPosition; // 房间x坐标
    public int roomyPosition; // 房间y坐标

    public RoomIdentity roomInfo;
    
    void Start()
    {
        
    }

   
    public void UpdateRoom()
    {
        if(room1)
            doorNumber ++;
        if(room2)
            doorNumber ++;
        if(room3)
        doorNumber ++;
        if(room4)
            doorNumber ++;
    }
}
