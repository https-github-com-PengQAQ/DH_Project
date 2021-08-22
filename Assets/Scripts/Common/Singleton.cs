using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 单例模式的泛型构造
/// 所有单例继承自这个
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class Singleton<T> where T : class,new()
{
    protected static T _instance = null;
    public static T Instance
    {
        get
        {
            if (_instance == null)
                _instance = new T();
            return _instance;
        }
    }
   
    protected Singleton()
    {
        Init();
    }

    public virtual void Init() { }
}
