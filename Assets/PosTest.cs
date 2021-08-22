using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PosTest : MonoBehaviour
{
    public Transform g;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(g.position);
        Debug.Log(g.localPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
