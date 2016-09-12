using UnityEngine;
using System.Collections;

public abstract class ResponsingObject : MonoBehaviour {
    public string PRODUCT_NAME = "NAME";
    public float GAZING_SEC = 2f;
    bool isGazing = false;


    void Start()
    {
        if (GetComponent<Animator>())
            GetComponent<Animator>().StopPlayback();
        isGazing = false;
    }

    protected abstract void actionOnGazing();
    void gazingFor()
    {
        if (isGazing)
        {
            actionOnGazing();
        }
    }

    /// Called when the user is looking on a GameObject with this script,
    /// as long as it is set to an appropriate layer (see GvrGaze).
    public void OnGazeEnter()
    {
        isGazing = true;
        Invoke("gazingFor", GAZING_SEC);
    }

    /// Called when the user stops looking on the GameObject, after OnGazeEnter
    /// was already called.
    public void OnGazeExit()
    {
        isGazing = false;
        CancelInvoke("gazingFor");
    }

    /// Called when the viewer's trigger is used, between OnGazeEnter and OnGazeExit.
    public void OnGazeTrigger()
    {
    }
}