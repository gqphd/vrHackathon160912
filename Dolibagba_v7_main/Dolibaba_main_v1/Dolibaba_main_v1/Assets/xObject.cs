using UnityEngine;
using System.Collections;
using System;

public class xObject : ResponsingObject
{
    public GameObject objectToClose;


    protected override void actionOnGazing()
    {
        transform.parent.gameObject.SetActive(false);
        if(objectToClose!=null)
            objectToClose.SetActive(false);
    }
}
