using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class UIManager:MonoBehaviour
{

    //单例模式
    public static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UIManager();
                
            }
            return instance;
        }
    }
    static private Dictionary<string, BaseUI> panels;
    static private Dictionary<string, bool> panelIsIns;
    static private List<BaseUI> panelsList;
    static private Stack<BaseUI> UIStack;
    /// <summary>
    /// 获取Canvas
    /// </summary>
    private Transform canvasTransform;
    private Transform CanvasTransform
    {
        get
        {
            if (canvasTransform == null)
                canvasTransform = GameObject.Find("Canvas").transform;
            return canvasTransform;
        }
    }

    public void init()
    {
        panels = new Dictionary<string, BaseUI>();
        UIStack = new Stack<BaseUI>();
        panelIsIns = new Dictionary<string, bool>();
        panelsList = new List<BaseUI>();
        GetAllPrefabs();
    }

    private static void GetAllPrefabs()
    {
        string UIpath = "Assets/Resources/Prefab/UI";
        string[] allPath = AssetDatabase.FindAssets("t:Prefab", new string[] { UIpath });

        for(int i = 0; i < allPath.Length; i++)
        {
            string path = AssetDatabase.GUIDToAssetPath(allPath[i]);
            BaseUI obj = AssetDatabase.LoadAssetAtPath(path, typeof(BaseUI)) as BaseUI;
            //BaseUI ob = Instantiate(obj);
            panels.Add(obj.name, obj);
            panelIsIns.Add(obj.name, false);
        }
    }

    public  void showUI(string panel)
    {
        BaseUI obj = null;
        if (UIStack == null)
            UIStack = new Stack<BaseUI>();
        if (UIStack.Count != 0)
            UIStack.Peek().OnHide();
        //判断是否实例化
        if (!panelIsIns[panel])
        {
            obj = Instantiate(panels[panel]);
            panelsList.Add(obj);
            panelIsIns[panel] = true;
            //后面的参数true，false表示是否保持在世界坐标的位置
            obj.transform.SetParent(CanvasTransform, false);
        }
        else
        {
            foreach(BaseUI ob in panelsList)
            {
                if (ob.name == panel+ "(Clone)")
                    obj = ob;
            }
        }
        
        UIStack.Push(obj);    //压栈
        UIStack.Peek().OnOpen();

    }

    public void popPanel()
    {
        if (UIStack == null)
            UIStack = new Stack<BaseUI>();
        if (UIStack.Count <= 0)
            return;

        //关闭栈顶的显示
        UIStack.Pop().OnClose();

        //重新打开
        UIStack.Peek().OnResume();
    }
}
