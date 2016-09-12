using UnityEngine;
using System.Collections;
using System;

public class WebObject : ResponsingObject
{
    protected override void actionOnGazing()
    {
        Application.OpenURL("http://blog.naver.com/yk9800/220783251245");
    }
}
