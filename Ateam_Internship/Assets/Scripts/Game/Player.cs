using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private DEFINE.Party PlayerParty;		// プレイヤーのパーティ情報
	private float PartyLife;                // パーティのライフ
	[SerializeField]private GaugeController lifeGauge;		// 体力ゲージ

	// Use this for initialization
	void Start()
	{
		PlayerParty = new DEFINE.Party(
			new DEFINE.Character(100, 10, DEFINE.PUZZLE_PIECE_SUIT.SPADE, DEFINE.PUZZLE_PIECE_SUIT.SPADE),			// リーダー
			new DEFINE.Character(100, 10, DEFINE.PUZZLE_PIECE_SUIT.DIAMOND, DEFINE.PUZZLE_PIECE_SUIT.DIAMOND),      // キャラ1(アイコン 左)
			new DEFINE.Character(100, 10, DEFINE.PUZZLE_PIECE_SUIT.HEART, DEFINE.PUZZLE_PIECE_SUIT.HEART),			// キャラ2(アイコン 中)
			new DEFINE.Character(100, 10, DEFINE.PUZZLE_PIECE_SUIT.CLUB, DEFINE.PUZZLE_PIECE_SUIT.CLUB));			// キャラ3(アイコン 右)

		// パーティのライフを設定
		PartyLife = PlayerParty.Chara_0.Life + PlayerParty.Chara_1.Life + PlayerParty.Chara_2.Life + PlayerParty.Chara_3.Life;
		
		// 体力ゲージを設定
		lifeGauge.SetGaugeMax(PartyLife);
		lifeGauge.SetGaugeValue(PartyLife);
	}

	// Update is called once per frame
	void Update()
	{

	}

	// プレイヤーのパーティ情報を取得
	public DEFINE.Party GetPlayerParty()
	{
		return PlayerParty;
	}

	// パーティのライフを減算
	public void SubPartyLife(float life)
	{
		PartyLife -= life;
	}

	// パーティのライフ取得
	public float GetPartyLife()
	{
		return PartyLife;
	}

	// プレイヤーの攻撃
	public void PlayerAttack()
	{

	}
}
