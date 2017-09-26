using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleStar : MonoBehaviour {


    // Use this for initialization
    void Start()
    {
        Screen.SetResolution(360, 640, false, 60);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-0.005f, 0, 0);
        if (transform.position.x < -10)
        {
            transform.position = new Vector3(10, 0, 0);
        }
    }
}
