using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PieceList : MonoBehaviour
{
    //public GameObject piecePrefab;
    //public Sprite[] pieceSprites;
    //[SerializeField]
    //private GameObject gameManager;
    
    private GameObject startPiece;      // 最初にドラッグしたピース
    private GameObject nextPiece;
    private GameObject endPiece;        // 最後にドラッグしたピース
    private string currentName;         // 名前判定用のstring変数
    private int nCnt;                   // 塗った回数

	private GameObject[] Puzzle;	// パズルのピース情報

    //削除するピースのリスト
    private List<GameObject> removablePieceList = new List<GameObject>();

	private GameManager gameManager;

	// Use this for initialization
	void Start()
    {
		// パズルの情報を取得
		Puzzle = GetComponent<PuzzleManager>().GetPuzzle();

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
                    nextPiece = hitObj;
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

        if (hit.collider != null)
        {
			// ピースの状態が何もなければ
			if(hit.transform.GetComponent<PuzzlePiece>().GetState() == DEFINE.PUZZLE_PIECE_STATE.NONE)
			{
				GameObject hitObj = hit.collider.gameObject;

				// 最後とは別オブジェクトである時
				if (startPiece != hitObj && endPiece != hitObj)   
				{
					if (hitObj != null && endPiece != null)
					{
						//２つのオブジェクトの距離を取得
						float fDistance = Vector2.Distance(hitObj.transform.position, endPiece.transform.position);

                        int nRemoveCnt = removablePieceList.Count;

                        for (int Cnt = 0; Cnt < removablePieceList.Count; Cnt++)
                        {
                            if (fDistance < 1.0f)
                            {
                                //削除対象のオブジェクトを格納
                                endPiece = removablePieceList[Cnt];
                                PushToList(removablePieceList[Cnt]);

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
        int nRemoveCnt = removablePieceList.Count;
		
		if (nRemoveCnt >= 2 && nRemoveCnt <= 8)
        {
            for (int i = 0; i < nRemoveCnt; i++)
            {
                ChangeColor(removablePieceList[i], new Color(1.0f, 1.0f, 1.0f, 1.0f));

				// プレイヤーのターンだったら
                if (gameManager.GetGameState() == DEFINE.GAME_STATE.PLAYER_TURN)
                {
					// リストに格納されているピースの状態を変更
					removablePieceList[i].GetComponent<PuzzlePiece>().SetState(DEFINE.PUZZLE_PIECE_STATE.PLAYER);
                }

				// エネミーのターンだったら
                if (gameManager.GetGameState() == DEFINE.GAME_STATE.ENEMY_TURN)
                {
					// リストに格納されているピースの状態を変更
					removablePieceList[i].GetComponent<PuzzlePiece>().SetState(DEFINE.PUZZLE_PIECE_STATE.ENEMY);
				}
            }

            nCnt++;

			// ターンを変更
			if (gameManager.GetGameState() == DEFINE.GAME_STATE.PLAYER_TURN)
			{
				// エネミーターンに変更
				gameManager.SetGameState(DEFINE.GAME_STATE.ENEMY_TURN);
			}
			else if (gameManager.GetGameState() == DEFINE.GAME_STATE.ENEMY_TURN)
			{
				// プレイヤーのターンに変更
				gameManager.SetGameState(DEFINE.GAME_STATE.PLAYER_TURN);
			}
		}
        else
        {
            //色の透明度を戻す
            for (int i = 0; i < nRemoveCnt; i++)
            {
                ChangeColor(removablePieceList[i], new Color(1.0f, 1.0f, 1.0f, 1.0f));
            }
        }
        // 初期化
        startPiece = null;
        endPiece = null;

		//削除対象オブジェクトリストの初期化
		removablePieceList = new List<GameObject>();
	}

    public void PushToList(GameObject obj)
    {
        removablePieceList.Add(obj);

        ChangeColor(obj, new Color(1.0f, 1.0f, 1.0f, 0.5f));
    }

    public void RemoveToList(GameObject obj)
    {
        removablePieceList.Remove(obj);

        ChangeColor(obj, new Color(1.0f, 1.0f, 1.0f, 1.0f));
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
}