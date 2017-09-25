using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_WingQuest : MonoBehaviour {

    public float FadeTime;
    public void OnClick()
    {
        FadeManager.Instance.LoadScene("QuestScene", FadeTime);
    }
}
