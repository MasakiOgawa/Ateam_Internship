using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Stage1 : MonoBehaviour {

    public float FadeTime = 0.5f;
	[SerializeField] SEManager SE;

	public void OnClick()
    {
		SE.PlaySE(4);
		FadeManager.Instance.LoadScene("GameScene", FadeTime);
    }
}
