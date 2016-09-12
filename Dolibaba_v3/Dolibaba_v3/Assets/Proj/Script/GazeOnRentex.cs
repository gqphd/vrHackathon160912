using UnityEngine;
using System.Collections;

public class GazeOnRentex : MonoBehaviour {

    public GameObject goOnHit;

    public bool isSecondCast = true;
    public Camera raycastingVirtualCamera;

    public string[] collideNames;
    public string[] linkUrls;

    // Use this for initialization
    void Start () {
        Debug.Log("GazeOnRentex started");
    }

    public float elapsedOnGaze = 0;
    public float gazeThreshold = 2;
    public float releaseThreshold = 3;

    public bool isTriggered = false;
	
	// Update is called once per frame
	void Update () {
        Vector3 vecOculView = transform.TransformDirection(Vector3.forward);
        Ray rayFirst = new Ray(transform.position, vecOculView);
        Debug.DrawRay(rayFirst.origin, rayFirst.direction, Color.blue);

        if (isTriggered)
        {
            elapsedOnGaze += Time.deltaTime;
            if(elapsedOnGaze> releaseThreshold)
            {
                isTriggered = false;
            }

            goOnHit.GetComponent<MeshRenderer>().material.color = Color.red;
            return;
        }

        RaycastHit hitFirst;
        if (Physics.Raycast(rayFirst, out hitFirst, 10000))
        {
            Debug.DrawLine(rayFirst.origin, hitFirst.point, Color.red);
            Vector3 hitpos = hitFirst.point;

            goOnHit.transform.position = hitpos;
            goOnHit.GetComponent<MeshRenderer>().material.color = Color.blue;

            //if secondary ray
            Vector2 uv = hitFirst.textureCoord;
            //Debug.LogFormat("U({0}) V({1})", uv.x, uv.y);

            //gq
            //no retargetting.. i am tired.
            //nope. do that again.
            if (isSecondCast)
            {
                float asp = raycastingVirtualCamera.aspect;
                float vFov = raycastingVirtualCamera.fieldOfView * Mathf.Deg2Rad;
                //Debug.LogFormat("Fov:{0}", vFov);
                //Debug.LogFormat("asp:{0}", asp);
                float hFov = vFov * asp;
                float progU = (uv.x - 0.5f) * 2;
                float progV = (uv.y - 0.5f) * 2;
                Vector3 fromPos = Vector3.zero;
                Vector3 landingPos = new Vector3(Mathf.Tan(hFov* progU / 2), Mathf.Tan(vFov* progV / 2), 1);
                //Debug.LogFormat("Mathf.Tan(hFov* progU / 2):{0}", Mathf.Tan(hFov * progU / 2));
                Vector3 recastDir = landingPos - fromPos;

                //Debug.DrawLine(ray.origin, hit.point, Color.red);
                Vector3 drawraySta = raycastingVirtualCamera.transform.position;
                Vector3 drawrayFin = drawraySta + raycastingVirtualCamera.transform.TransformDirection(recastDir)*3000;
                Debug.DrawLine(drawraySta, drawrayFin, Color.blue);

                Ray raySecond = new Ray(drawraySta, recastDir);
                RaycastHit hitSecond;

                if (Physics.Raycast(raySecond, out hitSecond, 10000))
                {
                    
                    //do something while colliding..

                    elapsedOnGaze += Time.deltaTime;
                    float gazeProg = elapsedOnGaze / gazeThreshold;
                    Debug.LogFormat("Ar target is collided! Gaze progress : {0}", gazeProg*100f);
                    Debug.DrawLine(drawraySta, drawrayFin, Color.green);
                    if (gazeProg > 1)
                    {
                        Debug.LogErrorFormat("Hit : {0}", hitSecond.collider.transform.parent.gameObject.name);
                        elapsedOnGaze = 0;

                        isTriggered = true;

                        for(int i = 0; i < collideNames.Length; i++)
                        {
                            string searchName = collideNames[i];
                            if (hitSecond.collider.transform.parent.gameObject.name.Contains(searchName))
                            {
                                Application.OpenURL(linkUrls[i]);
                            }
                        }
                    }

                    if (gazeProg > 1f) gazeProg = 1f;
                    goOnHit.GetComponent<MeshRenderer>().material.color = new Color(gazeProg, gazeProg, 1.0f);
                }
                else
                {
                    elapsedOnGaze = 0;
                }
            }
            
        }
        else
        {
            goOnHit.transform.position = Vector3.one * 10000f;
        }

            //Debug.DrawLine(ray.origin, ray.direction);
            //Debug.DrawRay(ray.origin, ray.direction*1000, Color.red);
            //Debug.DrawLine(ray.origin, ray.direction*1000, Color.red);
            //Gizmos.color = Color.blue;
            //Gizmos.DrawLine(transform.position, Vector3.one*1000);
            //if (Physics.Raycast(ray, out hit, 100))        {
            //    Debug.DrawLine(ray.origin, hit.point);
            //}
            //Debug.Log("Meh111");
    }
}
