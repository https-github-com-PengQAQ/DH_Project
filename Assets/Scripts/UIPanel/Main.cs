using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : BaseUI
{
    public void OpenPanel(string panel)
    {
        UIManager.Instance.showUI(panel);
    }
    public void popPanel()
    {
        UIManager.Instance.popPanel();
    }
    public void openSecen()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }
}
