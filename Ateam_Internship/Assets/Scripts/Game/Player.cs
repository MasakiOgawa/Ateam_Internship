using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	// キャラクター情報構造体
	public struct Character
	{
		private float Life;                         // ライフ
		private float Attack;						// アタック
		private DEFINE.PUZZLE_PIECE_SUIT Skiil1;    // スキルに必要なスート1
		private DEFINE.PUZZLE_PIECE_SUIT Skiil2;    // スキルに必要なスート2

		public Character(float life, float attack, DEFINE.PUZZLE_PIECE_SUIT skiil1, DEFINE.PUZZLE_PIECE_SUIT skiil2)
		{
			Life = life;			// ライフ
			Attack = attack;		// アタック
			Skiil1 = skiil1;		// スキル1
			Skiil2 = skiil2;		// スキル2
		}
	}

	// パーティ情報構造体
	public struct Party
	{
		Character Chara_0;      // リーダー
		Character Chara_1;      // キャラ1(アイコン 左)
		Character Chara_2;      // キャラ2(アイコン 中)
		Character Chara_3;      // キャラ3(アイコン 右)

		// コンストラクタ
		public Party(Character chara0, Character chara1, Character chara2, Character chara3)
		{
			Chara_0 = chara0;       // リーダー
			Chara_1 = chara1;       // キャラ1(アイコン 左)
			Chara_2 = chara2;       // キャラ2(アイコン 中)
			Chara_3 = chara3;       // キャラ3(アイコン 右)
		}
	};

	private Party PlayerParty;      // プレイヤーのパーティ情報
	public float MaxLife;			// プレイヤーの体力

	// Use this for initialization
	void Start()
	{
		PlayerParty = new Party(
			new Character(100, 10, DEFINE.PUZZLE_PIECE_SUIT.CLUB, DEFINE.PUZZLE_PIECE_SUIT.CLUB),        // リーダー
			new Character(100, 10, DEFINE.PUZZLE_PIECE_SUIT.CLUB, DEFINE.PUZZLE_PIECE_SUIT.CLUB),        // キャラ1(アイコン 左)
			new Character(100, 10, DEFINE.PUZZLE_PIECE_SUIT.CLUB, DEFINE.PUZZLE_PIECE_SUIT.CLUB),        // キャラ2(アイコン 中)
			new Character(100, 10, DEFINE.PUZZLE_PIECE_SUIT.CLUB, DEFINE.PUZZLE_PIECE_SUIT.CLUB));       // キャラ3(アイコン 右)

	}

	// Update is called once per frame
	void Update()
	{

	}

	// プレイヤーのパーティ情報を取得
	public Party GetPlayerParty()
	{
		return PlayerParty;
	}
}
