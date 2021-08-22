/*
* Tencent is pleased to support the open source community by making xLua available.
* Copyright (C) 2016 THL A29 Limited, a Tencent company. All rights reserved.
* Licensed under the MIT License (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
* http://opensource.org/licenses/MIT
* Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
*/

using UnityEngine;
using System.Collections.Generic;
using XLua;
using System;
using UnityEngine.EventSystems;

public class LuaBehaviour : MonoBehaviour
{
    [HideInInspector] public List<string> luaScriptPathList = new List<string>();
    public List<UnityEngine.Object> injectionList = new List<UnityEngine.Object>();

    //用于挂载各种后台脚本
    internal static GameObject globalObject = null;

    public static LuaEnv luaEnv = null; //all lua behaviour shared one luaenv only!
    internal static float lastGCTime = 0;
    internal const float GCInterval = 1;//1 second
    internal static Dictionary<string, byte[]> luaScriptDict = new Dictionary<string, byte[]>();

    [HideInInspector] public List<string> luaRefPathList = new List<string>();
    [HideInInspector] public List<string> luaRefPathMd5List = new List<string>();
    [HideInInspector] public List<string> luaNumberKeyList = new List<string>();
    [HideInInspector] public List<float> luaNumberValueList = new List<float>();
    [HideInInspector] public List<string> luaUserdataKeyList = new List<string>();
    [HideInInspector] public List<string> luaUserdataTypeList = new List<string>();
    [HideInInspector] public List<UnityEngine.Object> luaUserdataValueList = new List<UnityEngine.Object>();

    private List<Action> luaStartList = new List<Action>();
    private List<Action> luaUpdateList = new List<Action>();
    private List<Action> luaFixedUpdateList = new List<Action>();
    private List<Action> luaLateUpdateList = new List<Action>();
    private List<Action> luaOnGUIList = new List<Action>();
    private List<Action> luaOnDisableList = new List<Action>();
    private List<Action> luaOnEnableList = new List<Action>();
    private List<Action> luaOnDestroyList = new List<Action>();
    private List<Action<bool>> luaOnApplicationFocusList = new List<Action<bool>>();
    private List<Action<bool>> luaOnApplicationPauseList = new List<Action<bool>>();

    private Dictionary<string, LuaTable> scriptEnvDict = new Dictionary<string, LuaTable>();
    private List<LuaTable> scriptEnvList = new List<LuaTable>();

    private static List<string> luaSearchPaths = new List<String>();
    public static void clearSearchPaths()
    {
        luaSearchPaths.Clear();
        luaScriptDict.Clear();
        addSearchPaths(Application.streamingAssetsPath + "/DHGames");
    }

    public static void clearCache()
    {
        luaScriptDict.Clear();
    }

    //快速刷新所有已打开UI
    public static void fastRestartUI(){
        Debug.Log("LuaBehaviour:FastRestartUI");
        luaEnv.DoString("require(\"framework.App\").restartUI()", "fast restart ui");
    }

    //快速重启整个游戏
    public static void fastRestart()
    {
        Debug.Log("LuaBehaviour:FastRestart");
        luaEnv.DoString("require(\"framework.App\").restartGame()", "restart game");
    }

    public static void addSearchPaths(string path)
    {
        luaSearchPaths.Add(path);
        
    }

    static private byte[] loadLuaScriptText(string scriptPath, bool cache)
    {
        byte[] luaText = null;
        scriptPath = scriptPath.Replace('.', '/');
        //Debug.Log("loadLuaScriptText, path is " + scriptPath);
        if (!luaScriptDict.TryGetValue(scriptPath, out luaText))
        {
	        //PC平台:执行Assets/Develop/Lua目录中的代码
            if ((Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor))
	        {
                string devTextPath = Application.dataPath + "/Develop/Lua/" + scriptPath + ".lua";
                bool devExist = System.IO.File.Exists(devTextPath);
                string luaTextPath = null;
                if (devExist)
                {
	                //执行源码
                    luaTextPath = "file://" + Application.dataPath + "/Develop/Lua/" + scriptPath + ".lua";
                }
                else
                {
	                //执行字节码:策划是没有源码的,执行编译后的字节码
                    luaTextPath = "file://" + Application.dataPath + "/Lua/" + scriptPath + ".lua.bytes";
                }
                WWW w = new WWW(luaTextPath);
                if (string.IsNullOrEmpty(w.error))
                {
                    luaText = w.bytes;
                }
                else
                {
                    Debug.LogError("lua file is missing : " + luaTextPath + " " + w.error);
                }
            }
            else
            {
                string packageLuaFilePath = Application.streamingAssetsPath;
                Action<string> loadText = (string preName) =>
                {
	                //热更路径
	                string luaTextPath = preName + "/lua/" + scriptPath.ToLower() + ".lua.bytes.ab";
	                try
	                {
		                /*Lua文件会有多个搜索路径，原始文件在streamingAssetsPath，也就是包里，热更文件在磁盘里，
		                比如persistentDataPath。AssetBundle.LoadFromFile这个鬼，如果读取目标文件时，目标
		                文件不存在，会打印Error日志并且try是无用的，导致调试时会很烦，因此需要判断下文件是否存在
		                注意:streamingAssetsPath因为在包里，不同平台访问权限不同，是不能用System.IO.File.Exists判断的，
		                并且因为是固定在包里，也没有必要判断
		                */
		                if (!luaTextPath.ToLower().Contains(packageLuaFilePath.ToLower()))
		                {
			                bool exist = System.IO.File.Exists(luaTextPath);
			                if (!exist)
			                {
				                return;
			                }
		                }

		                AssetBundle ab = AssetBundle.LoadFromFile(luaTextPath);
		                if (ab)
		                {
			                
			                string assetName = "Assets/Lua/" + scriptPath + ".lua.bytes";
			                TextAsset textAsset = ab.LoadAsset<TextAsset>(assetName);
			                luaText = textAsset.bytes;
			                ab.Unload(true);
		                }

		                else
		                {
			                //Debug.Log("Load lua asset bundle failed, path is " + luaTextPath);
		                }
	                }
	                catch
	                {
		                //ignore
	                }
                };

	           
	            for (int i = luaSearchPaths.Count - 1; i >= 0; i--)
                {
                    string searchPath = luaSearchPaths[i];
	                
                    loadText(searchPath);
                    if (luaText != null)
                    {
                        break;
                    }
                }

                if (luaText == null)
                {
                    Debug.LogError("Lua assetBundle is missing : " + scriptPath + ".lua");
                }
                else
                {
                    //Debug.Log("Lua assetBundle is get : " + scriptPath + ".lua");
                }
            }

            if (cache && luaText != null)
            {
                luaScriptDict.Add(scriptPath, luaText);
            }
        }

        return luaText;
    }

    public LuaTable getTable(string key)
    {
        LuaTable ret;
        if (scriptEnvDict.TryGetValue(key, out ret))
        {
            return ret;
        }
        else
        {
            return null;
        }
    }

    public LuaTable getTable(int index)
    {
        if (index < scriptEnvList.Count)
        {
            return scriptEnvList[index];
        }
        else
        {
            return null;
        }
    }

    public LuaTable getTable()
    {
        if (scriptEnvList.Count > 0)
        {
            return scriptEnvList[0];
        }
        else
        {
            return null;
        }
    }

    public void addLuaScript(string luaScriptPath) 
    {
        luaScriptPathList.Add(luaScriptPath);
        executeLuaScript(luaScriptPath);
    }

    private void executeLuaScript(string luaScriptPath) 
    {
		LuaTable scriptEnv = luaEnv.NewTable();

		LuaTable meta = luaEnv.NewTable();
		meta.Set("__index", luaEnv.Global);
		scriptEnv.SetMetaTable(meta);
		meta.Dispose();

		scriptEnv.Set("self", this);
		foreach (var gameObj in injectionList)
		{
            if (gameObj != null) {
                scriptEnv.Set(gameObj.name, gameObj);
            }
		}

        if(!scriptEnvDict.ContainsKey(luaScriptPath))
        {
            scriptEnvDict.Add(luaScriptPath, scriptEnv);
            scriptEnvList.Add(scriptEnv);
        }
		
		byte[] luaText = loadLuaScriptText(luaScriptPath, true);
		if (luaText != null)
		{
			luaEnv.DoString(luaText, luaScriptPath, scriptEnv);

			Action luaFunction;
			scriptEnv.Get("luaStart", out luaFunction);
			if (luaFunction != null)
			{
				luaStartList.Add(luaFunction);
			}
			scriptEnv.Get("luaUpdate", out luaFunction);
			if (luaFunction != null)
			{
                luaUpdateList.Add(luaFunction);
			}
			scriptEnv.Get("luaFixedUpdate", out luaFunction);
			if (luaFunction != null)
			{
				luaFixedUpdateList.Add(luaFunction);
			}
			scriptEnv.Get("luaLateUpdate", out luaFunction);
			if (luaFunction != null)
			{
				luaLateUpdateList.Add(luaFunction);
			}
			scriptEnv.Get("luaOnGUI", out luaFunction);
			if (luaFunction != null)
			{
				luaOnGUIList.Add(luaFunction);
			}
			scriptEnv.Get("luaOnDisable", out luaFunction);
			if (luaFunction != null)
			{
				luaOnDisableList.Add(luaFunction);
			}
			scriptEnv.Get("luaOnEnable", out luaFunction);
			if (luaFunction != null)
			{
				luaOnEnableList.Add(luaFunction);
			}
			scriptEnv.Get("luaOnDestroy", out luaFunction);
			if (luaFunction != null)
			{
				luaOnDestroyList.Add(luaFunction);
			}
			Action<bool> focusFunction;
			scriptEnv.Get("luaOnApplicationFocus", out focusFunction);
			if (focusFunction != null)
			{
				luaOnApplicationFocusList.Add(focusFunction);
			}
			Action<bool> pauseFunction;
			scriptEnv.Get("luaOnApplicationPause", out pauseFunction);
			if (pauseFunction != null)
			{
				luaOnApplicationPauseList.Add(pauseFunction);
			}

            //注册持久化变量
            HashSet<string> keyHashSet = new HashSet<string>();
			for (int i = 0; i < luaNumberKeyList.Count; i++)
			{
				string fullKey = luaNumberKeyList[i];
				if (fullKey.StartsWith(luaScriptPath, StringComparison.Ordinal))
				{
					int index = fullKey.LastIndexOf('.');
					string key = fullKey.Substring(index + 1);
					scriptEnv.Set(key, luaNumberValueList[i]);

                    keyHashSet.Add(key);
				}
			}
			LuaTable publicNumber;
			scriptEnv.Get("public_number", out publicNumber);
			if (publicNumber != null)
			{
				publicNumber.ForEach<string, float>((string key, float fValue) => {
                    if (!keyHashSet.Contains(key)) {
                        scriptEnv.Set(key, fValue);
                    }
				});
			}

            for (int i = 0; i < luaUserdataKeyList.Count; i++)
			{
				string fullKey = luaUserdataKeyList[i];
				if (fullKey.StartsWith(luaScriptPath, StringComparison.Ordinal))
				{
					int index = fullKey.LastIndexOf('.');
					string key = fullKey.Substring(index + 1);
					scriptEnv.Set(key, luaUserdataValueList[i]);
				}
			}

			Action luaAwake = scriptEnv.Get<Action>("luaAwake");
			if (luaAwake != null)
			{
				luaAwake();
			}
		}
    }

    void Awake()
    {
        //初始化工具帮助类
        //约定，所有需要挂载的唯一全局唯一脚本，都在这里进行挂载
        if (globalObject == null)
        {
            globalObject = new GameObject("Global");
            DontDestroyOnLoad(globalObject);
            //不管哪个平台都挂一个LuaBehaviour脚本,方便处理一些全局的功能
            var luaBehaviour = globalObject.AddComponent<LuaBehaviour>();

            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor)
            {
                //挂载检测输入脚本
                luaBehaviour.addLuaScript("bind.Input");
            }
        }

        //初始化Lua虚拟机
        if (luaEnv == null)
        {
            luaEnv = new LuaEnv();
            luaEnv.AddLoader((ref string filename) =>
            {
                byte[] text = loadLuaScriptText(filename, false);
                return text;
            });


            //方便切换任意场景 执行一次lua初始化
            luaEnv.DoString("require(\"framework.App\").init()", "lua init");

		}

        if (luaScriptPathList.Count == 0) {
			LuaTable scriptEnv = luaEnv.NewTable();

			scriptEnv.Set("self", this);
			foreach (var gameObj in injectionList)
			{
                if (gameObj != null) {
                    scriptEnv.Set(gameObj.name, gameObj);
                }
			}

            scriptEnvList.Add(scriptEnv);
        }

        foreach (string luaScriptPath in luaScriptPathList) {
            executeLuaScript(luaScriptPath);
        }
    }

	// Use this for initialization
	void Start () {
		foreach (var luaStart in luaStartList) {
			luaStart();
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach (var luaUpdate in luaUpdateList) {
			luaUpdate();
		}
        if (luaEnv != null && Time.time - LuaBehaviour.lastGCTime > GCInterval)
        {
            luaEnv.Tick();
            LuaBehaviour.lastGCTime = Time.time;
        }
	}

	void FixedUpdate() {
		foreach (var luaFixedUpdate in luaFixedUpdateList) {
			luaFixedUpdate();
		}
	}

	void LateUpdate() {
		foreach (var luaLateUpdate in luaLateUpdateList)
		{
			luaLateUpdate();
		}
	}

	void OnDisable() {
		foreach (var luaOnDisable in luaOnDisableList) {
			luaOnDisable();
		}
	}

	void OnEnable() {
		foreach (var luaOnEnable in luaOnEnableList) {
			luaOnEnable();
		}
	}

	private void OnApplicationFocus(bool hasFocus)
	{
		foreach (var luaOnApplicationFocus in luaOnApplicationFocusList) {
			luaOnApplicationFocus(hasFocus);
		}
	}


	private void OnApplicationPause(bool pauseStatus)
	{
		foreach (var luaOnApplicationPause in luaOnApplicationPauseList) {
			luaOnApplicationPause(pauseStatus);
		}
	}

	void OnDestroy() {
		foreach (var luaOnDestroy in luaOnDestroyList) {
			luaOnDestroy();
		}

        luaStartList.Clear();
		luaUpdateList.Clear();
		luaFixedUpdateList.Clear();
		luaLateUpdateList.Clear();
		luaOnGUIList.Clear();
		luaOnDisableList.Clear();
        luaOnEnableList.Clear();
		luaOnDestroyList.Clear();
		luaOnApplicationFocusList.Clear();
		luaOnApplicationPauseList.Clear();


        foreach (var scriptEnv in scriptEnvList) {
            scriptEnv.Dispose();
        }
        scriptEnvList.Clear();
        scriptEnvDict.Clear();
        injectionList.Clear();
    }
}
