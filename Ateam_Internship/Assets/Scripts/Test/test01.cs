using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 画面上部のペンの色表示用
public class test01 : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
		GetComponent<SpriteRenderer>().color = new Color(1, 0.5f, 1, 1);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			GetComponent<SpriteRenderer>().color = new Color(1, 0.5f, 1, 1);
		}

		if (Input.GetKeyDown(KeyCode.S))
		{
			GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 1, 1);
		}

		if (Input.GetKeyDown(KeyCode.D))
		{
			GetComponent<SpriteRenderer>().color = Color.white;
		}

		if (Input.GetKeyDown(KeyCode.F))
		{
			GetComponent<SpriteRenderer>().color = new Color(1, 0.5f, 1, 1);
		}
	}
}
