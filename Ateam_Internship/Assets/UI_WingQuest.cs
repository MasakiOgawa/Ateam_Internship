using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_WingQuest : MonoBehaviour {

    public float FadeTime;
    public float ToFadeTime; // タップしてからフェードまでの時間

    public void OnClick()
    {
        StartCoroutine("hogehoge");
    }
    IEnumerator hogehoge()
    {

        yield return new WaitForSeconds(ToFadeTime);
        FadeManager.Instance.LoadScene("QuestScene", FadeTime);
    }
}
