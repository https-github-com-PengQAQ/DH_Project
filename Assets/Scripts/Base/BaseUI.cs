using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;


[Hotfix]
public class BaseUI : MonoBehaviour
{
    Canvas canvas;
    /// <summary>
    /// 打开UI
    /// </summary>
    [LuaCallCSharp]
    public virtual void OnOpen()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }
    /// <summary>
    /// 关闭UI
    /// </summary>

    public virtual void OnClose()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        
    }
    /// <summary>
    /// 隐藏UI
    /// </summary>

    public virtual void OnHide()
    {
        GetComponent<CanvasGroup>().alpha = 0;
    }
    /// <summary>
    /// 重新打开UI
    /// </summary>

    public virtual void OnResume()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }
}
