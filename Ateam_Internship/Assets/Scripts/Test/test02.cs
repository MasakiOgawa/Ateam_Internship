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

	[SerializeField] private SEManager se;
	[SerializeField] private EffectManager em;

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

			se.PlaySE(3);

			em.PlayEffect(0, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
		}

		if (Input.GetKeyDown(KeyCode.W))
		{
			GetComponent<SpriteRenderer>().sprite = tex2;

			se.PlaySE(4);

			em.PlayEffect(3, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
		}

		if (Input.GetKeyDown(KeyCode.E))
		{
			GetComponent<SpriteRenderer>().sprite = tex3;

			se.PlaySE(5);

			em.PlayEffect(10, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			GetComponent<SpriteRenderer>().sprite = tex4;

			se.PlaySE(50);

			em.PlayEffect(15, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
		}
	}
}
