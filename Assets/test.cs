using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(shake());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator shake()
    {
        yield return new WaitForSeconds(1f);
        //transform.DOShakePosition(0.3f);
        
    }
}
