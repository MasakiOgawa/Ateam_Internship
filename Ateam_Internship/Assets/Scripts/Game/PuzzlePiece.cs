using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
	//--------------------------------------------------
	// 定数定義
	//--------------------------------------------------
	private const float PlayerColor_R = 1.0f;       // プレイヤー色情報 R
	private const float PlayerColor_G = 0.5f;       // プレイヤー色情報 G
	private const float PlayerColor_B = 1.0f;       // プレイヤー色情報 B
	private const float PlayerColor_A = 1.0f;       // プレイヤー色情報 A

	private const float EnemyColor_R = 0.5f;        // エネミー色情報 R
	private const float EnemyColor_G = 0.5f;        // エネミー色情報 G
	private const float EnemyColor_B = 1.0f;        // エネミー色情報 B
	private const float EnemyColor_A = 1.0f;        // エネミー色情報 A


	//--------------------------------------------------
	// 変数宣言
	//--------------------------------------------------

	// プライベート変数
	private Color PuzzlePiececolor;     // パズルピース色情報
	private Sprite PuzzlePieceTex;      // パズルピーステクスチャ情報

	private DEFINE.PUZZLE_PIECE_STATE PuzzlePieceState;         // パズルのピースの状態
	private DEFINE.PUZZLE_PIECE_SUIT PuzzlePieceSuit;           // パズルのピースの柄

	private LineRenderer lineRenderer;
	private GameObject lineObj;

	// デバッグ用
	private bool ClickRight;            // 右クリックが押されているか


	// インスペクターに表示する変数
	[SerializeField]
	private Sprite PuzzlePiece_tex1;
	[SerializeField]
	private Sprite PuzzlePiece_tex2;
	[SerializeField]
	private Sprite PuzzlePiece_tex3;
	[SerializeField]
	private Sprite PuzzlePiece_tex4;

	//--------------------------------------------------
	// スタート
	//--------------------------------------------------
	void Start()
	{
		// 初期化
		PuzzlePiececolor = new Color(PlayerColor_R, PlayerColor_G, PlayerColor_B, PlayerColor_A);   // 色情報

		PuzzlePieceTex = PuzzlePiece_tex1;                      // テクスチャ情報
		PuzzlePieceState = DEFINE.PUZZLE_PIECE_STATE.NONE;      // パズルピースの状態
		PuzzlePieceSuit = DEFINE.PUZZLE_PIECE_SUIT.NONE;        // パズルピースの柄

	}


	//--------------------------------------------------
	// アップデート
	//--------------------------------------------------
	void Update()
	{


		// デバッグ用
		//DebugPuzzle();
	}


	//--------------------------------------------------
	// マウスがオブジェクトの上に乗ったら
	//--------------------------------------------------
	private void OnMouseOver()
	{
		// テクスチャを切り替え
		if (ClickRight == true)
		{
			// パズルのテクスチャを変更
			GetComponent<SpriteRenderer>().sprite = PuzzlePieceTex;
		}
	}

	//--------------------------------------------------
	// パズルの状態設定
	//--------------------------------------------------
	public void SetState(DEFINE.PUZZLE_PIECE_STATE state)
	{
		// 状態を設定
		PuzzlePieceState = state;

		// 状態に合わせて色を変更
		switch (PuzzlePieceState)
		{
			case DEFINE.PUZZLE_PIECE_STATE.NONE:        // 何もなし
				PuzzlePiececolor = Color.white;
				break;

			case DEFINE.PUZZLE_PIECE_STATE.PLAYER:      // プレイヤー
				PuzzlePiececolor = new Color(PlayerColor_R, PlayerColor_G, PlayerColor_B, PlayerColor_A);
				GetComponent<SpriteRenderer>().color = PuzzlePiececolor;
				break;

			case DEFINE.PUZZLE_PIECE_STATE.ENEMY:       // エネミー
				PuzzlePiececolor = new Color(EnemyColor_R, EnemyColor_G, EnemyColor_B, EnemyColor_A);
				GetComponent<SpriteRenderer>().color = PuzzlePiececolor;
				break;
		}
	}


	//--------------------------------------------------
	// パズルの柄設定
	//--------------------------------------------------
	public void SetSuit(DEFINE.PUZZLE_PIECE_SUIT suit)
	{
		// 柄を設定
		PuzzlePieceSuit = suit;

		switch (PuzzlePieceSuit)
		{
			case DEFINE.PUZZLE_PIECE_SUIT.SPADE:            // スペード
				GetComponent<SpriteRenderer>().sprite = PuzzlePiece_tex1;
				break;

			case DEFINE.PUZZLE_PIECE_SUIT.DIAMOND:          // ダイヤ
				GetComponent<SpriteRenderer>().sprite = PuzzlePiece_tex2;
				break;

			case DEFINE.PUZZLE_PIECE_SUIT.HEART:            // ハート
				GetComponent<SpriteRenderer>().sprite = PuzzlePiece_tex3;
				break;

			case DEFINE.PUZZLE_PIECE_SUIT.CLUB:             // クラブ
				GetComponent<SpriteRenderer>().sprite = PuzzlePiece_tex4;
				break;
		}
	}

	// ピースの状態取得
	public DEFINE.PUZZLE_PIECE_STATE GetState()
	{
		return PuzzlePieceState;
	}

	// パズルの柄取得
	public DEFINE.PUZZLE_PIECE_SUIT GetSuit()
	{
		return PuzzlePieceSuit;
	}

	//--------------------------------------------------
	// デバッグ用
	//--------------------------------------------------
	private void DebugPuzzle()
	{
		// 右クリックが押されていたら
		if (Input.GetMouseButton(1))
		{
			ClickRight = true;
		}
		else
		{
			ClickRight = false;
		}


		// 色を切り替え
		if (Input.GetKeyDown(KeyCode.A))
		{
			PuzzlePiececolor = new Color(PlayerColor_R, PlayerColor_G, PlayerColor_B, PlayerColor_A);
		}

		if (Input.GetKeyDown(KeyCode.S))
		{
			PuzzlePiececolor = new Color(EnemyColor_R, EnemyColor_G, EnemyColor_B, EnemyColor_A);
		}

		if (Input.GetKeyDown(KeyCode.D))
		{
			PuzzlePiececolor = Color.white;
		}

		if (Input.GetKeyDown(KeyCode.F))
		{
			PuzzlePiececolor = new Color(PlayerColor_R, PlayerColor_G, PlayerColor_B, PlayerColor_A);
			GetComponent<SpriteRenderer>().color = Color.white;
		}


		// テクスチャを切り替え
		if (Input.GetKeyDown(KeyCode.Q))
		{
			PuzzlePieceTex = PuzzlePiece_tex1;
		}

		if (Input.GetKeyDown(KeyCode.W))
		{
			PuzzlePieceTex = PuzzlePiece_tex2;
		}

		if (Input.GetKeyDown(KeyCode.E))
		{
			PuzzlePieceTex = PuzzlePiece_tex3;
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			PuzzlePieceTex = PuzzlePiece_tex4;
		}


		// スペースが押されたらテクスチャをランダムに設定
		if (Input.GetKeyDown(KeyCode.Space))
		{
			switch (Random.Range(1, 5))
			{
				case 1:         // スペード
					GetComponent<SpriteRenderer>().sprite = PuzzlePiece_tex1;
					PuzzlePieceSuit = DEFINE.PUZZLE_PIECE_SUIT.SPADE;
					break;

				case 2:         // ダイヤ
					GetComponent<SpriteRenderer>().sprite = PuzzlePiece_tex2;
					PuzzlePieceSuit = DEFINE.PUZZLE_PIECE_SUIT.DIAMOND;
					break;

				case 3:         // ハート
					GetComponent<SpriteRenderer>().sprite = PuzzlePiece_tex3;
					PuzzlePieceSuit = DEFINE.PUZZLE_PIECE_SUIT.HEART;
					break;

				case 4:         // クローバー
					GetComponent<SpriteRenderer>().sprite = PuzzlePiece_tex4;
					PuzzlePieceSuit = DEFINE.PUZZLE_PIECE_SUIT.CLUB;
					break;
			}
		}
	}
}
