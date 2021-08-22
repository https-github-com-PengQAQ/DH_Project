using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LingtningEvent : MonoBehaviour
{

    public bool isLight = true;
    public GameObject lightning;
    public GameObject p;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            p = GameObject.Find("Player(Clone)");
            StartCoroutine(EventLight());
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            isLight = false;
        }
    }


    IEnumerator EventLight()
    {
        for(; ; )
        {
            if (isLight == false)
                break;
            yield return new WaitForSeconds(3f);
            GameObject ob = Instantiate(lightning);
            ob.transform.position = new Vector3(p.transform.position.x, p.transform.position.y + 2f, p.transform.position.z);
        }
       
    }    
}
