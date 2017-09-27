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
    private bool EffectFlag;

    

	[SerializeField] private IconManager iconPlayer;		// プレイヤーアイコン
	[SerializeField] private IconManager iconEnemy;			// エネミーアイコン
    [SerializeField] private UiText uiText;
    [SerializeField] private UiText2 uiText2;
    [SerializeField] private EffectManager em;
    [SerializeField] int hoge;
    [SerializeField] private GameObject normalObj;
	[SerializeField] private SEManager SE;

    private int nCnt;
	private int Cnt01;
	private bool Flag00;

    //--------------------------------------------------
    // スタート
    //--------------------------------------------------
    void Start()
	{
		GameState = DEFINE.GAME_STATE.PLAYER_TURN;                  // ゲーム状態
		player = GetComponent<Player>();                            // プレイヤー情報を取得
		enemy = GetComponent<Enemy>();								// エネミー情報を取得
		PieceList = GetComponentInChildren<PieceList>();                      // ピースのリストを取得
		skillChecker = GetComponent<SkillChecker>();                // スキル情報を取得

        nCnt = 0;
		SE.PlaySE(1);
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
                        //Debug.Log(SkillActive[0] );

                        if(SkillActive[0] == true)
                        {
                            GameObject gameObj;
                            gameObj = Instantiate(normalObj, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), transform);
                            gameObj.GetComponent<NormalEffect>().SetPoint(new Vector3(-1.4f, 1.65f, 0), new Vector3(-6, 3.3f, 0), new Vector3(0.46f, 1.97f, 0), new Vector3(1.42f, 2.98f, 0), 0);
                           
                        }
                        else if(SkillActive[0] == false)
                        {
                            GameObject gameObj;
                            gameObj = Instantiate(normalObj, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), transform);
                            gameObj.GetComponent<NormalEffect>().SetPoint(new Vector3(-1.4f, 1.65f, 0), new Vector3(-6, 3.3f, 0), new Vector3(0.46f, 1.97f, 0), new Vector3(1.42f, 2.98f, 0), 5);
                           
                        }

                        if (SkillActive[1] == true)
                        {
                            GameObject gameObj;
                            gameObj = Instantiate(normalObj, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), transform);
                            gameObj.GetComponent<NormalEffect>().SetPoint(new Vector3(-0.03f, 1.08f, 0), new Vector3(-2.9f, 2.7f, 0), new Vector3(0.77f, 1.45f, 0), new Vector3(1.42f, 2.97f, 0), 1);
                           
                        }
                        else if (SkillActive[1] == false)
                        {
                            GameObject gameObj;
                            gameObj = Instantiate(normalObj, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), transform);
                            gameObj.GetComponent<NormalEffect>().SetPoint(new Vector3(-0.03f, 1.08f, 0), new Vector3(-2.9f, 2.7f, 0), new Vector3(0.77f, 1.45f, 0), new Vector3(1.42f, 2.97f, 0),	 5);
                           
                        }

                        if (SkillActive[2] == true)
                        {
                            GameObject gameObj;
                            gameObj = Instantiate(normalObj, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), transform);
                            gameObj.GetComponent<NormalEffect>().SetPoint(new Vector3(0.79f, 1.08f, 0), new Vector3(0.76f, 2.7f, 0), new Vector3(1.68f, 1.67f, 0), new Vector3(1.42f, 2.98f, 0), 2);
                            //Debug.Log("4");
                        }
                        else if (SkillActive[2] == false)
                        {
                            GameObject gameObj;
                            gameObj = Instantiate(normalObj, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), transform);
                            gameObj.GetComponent<NormalEffect>().SetPoint(new Vector3(0.79f, 1.08f, 0), new Vector3(0.76f, 2.7f, 0), new Vector3(1.68f, 1.67f, 0), new Vector3(1.42f, 2.98f, 0), 5	);

						}

                        if (SkillActive[3] == true)
                        {
                            GameObject gameObj;
                            gameObj = Instantiate(normalObj, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), transform);
                            gameObj.GetComponent<NormalEffect>().SetPoint(new Vector3(1.67f, 1.08f, 0), new Vector3(0.52f, 1.92f, 0), new Vector3(2.36f, 2.34f, 0), new Vector3(1.42f, 2.9f, 0), 3);
                            
                        }
                        else if (SkillActive[3] == false)
                        {
                            GameObject gameObj;
                            gameObj = Instantiate(normalObj, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), transform);
							gameObj.GetComponent<NormalEffect>().SetPoint(new Vector3(1.67f, 1.08f, 0), new Vector3(0.52f, 1.92f, 0), new Vector3(2.36f, 2.34f, 0), new Vector3(1.42f, 2.9f, 0), 5);

						}

                        SkillFlag = true;
					}

					// 攻撃フラグオンだったら
					if(AttackFlag == false)
					{
						player.PlayerAttack();
						AttackFlag = true;
                    }

                    // エフェクトが終わったら
                    if (EffectFlag == true && enemy.GetPartyLife() > 0)
                    {
                        SetGameState(DEFINE.GAME_STATE.ENEMY_TURN);
                        uiText.SetUiNum(1);

                        PuzzleFlag = false;
                        SkillFlag = false;
                        AttackFlag = false;
                        EffectFlag = false;
						
					}
                }

				// エネミーの体力が0だったら
				if (enemy.GetPartyLife() <= 0)
				{
                    nCnt++;
                    uiText.SetShowUi(false);

                }

                if (nCnt >= 120)
                {
                    // 勝利UI
                    uiText2.SetUiNum(0);

					if(Flag00 == false)
					{
						SE.PlaySE(5);
						SE.PlaySE(3);
						//SE.PlaySE(16);
						Flag00 = true;
					}

					if (Input.GetMouseButtonDown(0) /*| Input.GetTouch(0).phase == TouchPhase.Began*/) // タッチにかえる
                    {
                        FadeManager.Instance.LoadScene("ResultScene", 0.5f);
                    }
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

						em.PlayEffect(4, new Vector3(-1.38f, 1.56f, 0), new Quaternion(0, 0, 0, 0));

						SE.PlaySE(15);
						SE.PlaySE(2);

						SkillFlag = true;
					}

					// 攻撃フラグオンだったら
					if (AttackFlag == false)
					{
						enemy.EnemyAttack();
						AttackFlag = true;
                        EffectFlag = true;
                    }

                    // エフェクトが終わったら
                    if(EffectFlag == true && player.GetPartyLife() > 0)
                    {
                        SetGameState(DEFINE.GAME_STATE.PLAYER_TURN);
                        uiText.SetUiNum(0);

                        PuzzleFlag = false;
                        SkillFlag = false;
                        AttackFlag = false;
                        EffectFlag = false;
						
					}

					
				}

                // プレイヤーの体力が0だったら
                if (player.GetPartyLife() <= 0)
                {
                    nCnt++;
                    uiText.SetShowUi(false);
                }

                if (nCnt >= 120)
                {
                    // 勝利UI
                    uiText2.SetUiNum(1);

                    if (Input.GetMouseButtonDown(0) /*| Input.GetTouch(0).phase == TouchPhase.Began*/) // タッチにかえる
                    {
                        FadeManager.Instance.LoadScene("ResultScene", 0.5f);
                    }
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

    public void SetEffectFlag(bool setFlag)
    {
        EffectFlag = setFlag;
    }
}
