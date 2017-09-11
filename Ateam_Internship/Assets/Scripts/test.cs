using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
	private bool flag;
	private bool flag2;
	private Color color;

	[SerializeField]
	private Sprite tex1;
	[SerializeField]
	private Sprite tex2;
	[SerializeField]
	private Sprite tex3;
	[SerializeField]
	private Sprite tex4;

	private Sprite tex00;
	
	// Use this for initialization
	void Start()
	{
		color = new Color(1, 0.5f, 1, 1);
		Screen.SetResolution(360, 640, Screen.fullScreen);
		
		tex00 = tex1;
	}

	// Update is called once per frame
	void Update()
	{
		// ESCキーが押されたらゲーム終了
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}

		// 左クリックが押されていたら
		if (Input.GetMouseButton(0))
		{
			flag = true;
		}
		else
		{
			flag = false;
		}

		// 右クリックが押されていたら
		if (Input.GetMouseButton(1))
		{
			flag2 = true;
		}
		else
		{
			flag2 = false;
		}


		// 色を切り替え
		if (Input.GetKeyDown(KeyCode.A))
		{
			color = new Color(1, 0.5f, 1, 1);
		}

		if (Input.GetKeyDown(KeyCode.S))
		{
			color = new Color(0.5f, 0.5f, 1, 1);
		}

		if (Input.GetKeyDown(KeyCode.D))
		{
			color = Color.white;
		}

		if (Input.GetKeyDown(KeyCode.F))
		{
			color = new Color(1, 0.5f, 1, 1);
			GetComponent<SpriteRenderer>().color = Color.white;
		}


		// テクスチャを切り替え
		if (Input.GetKeyDown(KeyCode.Q))
		{
			tex00 = tex1;
		}

		if (Input.GetKeyDown(KeyCode.W))
		{
			tex00 = tex2;
		}

		if (Input.GetKeyDown(KeyCode.E))
		{
			tex00 = tex3;
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			tex00 = tex4;
		}


		// スペースが押されたらテクスチャをランダムに設定
		if (Input.GetKeyDown(KeyCode.Space))
		{
			switch (Random.Range(1, 5))
			{
				case 1:
					GetComponent<SpriteRenderer>().sprite = tex1;
					break;

				case 2:
					GetComponent<SpriteRenderer>().sprite = tex2;
					break;

				case 3:
					GetComponent<SpriteRenderer>().sprite = tex3;
					break;

				case 4:
					GetComponent<SpriteRenderer>().sprite = tex4;
					break;
			}
		}
	}


	// マウスがオブジェクトの上に乗ったら
	private void OnMouseOver()
	{
		//// 色を切り替え
		//if (flag == true)
		//{
		//	GetComponent<SpriteRenderer>().color = color;
		//}

		// テクスチャを切り替え
		if (flag2 == true)
		{
			GetComponent<SpriteRenderer>().sprite = tex00;
		}
	}

	// オブジェクトがタッチされているときの処理
	public void OnTouch()
	{
		Debug.Log("touch");
		
		GetComponent<SpriteRenderer>().color = color;

		//GetComponent<SpriteRenderer>().sprite = tex00;
	}
}
