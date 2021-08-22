using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XLua;

namespace Scene
{
    [Hotfix]
    [LuaCallCSharp]
    public class SceneMgr : MonoBehaviour
    {
        //本类实例
        private static SceneMgr _Instance;

        
        public static SceneMgr GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new GameObject("_SceneMgr").AddComponent<SceneMgr>();
            }
            return _Instance;
        }
        public void TurnScene()
        {
            SceneManager.LoadScene(2, LoadSceneMode.Additive);

        }
    }
}


