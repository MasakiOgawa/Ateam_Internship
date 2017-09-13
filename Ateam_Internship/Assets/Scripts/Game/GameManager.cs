using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	//--------------------------------------------------
	// 列挙体定義
	//--------------------------------------------------

	// ゲーム状態
	private enum GAME_STATE
	{
		NONE = 0,			// 何もなし
		PLAYER_TURN,		// プレイヤー
		ENEMY_TURN,			// エネミー
		PUZZLE_CLEAN,		// パズルクリーン
	}


	//--------------------------------------------------
	// 変数定義
	//--------------------------------------------------
	private GAME_STATE GameState;		// ゲーム状態情報

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
			case GAME_STATE.NONE:				// 何もない

				break;

			case GAME_STATE.PLAYER_TURN:		// P1ターン

				break;

			case GAME_STATE.ENEMY_TURN:		// P2ターン

				break;

			case GAME_STATE.PUZZLE_CLEAN:		// パズルクリーン

				break;
		}
	}
}
