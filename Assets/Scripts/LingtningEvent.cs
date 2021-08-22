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
            p = GameObject.Find("Player(Clone)");
        if (isLight == true)
            StartCoroutine(EventLight());
    }


    IEnumerator EventLight()
    {
        yield return new WaitForSeconds(3f);
        GameObject ob = Instantiate(lightning);
        
    }    
}
