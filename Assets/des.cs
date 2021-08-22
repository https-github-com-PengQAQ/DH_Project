using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class des : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Destroy(this, 0.6f);
        
        //StartCoroutine(d());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator d()
    {
        yield return new WaitForSeconds(0.7f);
        GameObject.Destroy(this,0.6f);
    }
}
