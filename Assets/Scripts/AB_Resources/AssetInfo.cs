using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
[Hotfix]
[LuaCallCSharp]
public class AssetInfo 
{
    //资源对象
    private UnityEngine.Object _Object;
    //资源类型
    public Type AssetType { get; set; }
    ////路径
    public string Path { get; set; }
    //读取次数
    public int RefCount { get; set; }

    //加载方式（Eidtor和实际不同）
    public string LoadType;

    //是否加载
    public bool IsLoaded
    {
        get
        {
            return _Object != null;
        }
    }

    public UnityEngine.Object AssetObject
    {
        get
        {
            if (null == _Object)
            {
                ResourcesLoad();
            }
            return _Object;
        }
    }
    //加载
    private void ResourcesLoad()
    {
        try
        {
            #if UNITY_EDITOR
                        _Object = Resources.Load(Path, typeof(UnityEngine.Object));
            #endif
            #if UNITY_IPHONE
                        _Object = Resources.Load(Path, typeof(UnityEngine.Object));
            #endif
            if (!_Object)
                Debug.Log("Load Failed:" + Path);
        }
        catch(Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    //协程加载
    public IEnumerator GetCoroutineObject(Action<UnityEngine.Object> _loaded)
    {
        while (true)
        {
            yield return null;
            if (!_Object)
            {
                ResourcesLoad();
                yield return null;
            }
            else
            {
                if (_loaded != null)
                    _loaded(_Object);
            }
            yield break;
        }
    }



}
