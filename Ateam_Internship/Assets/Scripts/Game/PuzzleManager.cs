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


	//--------------------------------------------------
	// 変数定義
	//--------------------------------------------------

	// プライベート
	private GameObject[] PuzzlePiece = new GameObject[DEFINE.PUZZLE_PIECE_MAX];			// 全てのパズルピースの情報

	// インスペクター表示
	[SerializeField] private GameObject PuzzlePiece_Prehab;      // パズルのプレハブ情報
	[SerializeField] private float PieceWight;		// ピースの幅
	[SerializeField] private float PieceHeight;		// ピースの高さ

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

	}

	//--------------------------------------------------
	// パズルのピースを生成
	//--------------------------------------------------
	void CreatePuzzlePiece()
	{
		int OddNumber = 0;      // 奇数の回数

		// パズルのピースを生成
		for (int Wight = 0; Wight < PUZZLE_WIGHT; Wight++)
		{
			// 偶数だったら
			if (Wight % 2 == 0)
			{
				for (int Height = 0; Height < PUZZLE_HEIGHT; Height++)
				{
					// ピースのインスタンス生成
					PuzzlePiece[((Wight / 2) * 11) + Height] = Instantiate(PuzzlePiece_Prehab, new Vector3(PuzzlePiece_Prehab.transform.position.x + (PieceWight * Wight), PuzzlePiece_Prehab.transform.position.y + (PieceHeight * Height), 0), Quaternion.Euler(0, 0, 0), transform);

					// ランダムでピースの柄を設定
					switch (Random.Range(1, 5))
					{
						case 1:     // スペード
							PuzzlePiece[((Wight / 2) * 11) + Height].GetComponent<PuzzlePiece>().SetSuit(DEFINE.PUZZLE_PIECE_SUIT.SPADE);
							break;

						case 2:     // ダイヤ
							PuzzlePiece[((Wight / 2) * 11) + Height].GetComponent<PuzzlePiece>().SetSuit(DEFINE.PUZZLE_PIECE_SUIT.DIAMOND);
							break;

						case 3:     // ハート
							PuzzlePiece[((Wight / 2) * 11) + Height].GetComponent<PuzzlePiece>().SetSuit(DEFINE.PUZZLE_PIECE_SUIT.HEART);
							break;

						case 4:     // クローバー
							PuzzlePiece[((Wight / 2) * 11) + Height].GetComponent<PuzzlePiece>().SetSuit(DEFINE.PUZZLE_PIECE_SUIT.CLUB);
							break;
					}
				}
			}
			// 奇数だったら
			else if (Wight % 2 == 1)
			{
				for (int Height = 0; Height < PUZZLE_HEIGHT - 1; Height++)
				{
					// ピースのインスタンス生成
					PuzzlePiece[(Wight * 6 - OddNumber) + Height] = Instantiate(PuzzlePiece_Prehab, new Vector3(PuzzlePiece_Prehab.transform.position.x + (PieceWight  * Wight), -0.66f + (PieceHeight * Height), 0), Quaternion.Euler(0, 0, 0), transform);

					// ランダムでピースの柄を設定
					switch (Random.Range(1, 5))
					{
						case 1:     // スペード
							PuzzlePiece[(Wight * 6 - OddNumber) + Height].GetComponent<PuzzlePiece>().SetSuit(DEFINE.PUZZLE_PIECE_SUIT.SPADE);
							break;

						case 2:     // ダイヤ
							PuzzlePiece[(Wight * 6 - OddNumber) + Height].GetComponent<PuzzlePiece>().SetSuit(DEFINE.PUZZLE_PIECE_SUIT.DIAMOND);
							break;

						case 3:     // ハート
							PuzzlePiece[(Wight * 6 - OddNumber) + Height].GetComponent<PuzzlePiece>().SetSuit(DEFINE.PUZZLE_PIECE_SUIT.HEART);
							break;

						case 4:     // クローバー
							PuzzlePiece[(Wight * 6 - OddNumber) + Height].GetComponent<PuzzlePiece>().SetSuit(DEFINE.PUZZLE_PIECE_SUIT.CLUB);
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
}
