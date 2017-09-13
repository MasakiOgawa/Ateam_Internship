using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	//--------------------------------------------------
	// 変数定義
	//--------------------------------------------------
	private DEFINE.GAME_STATE GameState = DEFINE.GAME_STATE.ENEMY_TURN;		// ゲーム状態情報

	//--------------------------------------------------
	// スタート
	//--------------------------------------------------
	void Start()
	{

	}


	//--------------------------------------------------
	// アップデート
	//--------------------------------------------------
	void Update()
	{
		// ゲーム状態管理
		switch (GameState)
		{
			case DEFINE.GAME_STATE.NONE:				// 何もない

				break;

			case DEFINE.GAME_STATE.PLAYER_TURN:		// P1ターン

				break;

			case DEFINE.GAME_STATE.ENEMY_TURN:		// P2ターン

				break;

			case DEFINE.GAME_STATE.PUZZLE_CLEAN:		// パズルクリーン

				break;
		}
	}

    public DEFINE.GAME_STATE GetGameState()
    {
        return GameState;
    }
}
