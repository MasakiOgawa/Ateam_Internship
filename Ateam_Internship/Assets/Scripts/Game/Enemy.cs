using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	private DEFINE.Party EnemyParty;						// エネミーのパーティ情報
	private float PartyLife;                                // パーティのライフ
	private float PartyAttack;                                // パーティのアタック
	[SerializeField] private GaugeController lifeGauge;      // 体力ゲージ
	[SerializeField] private Player player;                     // プレイヤー情報
	[SerializeField] private PieceList pieceList;				// ピース情報

	// Use this for initialization
	void Start()
	{
		EnemyParty = new DEFINE.Party(
			new DEFINE.Character(100, 100, DEFINE.PUZZLE_PIECE_SUIT.SPADE, DEFINE.PUZZLE_PIECE_SUIT.SPADE),           // リーダー
			new DEFINE.Character(100, 100, DEFINE.PUZZLE_PIECE_SUIT.DIAMOND, DEFINE.PUZZLE_PIECE_SUIT.DIAMOND),		// キャラ1(アイコン 左)
			new DEFINE.Character(100, 100, DEFINE.PUZZLE_PIECE_SUIT.HEART, DEFINE.PUZZLE_PIECE_SUIT.HEART),        // キャラ2(アイコン 中)
			new DEFINE.Character(100, 100, DEFINE.PUZZLE_PIECE_SUIT.CLUB, DEFINE.PUZZLE_PIECE_SUIT.CLUB));          // キャラ3(アイコン 右)

		// パーティのライフを設定
		PartyLife = EnemyParty.Chara_0.Life + EnemyParty.Chara_1.Life + EnemyParty.Chara_2.Life + EnemyParty.Chara_3.Life;
		PartyAttack = EnemyParty.Chara_0.Attack + EnemyParty.Chara_1.Attack + EnemyParty.Chara_2.Attack + EnemyParty.Chara_3.Attack;

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

	// エネミーのパーティ情報を取得
	public DEFINE.Party GetEnemyParty()
	{
		return EnemyParty;
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

	// エネミーの攻撃
	public void EnemyAttack()
	{
		// 消した個数を取得
		int PieceNum = pieceList.GetListCount();

		// 攻撃
		player.SubPartyLife(PartyAttack);
	}
}
