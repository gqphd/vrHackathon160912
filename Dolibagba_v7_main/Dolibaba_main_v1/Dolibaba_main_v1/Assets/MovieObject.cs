using UnityEngine;
using System.Collections;
using System;

public class MovieObject : ResponsingObject {
    public GameObject rectangleScreen;

    protected override void actionOnGazing()
    {
        print("You Are Gazing on " + PRODUCT_NAME);
        rectangleScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
