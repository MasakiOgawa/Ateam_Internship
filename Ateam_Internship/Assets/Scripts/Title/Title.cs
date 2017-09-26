using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour 
{
    public float FadeTime;

	// Use this for initialization
	void Start ()
    {
		Screen.SetResolution(360, 640, false, 60);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetMouseButton(0))
        {
            FadeManager.Instance.LoadScene("HomeScene", FadeTime);
        }
        if (Input.GetMouseButton(1))
        { 
            //テスト用
            //特に処理なし
        }

        transform.Translate(-0.01f, 0, 0);
        if (transform.position.x < -11f)
        {
            transform.position = new Vector3(11f, 0, 0);
        }
	}
}
