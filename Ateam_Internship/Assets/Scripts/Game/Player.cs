//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Player : MonoBehaviour
//{
//	// キャラクター情報構造体
//	struct Character
//	{
//		private float Life;							// ライフ
//		private DEFINE.PUZZLE_PIECE_SUIT Skiil1;	// スキルに必要なスート1
//		private DEFINE.PUZZLE_PIECE_SUIT Skiil2;	// スキルに必要なスート2
//	}

//	// パーティ情報構造体
//	struct PlayerParty
//	{
//		public Character Chara_0;		// リーダー
//		public Character Chara_1;		// キャラ1(アイコン 左)
//		public Character Chara_2;      // キャラ2(アイコン 中)
//		public Character Chara_3;      // キャラ3(アイコン 右)

//		public PlayerParty (Character Chara0, Character Chara1, Character Chara2, Character Chara3)
//		{
//			Chara0 = Chara0;
//			Chara1 = Chara1;
//			Chara2 = Chara2;
//			Chara3 = Chara3;
//		}
//	};

//	private PlayerParty Party;		// プレイヤーのパーティ情報

//	// Use this for initialization
//	void Start()
//	{
//		Party = new PlayerParty()
//	}

//	// Update is called once per frame
//	void Update()
//	{

//	}

//	// プレイヤーのパーティ情報を取得
//	public PlayerParty GetPlayerParty()
//	{
//		return Party;
//	}
//}
