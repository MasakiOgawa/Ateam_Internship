using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Stage1 : MonoBehaviour {

    public float FadeTime = 0.5f;
    public void OnClick()
    {
        FadeManager.Instance.LoadScene("GameScene", FadeTime);
    }
}
