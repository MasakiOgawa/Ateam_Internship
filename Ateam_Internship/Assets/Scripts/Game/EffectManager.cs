using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
	// エフェクト情報
	[SerializeField] private GameObject[] EffectObj;


	// Use this for initialization
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{

	}

	// エフェクト再生
	public void PlayEffect(int ID, Vector3 pos, Quaternion rot)
	{

		// 最大数を超えていなかったら
		if (ID < EffectObj.Length)
		{
			// エフェクトのインスタンス生成
			Instantiate(EffectObj[ID], pos, rot, transform);
		}
	}
}
