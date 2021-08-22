using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class AssetBundle : Editor
{
    [MenuItem("AB/Build")]
    static void Build()
    {
        string outDir = "Bundles";
        if(!Directory.Exists(outDir))
        {
            Directory.CreateDirectory(outDir);
        }
        AssetBundleBuild[] bundles = new AssetBundleBuild[1];
        bundles[0].assetBundleName = "ui.Unity3d";
        string[] bundleAsset = new string[6];
        bundleAsset[0] = @"Assets/Resources/Prefab/UI/Main.prefab";
        bundleAsset[1] = @"Assets/Resources/Prefab/UI/Bag.prefab";
        bundleAsset[2] = @"Assets/Resources/Prefab/UI/Game.prefab";
        bundleAsset[3] = @"Assets/Resources/Prefab/UI/Shop.prefab";
        bundleAsset[4] = @"Assets/Resources/Prefab/UI/Stop.prefab";
        bundleAsset[5] = @"Assets/Resources/Prefab/UI/Tips.prefab";
        bundles[0].assetNames = bundleAsset;
        BuildPipeline.BuildAssetBundles(outDir, bundles, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);

        //BuildPipeline.BuildAssetBundles(outDir, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);

    }
}
