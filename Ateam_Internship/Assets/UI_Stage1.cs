using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Stage1 : MonoBehaviour {

    public float FadeTime;
    public float ToFadeTime; // タップしてからフェードまでの時間

    public void OnClick()
    {
        StartCoroutine("hogehoge");
    }

    IEnumerator hogehoge()
    {

        yield return new WaitForSeconds(ToFadeTime);
        //FadeManager.Instance.LoadScene("GameScene", FadeTime);
    }
}
