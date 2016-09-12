using UnityEngine;
using System.Collections;

public class SpherePlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {

        // this line of code will make the Movie Texture begin playing
        ((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
    }

    // Update is called once per frame
    void Update () {

        //if (Input.GetButtonDown("Jump"))
        //{

        //    Renderer r = GetComponent<Renderer>();
        //    MovieTexture movie = (MovieTexture)r.material.mainTexture;

        //    if (movie.isPlaying)
        //    {
        //        movie.Pause();
        //    }
        //    else
        //    {
        //        movie.Play();
        //    }
        //}

    }
}
