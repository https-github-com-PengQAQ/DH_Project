using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        UIManager.Instance.init();
        UIManager.Instance.showUI("Main");
    }
}
