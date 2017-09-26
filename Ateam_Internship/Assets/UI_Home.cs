using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Home : MonoBehaviour {

    public float FadeTime;
	[SerializeField] SEManager SE;

	public void OnClick()
    {
		SE.PlaySE(4);
		FadeManager.Instance.LoadScene("HomeScene", FadeTime);
    }
}
