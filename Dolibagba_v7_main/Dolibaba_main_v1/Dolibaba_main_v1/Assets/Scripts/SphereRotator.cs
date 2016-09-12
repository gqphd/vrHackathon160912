using UnityEngine;
using System.Collections;

public class SphereRotator : MonoBehaviour {

    //slerp
    //Quaternion startRotation;
    //public Quaternion toRotation;

    public float rotateFreq = 4.0f;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        //every frame
        float elapsedTimeBetweenFrame = Time.deltaTime;
        float rotateYAngleVelDeg = 360.0f / rotateFreq;
        float rotDeg = rotateYAngleVelDeg * elapsedTimeBetweenFrame;
        Debug.Log("Rot :" + rotDeg);

        Vector3 prevEulerRot = transform.rotation.eulerAngles;
        float newY = prevEulerRot.y + rotDeg;
        transform.rotation = Quaternion.Euler(prevEulerRot.x, newY, prevEulerRot.z);

    }
}
