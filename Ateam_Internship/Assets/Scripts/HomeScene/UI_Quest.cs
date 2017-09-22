using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Quest : MonoBehaviour
{
    public void OnClick() {
        FadeManager.Instance.LoadScene("QuestScene", 2.0f);
    }
}
         

