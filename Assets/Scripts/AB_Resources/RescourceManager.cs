using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

[Hotfix]
[LuaCallCSharp]
public class RescourceManager : Singleton<RescourceManager>
{
    private Dictionary<string, AssetInfo> dicAssetInfo = new Dictionary<string, AssetInfo>();

    public override void Init()
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace);
        dicAssetInfo = new Dictionary<string, AssetInfo>();
    }

    public UnityEngine.Object LoadInstance(string path)
    {
        UnityEngine.Object obj = Load(path);
        return Instantiate(obj);
    }

    public UnityEngine.Object Load(string path)
    {
        AssetInfo assetInfo = GetAssetInfo(path);
        if (assetInfo != null)
            return assetInfo.AssetObject;
        return null;
    }


    private AssetInfo GetAssetInfo(string path, Action<UnityEngine.Object> loaded = null)
    {
        if(string.IsNullOrEmpty(path))
        {
            Debug.Log("the path is not found");
            if (loaded != null)
                loaded(null);
        }

        AssetInfo assetInfo = null;
        //第一次加载，当内存中没有这资源时，将其加入到字典中
        if(!dicAssetInfo.TryGetValue(path,out assetInfo))
        {
            assetInfo = new AssetInfo();
            assetInfo.Path = path;
            dicAssetInfo.Add(path, assetInfo);
        }
        assetInfo.RefCount++;
        return assetInfo;
        
    }


    private UnityEngine.Object Instantiate(UnityEngine.Object obj, Action<UnityEngine.Object> loaded = null)
    {
        UnityEngine.Object retObj = null;
        if(obj != null)
        {
            retObj = MonoBehaviour.Instantiate(obj);
            if (retObj != null)
            {
                if (loaded != null)
                {
                    loaded(retObj);
                    return null;
                }
                return retObj;
            }
            else
                Debug.Log("Error:null Instantiate");
        }
        else
        {
            Debug.LogError("Error: null Resources Load return _obj.");
        }
        return null;
    }


    private void Destory()
    {
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }
}
