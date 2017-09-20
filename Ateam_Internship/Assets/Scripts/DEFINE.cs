using System.Collections;

//--------------------------------------------------
// 説明		定数定義用クラス
//			スクリプトをまたいで定数を使いたい時などに使用
// 定義例	public const int GAME_MATCH_POINT = 3;
// 使用例	DEFINE.GAME_MATCH_POINT
//--------------------------------------------------
public static class DEFINE
{
	public const int PUZZLE_PIECE_MAX = 39;     // パズルのピースの最大数

	//--------------------------------------------------
	// 列挙体定義 (ホントはDEFINEとは別のクラスにするべき)
	//--------------------------------------------------

	// パズルのピースの状態
	public enum PUZZLE_PIECE_STATE
	{
		NONE = 0,       // 何もなし
		PLAYER,         // プレイヤー
		ENEMY           // エネミー
	}

	// パズルピースの柄
	public enum PUZZLE_PIECE_SUIT
	{
		NONE = 0,       // 何もなし
		SPADE,          // スペード
		DIAMOND,        // ダイヤ
		HEART,          // ハート
		CLUB,           // クラブ
	}

    // ゲーム状態
    public enum GAME_STATE
    {
        NONE = 0,           // 何もなし
        PLAYER_TURN,        // プレイヤー
        ENEMY_TURN,         // エネミー
        PUZZLE_CLEAN,       // パズルクリーン
    }

	//--------------------------------------------------
	// 構造体定義  (ホントはDEFINEとは別のクラスにするべき)
	//--------------------------------------------------

	// キャラクター情報構造体
	public struct Character
	{
		public float Life;                         // ライフ
		public float Attack;                       // アタック
		public DEFINE.PUZZLE_PIECE_SUIT Skill1;    // スキルに必要なスート1
		public DEFINE.PUZZLE_PIECE_SUIT Skill2;    // スキルに必要なスート2

		public Character(float life, float attack, DEFINE.PUZZLE_PIECE_SUIT skill1, DEFINE.PUZZLE_PIECE_SUIT skill2)
		{
			Life = life;            // ライフ
			Attack = attack;        // アタック
			Skill1 = skill1;        // スキル1
			Skill2 = skill2;        // スキル2
		}
	}

	// パーティ情報構造体
	public struct Party
	{
		public Character Chara_0;      // リーダー
		public Character Chara_1;      // キャラ1(アイコン 左)
		public Character Chara_2;      // キャラ2(アイコン 中)
		public Character Chara_3;      // キャラ3(アイコン 右)

		// コンストラクタ
		public Party(Character chara0, Character chara1, Character chara2, Character chara3)
		{
			Chara_0 = chara0;       // リーダー
			Chara_1 = chara1;       // キャラ1(アイコン 左)
			Chara_2 = chara2;       // キャラ2(アイコン 中)
			Chara_3 = chara3;       // キャラ3(アイコン 右)
		}
	};
}
