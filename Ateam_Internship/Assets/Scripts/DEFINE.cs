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
	// 列挙体定義
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
}
