using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	//--------------------------------------------------
	// 変数定義
	//--------------------------------------------------
	private DEFINE.GAME_STATE GameState;        // ゲーム状態情報
	private Player player;                      // プレイヤー情報
	private Enemy enemy;						// エネミー情報
	private PieceList PieceList;                // ピースのリスト
	private SkillChecker skillChecker;			// スキルチェック情報

	private bool PuzzleFlag;                    // パズルフラグ
	private bool SkillFlag;                     // スキルフラグ
	private bool AttackFlag;                    // アタックフラグ

	[SerializeField] IconManager iconPlayer;		// プレイヤーアイコン
	[SerializeField] IconManager iconEnemy;			// エネミーアイコン

	//--------------------------------------------------
	// スタート
	//--------------------------------------------------
	void Start()
	{
		GameState = DEFINE.GAME_STATE.PLAYER_TURN;                  // ゲーム状態
		player = GetComponent<Player>();                            // プレイヤー情報を取得
		enemy = GetComponent<Enemy>();								// エネミー情報を取得
		PieceList = GetComponentInChildren<PieceList>();                      // ピースのリストを取得
		skillChecker = GetComponent<SkillChecker>();				// スキル情報を取得

		//Screen.SetResolution(340, 640, false, 60);
	}


	//--------------------------------------------------
	// アップデート
	//--------------------------------------------------
	void Update()
	{
		bool[] SkillActive;     // スキルが発動しているかどうか

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

			case DEFINE.GAME_STATE.PLAYER_TURN:     // P1ターン

				//bool[] SkillActive;		// スキルが発動しているかどうか

				// アイコンを切り替え
				iconPlayer.enabled = true;
				iconEnemy.enabled = false;

				// パズルが終了していたら
				if (PuzzleFlag == true)
				{
					// スキルが発動したかチェック
					if(SkillFlag == false)
					{
						SkillActive = skillChecker.SkillCheckList(player.GetPlayerParty(), PieceList);
						SkillFlag = true;
					}

					// 攻撃フラグオンだったら
					if(AttackFlag == false)
					{
						player.PlayerAttack();
						AttackFlag = true;
					}
					
					SetGameState(DEFINE.GAME_STATE.ENEMY_TURN);
					PuzzleFlag = false;
					SkillFlag = false;
					AttackFlag = false;
				}

				// エネミーの体力が0だったら
				if (enemy.GetPartyLife() <= 0)
				{
					FadeManager.Instance.LoadScene("ResultScene", 0.5f);
				}

				break;

			case DEFINE.GAME_STATE.ENEMY_TURN:      // エネミーターン

				//bool[] SkillActive;     // スキルが発動しているかどうか

				// アイコンを切り替え
				iconPlayer.enabled = false;
				iconEnemy.enabled = true;

				// パズルが終了していたら
				if (PuzzleFlag == true)
				{
					// スキルが発動したかチェック
					if (SkillFlag == false)
					{
						SkillActive = skillChecker.SkillCheckList(enemy.GetEnemyParty(), PieceList);
						SkillFlag = true;
					}

					// 攻撃フラグオンだったら
					if (AttackFlag == false)
					{
						enemy.EnemyAttack();
						AttackFlag = true;
					}

					SetGameState(DEFINE.GAME_STATE.PLAYER_TURN);
					PuzzleFlag = false;
					SkillFlag = false;
					AttackFlag = false;
				}
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

	// パズルが終了したフラグを設定
	public void SetPuzzleFlag(bool flag)
	{
		PuzzleFlag = flag;
	}

	// パズルが終了したフラグを取得
	public bool GetPuzzleFlag()
	{
		return PuzzleFlag;
	}
}
