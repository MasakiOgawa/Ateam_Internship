using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
	private AudioSource[] Audio;        // オーディオ情報

	// Use this for initialization
	void Start()
	{
		// オーディオ情報を取得
		Audio = GetComponents<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	// SE再生
	public void PlaySE(int ID)
	{
		// 最大数を超えていなかったら
		if(ID < Audio.Length)
		{
			Audio[ID].PlayOneShot(Audio[ID].clip);
		}
	}
}
