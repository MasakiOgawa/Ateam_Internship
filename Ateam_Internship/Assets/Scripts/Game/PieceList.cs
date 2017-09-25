using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PieceList : MonoBehaviour
{
    private GameObject startPiece;      // 最初にドラッグしたピース
    private GameObject endPiece;        // 最後にドラッグしたピース
    private string currentName;         // 名前判定用のstring変数
    private int nCnt;                   // 塗った回数

    private static int nPrevRemoveCnt;
    private int nRemoveCnt;

    //private GameObject[] Puzzle;	// パズルのピース情報

    //削除するピースのリスト
    public List<GameObject> removablePieceList = new List<GameObject>();

	private GameManager gameManager;		// ゲームマネージャー情報

	// Use this for initialization
	void Start()
    {
        // パズルの情報を取得
        //Puzzle = GetComponent<PuzzleManager>().GetPuzzle();

        // カウンタ初期化
        nCnt = 0;

		gameManager = transform.parent.GetComponent<GameManager>();

	}

    // Update is called once per frame
    void Update()
	{
		if (Input.GetMouseButtonDown(0) && startPiece == null)
		{
			// クリック開始
			OnDragStart();
		}
		else if (Input.GetMouseButtonUp(0))
		{
			//クリックを終えた時
			OnDragEnd();
		}
		else if (startPiece != null)
		{
			// クリック中
			OnDragging();
		}
	}

	// クリック開始処理
	public void OnDragStart()
	{
		// クリックした位置のオブジェクトを取得
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

		if (hit.collider != null)
		{
			// ピースの状態が何もなければ
			if (hit.transform.GetComponent<PuzzlePiece>().GetState() == DEFINE.PUZZLE_PIECE_STATE.NONE)
			{
				GameObject hitObj = hit.collider.gameObject;

				//オブジェクトの名前を前方一致で判定
				string pieceName = hitObj.name;

				if (pieceName.StartsWith("PuzzlePiece"))
				{
					startPiece = hitObj;
                    endPiece = hitObj;
					currentName = hitObj.name;

					//削除対象オブジェクトリストの初期化
					removablePieceList = new List<GameObject>();

                    //削除対象のオブジェクトを格納
                    PushToList(hitObj);

                }
			}
		}
	}

    // クリック中の処理
    public void OnDragging()
    {
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		//RaycastHit2D hit01 = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
		bool ListFlag = false;      // リスト比較フラグ

		if (hit.collider != null)
		{
			// ピースの状態が何もなければ
			if (hit.transform.GetComponent<PuzzlePiece>().GetState() == DEFINE.PUZZLE_PIECE_STATE.NONE)
			{
				GameObject hitObj = hit.collider.gameObject;

				// 最後とは別オブジェクトである時
				if (endPiece != hitObj)
				{
					if (hitObj != null)
					{
						//２つのオブジェクトの距離を取得
						float fDistance = Vector2.Distance(hitObj.transform.position, endPiece.transform.position);

						if (fDistance < 1.0f)
						{
							// 既にリストにピースが入っていないか比較
							for (int Cnt = 0; Cnt < removablePieceList.Count; Cnt++)
							{
								if (hitObj == removablePieceList[Cnt])
								{
									// 既にリストに格納されていたらフラグをオンにする
									ListFlag = true;
								}
							}

							// リストの要素が最大数未満だったら
							if (removablePieceList.Count < 8)
							{
								// リストにまだ格納されていなかったら
								if (ListFlag == false)
								{
									//削除対象のオブジェクトを格納
									endPiece = hitObj;
									PushToList(hitObj);
								}
							}
							else
							{
								endPiece = removablePieceList[removablePieceList.Count - 2];
								RemoveToList(removablePieceList[removablePieceList.Count - 1]);
							}
						}
					}
				}
			}
		}
	}

    // クリック終了時処理
    public void OnDragEnd()
    {
        if (removablePieceList.Count >= 2 && removablePieceList.Count <= 8)
        {
            for (int i = 0; i < removablePieceList.Count; i++)
            {
                //ChangeColor(removablePieceList[i], new Color(0.5f, 0.5f, 0.5f, 1.0f));

                // プレイヤーのターンだったら
                if (gameManager.GetGameState() == DEFINE.GAME_STATE.PLAYER_TURN)
                {
					// リストに格納されているピースの状態を変更
					removablePieceList[i].GetComponent<PuzzlePiece>().SetState(DEFINE.PUZZLE_PIECE_STATE.PLAYER);
                }
				// エネミーのターンだったら
                else if (gameManager.GetGameState() == DEFINE.GAME_STATE.ENEMY_TURN)
                {
					// リストに格納されているピースの状態を変更
					removablePieceList[i].GetComponent<PuzzlePiece>().SetState(DEFINE.PUZZLE_PIECE_STATE.ENEMY);
				}
            }

            // 塗った数カウント
            nCnt++;

			// 4回塗られたら
			if (nCnt == 4)
			{
				// ピースをクリア
				GetComponent<PuzzleManager>().AllClean();

				// ピースを生成
				GetComponent<PuzzleManager>().CreateAllPiece();

				// カウンタ初期化
				nCnt = 0;
			}

            // パズル終了フラグオン
            gameManager.SetPuzzleFlag(true);
		}
        else
        {
            //色の透明度を戻す
            for (int i = 0; i < removablePieceList.Count; i++)
            {
                ChangeColor(removablePieceList[i], new Color(0.5f, 0.5f, 0.5f, 1.0f));
            }

			ListInit();
		}
	}

    public void PushToList(GameObject obj)
    {
        removablePieceList.Add(obj);

        ChangeColor(obj, new Color(0.35f, 0.35f, 0.35f, 0.35f));
    }

    public void RemoveToList(GameObject obj)
    {
        removablePieceList.Remove(obj);

        ChangeColor(obj, new Color(0.5f, 0.5f, 0.5f, 1.0f));
    }

    // 色変え
    void ChangeColor(GameObject obj, Color color)
    {
        //SpriteRendererコンポーネントを取得
        SpriteRenderer pieceTexture = obj.GetComponent<SpriteRenderer>();

        pieceTexture.color = new Color(color.r, color.g, color.b, color.a);
    }

	// 消去するピースの情報を取得
	public List<GameObject> GetRemovaleList()
	{
		return removablePieceList;
	}

	// リスト初期化
	public void ListInit()
	{
		// 初期化
		startPiece = null;
		endPiece = null;

		//削除対象オブジェクトリストの初期化
		removablePieceList.Clear();/* = new List<GameObject>();*/
	}

    // 塗った回数を取得
    public int GetFillCount()
    {
        return nCnt;
    }
}