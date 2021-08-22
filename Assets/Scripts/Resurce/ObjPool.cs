using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace Pool
{
    [Hotfix]
    [LuaCallCSharp]
    public class ObjPool : Singleton<ObjPool>
    {
        private static GameObject poolParent;
        private Dictionary<string, List<GameObject>> pool = new Dictionary<string, List<GameObject>>();
        public override void Init()
        {
            poolParent = new GameObject();
            poolParent.name = "Pool";
            poolParent.SetActive(false);
            GameObject.DontDestroyOnLoad(poolParent);
        }

        // Start is called before the first frame update
        void Start()
        {

        }
       

        /// <summary>
        /// 进池
        /// </summary>
        public void InPool(GameObject obj)
        {
            //如果在对象池中就直接返回
            if (obj.transform.parent == poolParent.transform)
                return;
            //不存在就加入到池中,同名的是一个列表
            if (!pool.ContainsKey(obj.name))
                pool.Add(obj.name, new List<GameObject>());
            obj.transform.SetParent(poolParent.transform);
            pool[obj.name].Add(obj);

        }

        /// <summary>
        /// 出池
        /// </summary>
        /// <param name="objName">需要使用的Obj的名</param>
        /// <param name="path">返回一个实例化的物体</param>
        /// <returns></returns>
        public GameObject OutPool(string objName, string path = null)
        {
            //if (path != null)
                //path += "/";
            //else
                //return null;
            //如果池中没有,直接向资源管理器要
            if (!pool.ContainsKey(objName))
            {
                //资源加载，要替换
                GameObject obj = Resources.Load(path + objName) as GameObject;
                obj.name = objName;
                return obj;
            }
            //如果池中有
            else
            {
                GameObject obj = pool[objName][0];
                //pool[objName].RemoveAt(0);
                obj.transform.SetParent(null);
                return obj;
            }
        }
        /// <summary>
        /// 清池，直接清除对象池的节点，所有对象都在其下面，可以直接清除
        /// </summary>
        public void OnDestroy()
        {
            pool.Clear();
            GameObject.Destroy(poolParent.gameObject);
        }
    }
}