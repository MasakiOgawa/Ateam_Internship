using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageRedFlash : MonoBehaviour
{
	private Image img;
	private int cnt;

	// Use this for initialization
	void Start()
	{
		img = GetComponent<Image>();
		//SetRedFlash(true);
	}

	// Update is called once per frame
	void Update()
	{
		if(cnt <= 0)
		{
			img.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		}
		else if(cnt > 0)
		{
			cnt--;
		}
	}

	public void SetRedFlash(bool flag)
	{
		if(flag == true)
		{
			img.color = new Color(1.0f, 0.2f, 0.2f, 1.0f);
		}
		else if (flag == false)
		{
			img.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		}

		cnt = 60;
	}
}
