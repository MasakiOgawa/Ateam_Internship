using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
	//--------------------------------------------------
	// 定数定義
	//--------------------------------------------------
	private const int PUZZLE_WIGHT = 7;		// パズルの幅
	private const int PUZZLE_HEIGHT = 6;    // パズルの高さ
	private const float PieceWidth = 0.713f;       // ピースの幅
	private const float PieceHeight = -0.826f;      // ピースの高さ

	//--------------------------------------------------
	// 変数定義
	//--------------------------------------------------

	// プライベート
	private GameObject[] PuzzlePiece = new GameObject[DEFINE.PUZZLE_PIECE_MAX];         // 全てのパズルピースの情報
    private int fillCount;
    private List<GameObject> removablePieceList;

    // インスペクター表示
    [SerializeField] private GameObject PuzzlePiece_Prehab;     // パズルのプレハブ情報
	[SerializeField] private PieceList puzzlePiece;             // パズルピース情報

    

    //--------------------------------------------------
    // スタート
    //--------------------------------------------------
    void Start()
	{
        // パズルのピース生成
        CreatePuzzlePiece();
	}

	//--------------------------------------------------
	// アップデート
	//--------------------------------------------------
	void Update()
	{
        // カウント情報取得
        fillCount = GetComponent<PieceList>().GetFillCount();
        //Debug.Log(fillCount);

	}

	//--------------------------------------------------
	// パズルのピースを生成
	//--------------------------------------------------
	void CreatePuzzlePiece()
	{
		int OddNumber = 0;      // 奇数の回数

		// パズルのピースを生成
		for (int Width = 0; Width < PUZZLE_WIGHT; Width++)
		{
			// 偶数だったら
			if (Width % 2 == 0)
			{
				for (int Height = 0; Height < PUZZLE_HEIGHT; Height++)
				{
					// ピースのインスタンス生成
					PuzzlePiece[((Width / 2) * 11) + Height] = Instantiate(PuzzlePiece_Prehab, new Vector3(PuzzlePiece_Prehab.transform.position.x + (PieceWidth * Width), PuzzlePiece_Prehab.transform.position.y + (PieceHeight * Height), 0), Quaternion.Euler(0, 0, 0), transform);

					// ランダムでピースの柄を設定
					switch (Random.Range(1, 5))
					{
						case 1:     // スペード
							PuzzlePiece[((Width / 2) * 11) + Height].GetComponent<PuzzlePiece>().SetSuit(DEFINE.PUZZLE_PIECE_SUIT.SPADE);
							break;

						case 2:     // ダイヤ
							PuzzlePiece[((Width / 2) * 11) + Height].GetComponent<PuzzlePiece>().SetSuit(DEFINE.PUZZLE_PIECE_SUIT.DIAMOND);
							break;

						case 3:     // ハート
							PuzzlePiece[((Width / 2) * 11) + Height].GetComponent<PuzzlePiece>().SetSuit(DEFINE.PUZZLE_PIECE_SUIT.HEART);
							break;

						case 4:     // クローバー
							PuzzlePiece[((Width / 2) * 11) + Height].GetComponent<PuzzlePiece>().SetSuit(DEFINE.PUZZLE_PIECE_SUIT.CLUB);
							break;
					}
				}
			}
			// 奇数だったら
			else if (Width % 2 == 1)
			{
				for (int Height = 0; Height < PUZZLE_HEIGHT - 1; Height++)
				{
					// ピースのインスタンス生成
					PuzzlePiece[(Width * 6 - OddNumber) + Height] = Instantiate(PuzzlePiece_Prehab, new Vector3(PuzzlePiece_Prehab.transform.position.x + (PieceWidth  * Width), -0.66f + (PieceHeight * Height), 0), Quaternion.Euler(0, 0, 0), transform);

					// ランダムでピースの柄を設定
					switch (Random.Range(1, 5))
					{
						case 1:     // スペード
							PuzzlePiece[(Width * 6 - OddNumber) + Height].GetComponent<PuzzlePiece>().SetSuit(DEFINE.PUZZLE_PIECE_SUIT.SPADE);
							break;

						case 2:     // ダイヤ
							PuzzlePiece[(Width * 6 - OddNumber) + Height].GetComponent<PuzzlePiece>().SetSuit(DEFINE.PUZZLE_PIECE_SUIT.DIAMOND);
							break;

						case 3:     // ハート
							PuzzlePiece[(Width * 6 - OddNumber) + Height].GetComponent<PuzzlePiece>().SetSuit(DEFINE.PUZZLE_PIECE_SUIT.HEART);
							break;

						case 4:     // クローバー
							PuzzlePiece[(Width * 6 - OddNumber) + Height].GetComponent<PuzzlePiece>().SetSuit(DEFINE.PUZZLE_PIECE_SUIT.CLUB);
							break;
					}
				}

				// 奇数の回数加算
				OddNumber++;
			}
		}
	}

	//--------------------------------------------------
	// パズルの情報を取得
	//--------------------------------------------------
	public GameObject[] GetPuzzle()
	{
		return PuzzlePiece;
	}

	// パズルの状態をリセット
	/*public void AllClean()
	{
        // ピース情報を取得
        removablePieceList = GetComponent<PieceList>().GetRemovaleList();
        
        // プレイヤーもしくは敵のピースだったら
       // if (puzzlePiece.transform.GetComponent<PuzzlePiece>().GetState() == DEFINE.PUZZLE_PIECE_STATE.PLAYER)
        {
            for (int nCount = 0; nCount < removablePieceList.Count; nCount++)
            {
                if (removablePieceList[nCount] != null)
                {
                    Destroy(removablePieceList[nCount]);
                }
            }
        }
		/*for (int Cnt = 0; Cnt < PuzzlePiece.Length; Cnt++)
		{
			PuzzlePiece[Cnt].GetComponent<PuzzlePiece>().SetState(DEFINE.PUZZLE_PIECE_STATE.NONE);
		}*/
	//}


}
