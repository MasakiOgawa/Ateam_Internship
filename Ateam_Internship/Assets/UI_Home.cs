﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Home : MonoBehaviour {

    public float FadeTime;
    public void OnClick()
    {
        FadeManager.Instance.LoadScene("HomeScene", FadeTime);
    }
}
