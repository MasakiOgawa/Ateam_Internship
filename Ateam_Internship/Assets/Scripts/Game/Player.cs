using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private DEFINE.Party PlayerParty;		// プレイヤーのパーティ情報
	private float PartyLife;                // パーティのライフ
	private float PartyAttack;                // パーティの攻撃力
	[SerializeField] private GaugeController lifeGauge;     // 体力ゲージ
	[SerializeField] private Enemy enemy;                   // エネミー情報
	[SerializeField] private PieceList pieceList;			// ピースリスト情報

	// Use this for initialization
	void Start()
	{
		PlayerParty = new DEFINE.Party(
			new DEFINE.Character(100, 10, DEFINE.PUZZLE_PIECE_SUIT.SPADE, DEFINE.PUZZLE_PIECE_SUIT.CLUB),			// リーダー
			new DEFINE.Character(100, 10, DEFINE.PUZZLE_PIECE_SUIT.DIAMOND, DEFINE.PUZZLE_PIECE_SUIT.HEART),      // キャラ1(アイコン 左)
			new DEFINE.Character(100, 10, DEFINE.PUZZLE_PIECE_SUIT.HEART, DEFINE.PUZZLE_PIECE_SUIT.DIAMOND),			// キャラ2(アイコン 中)
			new DEFINE.Character(100, 10, DEFINE.PUZZLE_PIECE_SUIT.CLUB, DEFINE.PUZZLE_PIECE_SUIT.SPADE));			// キャラ3(アイコン 右)

		// パーティの総ステータスを設定
		PartyLife = PlayerParty.Chara_0.Life + PlayerParty.Chara_1.Life + PlayerParty.Chara_2.Life + PlayerParty.Chara_3.Life;
		PartyAttack = PlayerParty.Chara_0.Attack + PlayerParty.Chara_1.Attack + PlayerParty.Chara_2.Attack + PlayerParty.Chara_3.Attack;

		// 体力ゲージを設定
		lifeGauge.SetGaugeMax(PartyLife);
		lifeGauge.SetGaugeValue(PartyLife);
	}

	// Update is called once per frame
	void Update()
	{
		// ライフゲージに現在の値を設定
		lifeGauge.SetGaugeValue(PartyLife);
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
		// 消した個数を取得
		int PieceNum = pieceList.GetListCount();
		
		// 攻撃
		enemy.SubPartyLife(PartyAttack * (1 + (PieceNum * 0.2f)));
	}
}
