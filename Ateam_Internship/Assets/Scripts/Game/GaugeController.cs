﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GaugeController : MonoBehaviour
{
	// コンスト 定数
	private const int SUB_GAUGE = 5;

	// メンバ 変数
	private Slider Gauge;       // ゲージの情報を取得
	private float Value;          // 現在の値

	private void Awake()
	{
		Gauge = GetComponent<Slider>();
	}

	// Use this for initialization
	private void Start()
	{
		
	}

	// Update is called once per frame
	private void Update()
	{
		// テスト
		//Gauge.value += 10;

		// ゲージを徐々に加算
		if(Gauge.value > Value)
		{
			Gauge.value -= SUB_GAUGE;
		}
	}

	// 現在の値を設定
	public void SetGaugeValue(float GaugeValue)
	{
		Value = GaugeValue;
	}

	// ゲージの最大値を設定
	public void SetGaugeMax(float maxValue)
	{
		Gauge.maxValue = maxValue;
		Gauge.value = maxValue;
	}
}
