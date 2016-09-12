using UnityEngine;
using System.Collections;

public class PlayMovieTexture : MonoBehaviour {

    public bool isLoop = false;

	// Use this for initialization
	void Start () {
        //@ref https://docs.unity3d.com/Manual/class-MovieTexture.html
        // this line of code will make the Movie Texture begin playing
        ((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
        ((MovieTexture)GetComponent<Renderer>().material.mainTexture).loop = isLoop;

    }

    // Update is called once per frame
    void Update () {
	}
}
