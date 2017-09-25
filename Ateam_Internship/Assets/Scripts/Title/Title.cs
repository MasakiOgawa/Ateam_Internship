using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour 
{
    public float FadeTime;
    public float ToFadeTime; // タップしてからフェードまでの時間

    
	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetMouseButton(0))
        {
            
            StartCoroutine("hogehoge");
         
        }
        if (Input.GetMouseButton(1))
        { 
            //テスト用
            //特に処理なし
        }
	}

    IEnumerator hogehoge()
    {

        yield return new WaitForSeconds(ToFadeTime);
        FadeManager.Instance.LoadScene("HomeScene", FadeTime);
    }


}
