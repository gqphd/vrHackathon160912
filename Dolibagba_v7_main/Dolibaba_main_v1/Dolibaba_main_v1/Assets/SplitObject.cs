using UnityEngine;
using System.Collections;
using System;

public class SplitObject : ResponsingObject{
    
    protected override void actionOnGazing()
    {
        print("You Are Gazing on " + PRODUCT_NAME);
        if (transform.childCount >= 1)
        {
            GetComponent<Animator>().SetTrigger("selected");

            print("You Are selecting" + PRODUCT_NAME);
        }
    }
}


