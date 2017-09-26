using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{

	private bool flag;
	public float FadeTime;
	[SerializeField] SEManager SE;

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			if (flag == false)
			{
				FadeManager.Instance.LoadScene("HomeScene", FadeTime);
				SE.PlaySE(4);
			}
			flag = true;
		}
		if (Input.GetMouseButton(1))
		{
			//テスト用
			//特に処理なし
		}
	}
}
