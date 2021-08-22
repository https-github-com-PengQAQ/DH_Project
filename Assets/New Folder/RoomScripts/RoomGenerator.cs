using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace Map
{
    [Hotfix]
    [LuaCallCSharp]
    [CSharpCallLua]
    public class RoomGenerator : MonoBehaviour
    {
        public enum Direction // 定义四个方向
        {
            up, down, left, right
        };
        public GameObject player; // 获得玩家位置
        public Room playeRoom; // 获得玩家所在房间
        public RoomIdentity roominfo; // 房间具体信息
        public Direction direction; // 方向
        [Header("房间信息")]
        public GameObject roomPrefab; // 房间预制体     
        public int roomNumber; // 总体房间数量
        public Color startColor, endColor;

        private int[,] MiniMap = new int[20, 20]; // 房间位置矩阵
        private int xposition = 10, yposition = 10;

        [Header("位置控制")]
        public Transform generatorPoint; // 小机器人
        public float xOffset; // x偏移量
        public float yOffset; // y偏移量
        public LayerMask roomLayer;

        public List<GameObject> theCloneRooms = new List<GameObject>();
        private int maxStep, max;

        public List<Room> rooms = new List<Room>(); // 存放房间
        public Dictionary<Vector2, Room> rooMap = new Dictionary<Vector2, Room>(); // 存放房间位置信息 

        public WallType wallType;
        public bool isFirstFloor = true;

        public RoomIdentity t;
        public RoomIdentity BoosRoom;

        public GameObject Rooms;

        [CSharpCallLua]
        public delegate void ChangeMap(Vector2 pos);

        [CSharpCallLua]
        public delegate void ChangeCameraPos(Vector2 pos);

        private void Start()
        {
            Rooms = new GameObject();
            Rooms.name = "Rooms";
        }
        public void SortMap(List<GameObject> r)
        {
            theCloneRooms = r;
            if(!isFirstFloor)
            {
                destroyRooms();
            }
                
            //MiniMap[xposition,yposition] = 1;
            for (int i = 0; i < roomNumber; i++)
            {
                ChangePointPos();
                Room ro = Instantiate(roomPrefab, generatorPoint.position, Quaternion.identity).GetComponent<Room>();
                ro.transform.SetParent(Rooms.transform);
                rooms.Add(ro);
                Vector2 pos = new Vector2(yposition, xposition);
                rooms[i].roomxPosition = yposition;
                rooms[i].roomyPosition = xposition;
                rooMap.Add(pos, rooms[i]);
            }

            //player.transform.position = rooms[0].transform.position;
            playeRoom = rooms[0];
            rooms[0].GetComponent<SpriteRenderer>().color = startColor;

            //endroom = rooms[0].gameObject;
            //.......final room.............
            foreach (var room in rooms)
            {
                roominfo = SetupRoom(room, room.transform.position);
                setRoomInfo(room, roominfo);
            }

            //生成Boss房
            t = Instantiate(theCloneRooms[15], new Vector3(999,999,0), Quaternion.identity).GetComponent<RoomIdentity>();
            t.transform.SetParent(Rooms.transform);
            
            BoosRoom = t;
            Debug.Log("哈哈哈哈哈哈：" +BoosRoom);
            isFirstFloor = false;
            //endroom.GetComponent<SpriteRenderer>().color = endColor;
        }

        public void destroyRooms()
        {
            rooms = new List<Room>();
            GameObject.Destroy(Rooms);
            Rooms = new GameObject();
            Rooms.name = "Rooms";
            rooMap = new Dictionary<Vector2, Room>();
            MiniMap = new int[20, 20];
            xposition = 10;
            yposition = 10;

        }
        void Update()
        {
            //switchRoom();
        }

        public void ChangePointPos()
        {
            direction = (Direction)UnityEngine.Random.Range(0, 4);
            do
            {
                switch (direction)
                {
                    case Direction.up:
                        generatorPoint.position += new Vector3(0, yOffset, 0);
                        xposition--;
                        MiniMap[xposition, yposition] = 1;
                        break;
                    case Direction.down:
                        generatorPoint.position += new Vector3(0, -yOffset, 0);
                        xposition++;
                        MiniMap[xposition, yposition] = 1;
                        break;
                    case Direction.left:
                        generatorPoint.position += new Vector3(-xOffset, 0, 0);
                        yposition--;
                        MiniMap[xposition, yposition] = 1;
                        break;
                    case Direction.right:
                        generatorPoint.position += new Vector3(xOffset, 0, 0);
                        yposition++;
                        MiniMap[xposition, yposition] = 1;
                        break;
                }
            } while (Physics2D.OverlapCircle(generatorPoint.position, 0.2f, roomLayer));

        }

        public RoomIdentity SetupRoom(Room newRoom, Vector3 roomPosition)
        {
            newRoom.room1 = Physics2D.OverlapCircle(roomPosition + new Vector3(0, yOffset, 0), 0.2f, roomLayer); // 上
            newRoom.room3 = Physics2D.OverlapCircle(roomPosition + new Vector3(0, -yOffset, 0), 0.2f, roomLayer);// 下
            newRoom.room4 = Physics2D.OverlapCircle(roomPosition + new Vector3(xOffset, 0, 0), 0.2f, roomLayer); // 右
            newRoom.room2 = Physics2D.OverlapCircle(roomPosition + new Vector3(-xOffset, 0, 0), 0.2f, roomLayer); // 左

            newRoom.UpdateRoom();

            switch (newRoom.doorNumber)
            {
                case 1:
                    if (newRoom.room1)
                    {
                        //Instantiate(theCloneRooms[14], roomPosition, Quaternion.identity);
                        //Instantiate(wallType.WallU, roomPosition, Quaternion.identity);
                        t = Instantiate(theCloneRooms[14], roomPosition, Quaternion.identity).GetComponent<RoomIdentity>();
                        t.transform.SetParent(Rooms.transform);
                        return t;//Instantiate(theCloneRooms[14], roomPosition, Quaternion.identity).GetComponent<RoomIdentity>().transform.SetParent(Rooms.transform);
                    }
                    if (newRoom.room2)
                    {
                        //Instantiate(theCloneRooms[3], roomPosition, Quaternion.identity);
                        //Instantiate(wallType.WallL, roomPosition, Quaternion.identity);
                        t = Instantiate(theCloneRooms[3], roomPosition, Quaternion.identity).GetComponent<RoomIdentity>();
                        t.transform.SetParent(Rooms.transform);
                        return t;
                    }
                    if (newRoom.room3)
                    {
                        t = Instantiate(theCloneRooms[0], roomPosition, Quaternion.identity).GetComponent<RoomIdentity>();
                        t.transform.SetParent(Rooms.transform);
                        return t;
                    }
                    if (newRoom.room4)
                    {
                        t = Instantiate(theCloneRooms[11], roomPosition, Quaternion.identity).GetComponent<RoomIdentity>();
                        t.transform.SetParent(Rooms.transform);
                        return t;
                    }
                    break;
                case 2:
                    if (newRoom.room1 && newRoom.room2)
                    {
                        t = Instantiate(theCloneRooms[9], roomPosition, Quaternion.identity).GetComponent<RoomIdentity>();
                        t.transform.SetParent(Rooms.transform);
                        return t;
                    }
                    if (newRoom.room2 && newRoom.room4)
                    {
                        t = Instantiate(theCloneRooms[5], roomPosition, Quaternion.identity).GetComponent<RoomIdentity>();
                        t.transform.SetParent(Rooms.transform);
                        return t;
                    }
                    if (newRoom.room2 && newRoom.room3)
                    {
                        t = Instantiate(theCloneRooms[4], roomPosition, Quaternion.identity).GetComponent<RoomIdentity>();
                        t.transform.SetParent(Rooms.transform);
                        return t;
                    }
                    if (newRoom.room1 && newRoom.room4)
                    {
                        t = Instantiate(theCloneRooms[12], roomPosition, Quaternion.identity).GetComponent<RoomIdentity>();
                        t.transform.SetParent(Rooms.transform);
                        return t;
                    }
                    if (newRoom.room1 && newRoom.room3)
                    {
                        t = Instantiate(theCloneRooms[2], roomPosition, Quaternion.identity).GetComponent<RoomIdentity>();
                        t.transform.SetParent(Rooms.transform);
                        return t;
                    }
                    if (newRoom.room3 && newRoom.room4)
                    {
                        t = Instantiate(theCloneRooms[1], roomPosition, Quaternion.identity).GetComponent<RoomIdentity>();
                        t.transform.SetParent(Rooms.transform);
                        return t;
                    }
                    break;
                case 3:
                    if (!newRoom.room1)
                    {
                        t = Instantiate(theCloneRooms[6], roomPosition, Quaternion.identity).GetComponent<RoomIdentity>();
                        t.transform.SetParent(Rooms.transform);
                        return t;
                    }
                    if (!newRoom.room2)
                    {
                        t = Instantiate(theCloneRooms[13], roomPosition, Quaternion.identity).GetComponent<RoomIdentity>();
                        t.transform.SetParent(Rooms.transform);
                        return t;
                    }
                    if (!newRoom.room3)
                    {
                        t = Instantiate(theCloneRooms[8], roomPosition, Quaternion.identity).GetComponent<RoomIdentity>();
                        t.transform.SetParent(Rooms.transform);
                        return t;
                    }
                    if (!newRoom.room4)
                    {
                        t = Instantiate(theCloneRooms[10], roomPosition, Quaternion.identity).GetComponent<RoomIdentity>();
                        t.transform.SetParent(Rooms.transform);
                        return t;
                    }
                    break;
                case 4:
                    t = Instantiate(theCloneRooms[7], roomPosition, Quaternion.identity).GetComponent<RoomIdentity>();
                    t.transform.SetParent(Rooms.transform);
                    return t;
                    break;

            }
            return null;
        }

        public void setRoomInfo(Room room, RoomIdentity rinfo)
        {
            room.roomInfo = rinfo;
        }

        public void switchRoom(string doorName)
        {
            player = GameObject.Find("Player(Clone)");
            if (player == null)
                player = GameObject.Find("GunPlayer(Clone)");
            Vector2 pos;
            pos.x = playeRoom.roomxPosition;
            pos.y = playeRoom.roomyPosition;

            Vector3 nextPos;
            if (doorName == "Pos1")
            {
                pos.y -= 1;
                //Transform parent = rooMap[pos].roomInfo.pos3.transform.parent;
                nextPos = rooMap[pos].roomInfo.pos3.transform.position;
                playeRoom = rooMap[pos];

                player.transform.position = nextPos + new Vector3(1, 0, 0);
            }
            else if (doorName == "Pos2")
            {
                pos.x -= 1;
                //Transform parent = rooMap[pos].roomInfo.pos4.transform.parent;
                nextPos = rooMap[pos].roomInfo.pos4.transform.position;
                playeRoom = rooMap[pos];
                player.transform.position = nextPos - new Vector3(1, 0, 0);
            }
            else if (doorName == "Pos3")
            {
                pos.y += 1;
                //Transform parent = rooMap[pos].roomInfo.pos1.transform.parent;
                nextPos = rooMap[pos].roomInfo.pos1.transform.position;
                playeRoom = rooMap[pos] ;
                player.transform.position = nextPos - new Vector3(1, 0, 0);
            }
            else
            {
                pos.x += 1;
                //Transform parent = rooMap[pos].roomInfo.pos2.transform.parent;
                nextPos = rooMap[pos].roomInfo.pos2.transform.position;
                playeRoom = rooMap[pos];
                player.transform.position = nextPos + new Vector3(1, 0, 0);
            }
            Debug.Log(pos);
            Debug.Log(LuaBehaviour.luaEnv);
            LuaBehaviour.luaEnv.DoString("require(\"framework.GameManager\")");
            
            ChangeMap a = LuaBehaviour.luaEnv.Global.Get<ChangeMap>("ChangeMap");
            ChangeCameraPos b = LuaBehaviour.luaEnv.Global.Get<ChangeCameraPos>("CameraSetPos");
            a(pos);
            b(pos);
        }
    }
    [System.Serializable]
    public class WallType
    {
        public RoomIdentity WallL, WallR, WallU, WallD,
                        WallLR, WallLU, WallLD, WallUR, WallUD, WallRD,
                        WallLUR, WallLUD, WallURD, WallLRD,
                        WallALL, Boss;
    }
}