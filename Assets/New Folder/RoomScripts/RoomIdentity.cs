using Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
[Hotfix]
[LuaCallCSharp]
public class RoomIdentity : MonoBehaviour
{

    public GameObject pos1=null,pos2=null,pos3=null,pos4=null; // 1 → 3  2——4
    public Transform startPos;          //出生点
    public PlatformEffector2D pe;
    // public Transform[] MonsterPos; // 怪物生成点
    // public Transform[] Items; // 血药生成点 
    //public GameObject door1 , door2 , door3 , door4; // 关卡门

    public Transform up, down, right, left;   //相机限制点
    public GameObject[] doors;
    public int bo = 2;         //怪物生成的波数
    public int localCount;      //当前怪物死亡个数
    public bool isFirst; // 是否为第一次进入房间
    public int flag;    //房间属性(0:战斗房，1:道具房，2:Boss房）
    public Transform propPos;   //道具生成点，或者Boss生成点

    public int count;       //要死的怪物总数
    public GameObject[] enemyGroundPos;
    public GameObject[] enemyFlyPos;

    public GameObject[] enemyGround;
    public GameObject[] enemyFly;

    
    public List<GameObject> enemyList;
    public GameObject Boss;

    void Start()
    {
        // Instantiate Monsters

        isFirst = true;
        localCount = 0;
        count = bo * enemyGroundPos.Length;
        if (Boss != null)
            count = 1;
        
    }
    /// <summary>
    /// 进入下一层需要初始化
    /// </summary>
    public void init()
    {

    }
    
    void Update()
    {

    }

    /// <summary>
    /// 当前房间游戏开始
    /// </summary>
    public void mapGameStart()
    {
        isFirst = false;
        Debug.Log("tttttttttttttttttttttt");
        if (flag == 0)  //怪物房
        {
            doorOpenOrClose(true);
            StartCoroutine( enemyInstance());
        }
        else if(flag == 1)  //道具房
        {
            mapGameEnd();
        }
        else//Boss房
        {
            bossInstance();
        }
            
    }

    /// <summary>
    /// 当前房间游戏结束
    /// </summary>
    public void mapGameEnd()
    {
        //开门
        if(flag == 0)
            doorOpenOrClose(false);
        //道具房就生成道具
        if (flag == 1)
        {
            doorOpenOrClose(false);
            propInstance();
        }
        if (flag == 2)
        {
            toNextFloor();
        }
            
       

    }

    /// <summary>
    /// 开关门
    /// </summary>
    /// <param name="flag"></param>
    public void doorOpenOrClose(bool flag)
    {
        Debug.Log("openDoor");
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].gameObject.SetActive(flag);
        }
    }


    /// <summary>
    /// 怪物生成
    /// </summary>
    IEnumerator enemyInstance()
    {
        Debug.Log("enemyInstance");
        for(int j=0;j<bo;j++)
        {
            //生成地面怪物
            for(int i=0;i<enemyGroundPos.Length;i++)
            {
                GameObject obj =  Instantiate(enemyGround[0], enemyGroundPos[i].transform);
                enemyList.Add(obj);
            }

            //生成天上怪物
            for(int i=0;i<enemyFlyPos.Length;i++)
            {
                GameObject obj = Instantiate(enemyFly[0], enemyFlyPos[i].transform);
                enemyList.Add(obj);
            }

            yield return new WaitForSeconds(10f);
        }
        
    }

    /// <summary>
    /// 道具生成
    /// </summary>
    public void propInstance()
    {
        //Instantiate(p, propPos);
    }

    /// <summary>
    /// Boss生成
    /// </summary>
    public void bossInstance()
    {
        Debug.Log("bossInstance");
        Debug.Log(this.propPos);
        GameObject obj = Instantiate(Boss,this.propPos);
        obj.transform.position = this.propPos.position;
        Debug.Log(obj.transform.parent.transform.parent);
        
    }

    /// <summary>
    /// 打完boss，生成去下一层的传送门
    /// </summary>
    public void toNextFloor()
    {
        Debug.Log("tonextFloor");
        //Instantiate(p, propPos);
        //GameObject.Find("RoomGenerate").GetComponent<RoomGenerator>().SortMap();
    }
}
