using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour 
{
   
	
	// Use this for initialization
	void Start ()
    {
		Screen.SetResolution(360, 640, false, 60);
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(-0.01f, 0, 0);
        if (transform.position.x < -11f)
        {
            transform.position = new Vector3(11f, 0, 0);
        }
	}
}
