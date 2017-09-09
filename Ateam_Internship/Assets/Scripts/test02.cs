using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 画面上部の記号表示用
public class test02 : MonoBehaviour
{
	[SerializeField]
	private Sprite tex1;
	[SerializeField]
	private Sprite tex2;
	[SerializeField]
	private Sprite tex3;
	[SerializeField]
	private Sprite tex4;

	// Use this for initialization
	void Start()
	{
		GetComponent<SpriteRenderer>().sprite = tex1;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			GetComponent<SpriteRenderer>().sprite = tex1;
		}

		if (Input.GetKeyDown(KeyCode.W))
		{
			GetComponent<SpriteRenderer>().sprite = tex2;
		}

		if (Input.GetKeyDown(KeyCode.E))
		{
			GetComponent<SpriteRenderer>().sprite = tex3;
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			GetComponent<SpriteRenderer>().sprite = tex4;
		}
	}
}
