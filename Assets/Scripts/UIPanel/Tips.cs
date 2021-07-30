using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tips : BaseUI
{
    public GameObject point;
    public override void OnOpen()
    {
        base.OnOpen();

        //transform.DOLocalMove(point.transform.position, 2);
    }
}
