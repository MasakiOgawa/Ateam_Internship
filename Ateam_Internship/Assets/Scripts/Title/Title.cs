using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour 
{
    public float FadeTime;

	// Use this for initialization
	void Start ()
    {
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
	}
}
