using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	//--------------------------------------------------
	// 変数定義
	//--------------------------------------------------
	private DEFINE.GAME_STATE GameState;		// ゲーム状態情報

	//--------------------------------------------------
	// スタート
	//--------------------------------------------------
	void Start()
	{
		GameState = DEFINE.GAME_STATE.PLAYER_TURN;  // ゲーム状態

		Screen.SetResolution(340, 640, false, 60);
	}


	//--------------------------------------------------
	// アップデート
	//--------------------------------------------------
	void Update()
	{
		// ESCキーが押されたらゲーム終了
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}

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

	// ゲーム状態を取得
    public DEFINE.GAME_STATE GetGameState()
    {
        return GameState;
    }

	// ゲーム状態を設定
	public void SetGameState(DEFINE.GAME_STATE state)
	{
		GameState = state;
	}
}
