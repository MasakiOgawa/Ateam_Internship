using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconManager : MonoBehaviour
{
	private Color High = new Color( 0.7f, 0.7f, 0.7f, 1.0f);
	private Color Low = new Color( 0.3f, 0.3f, 0.3f, 1.0f);

	[SerializeField] private Sprite[]   sprite;         // スプライト情報
	[SerializeField] private Image[]    image;           // イメージ情報
	[SerializeField] private Player     player;         // プレイヤー情報
	[SerializeField] private Enemy		enemy;         // エネミー情報
	[SerializeField] private PieceList  pieceList;      // ピースのリスト情報

	private DEFINE.Party party;     // プレイヤーのパーティ情報
	private bool[] skillFlag = { false, false, false, false};       // スキルが発動しているか

	// Use this for initialization
	void Start()
	{
		// パーティの情報を取得
		if(player != null)
		{
			party = player.GetPlayerParty();
		}
		else if(enemy != null)
		{
			party = enemy.GetEnemyParty();
		}

		// リーダー
		switch (party.Chara_0.Skill1)
		{
			case DEFINE.PUZZLE_PIECE_SUIT.SPADE:
				image[0].sprite = sprite[0];
				image[1].sprite = sprite[1];
				
				break;

			case DEFINE.PUZZLE_PIECE_SUIT.DIAMOND:
				image[0].sprite = sprite[2];
				image[1].sprite = sprite[3];
				break;

			case DEFINE.PUZZLE_PIECE_SUIT.HEART:
				image[0].sprite = sprite[4];
				image[1].sprite = sprite[5];
				break;

			case DEFINE.PUZZLE_PIECE_SUIT.CLUB:
				image[0].sprite = sprite[6];
				image[1].sprite = sprite[7];
				break;
		}

		switch (party.Chara_0.Skill2)
		{
			case DEFINE.PUZZLE_PIECE_SUIT.SPADE:
				image[2].sprite = sprite[0];
				image[3].sprite = sprite[1];

				break;

			case DEFINE.PUZZLE_PIECE_SUIT.DIAMOND:
				image[2].sprite = sprite[2];
				image[3].sprite = sprite[3];
				break;

			case DEFINE.PUZZLE_PIECE_SUIT.HEART:
				image[2].sprite = sprite[4];
				image[3].sprite = sprite[5];
				break;

			case DEFINE.PUZZLE_PIECE_SUIT.CLUB:
				image[2].sprite = sprite[6];
				image[3].sprite = sprite[7];
				break;
		}

		// キャラ1
		switch (party.Chara_1.Skill1)
		{
			case DEFINE.PUZZLE_PIECE_SUIT.SPADE:
				image[4].sprite = sprite[0];
				image[5].sprite = sprite[1];

				break;

			case DEFINE.PUZZLE_PIECE_SUIT.DIAMOND:
				image[4].sprite = sprite[2];
				image[5].sprite = sprite[3];
				break;

			case DEFINE.PUZZLE_PIECE_SUIT.HEART:
				image[4].sprite = sprite[4];
				image[5].sprite = sprite[5];
				break;

			case DEFINE.PUZZLE_PIECE_SUIT.CLUB:
				image[4].sprite = sprite[6];
				image[5].sprite = sprite[7];
				break;
		}

		switch (party.Chara_1.Skill2)
		{
			case DEFINE.PUZZLE_PIECE_SUIT.SPADE:
				image[6].sprite = sprite[0];
				image[7].sprite = sprite[1];

				break;

			case DEFINE.PUZZLE_PIECE_SUIT.DIAMOND:
				image[6].sprite = sprite[2];
				image[7].sprite = sprite[3];
				break;

			case DEFINE.PUZZLE_PIECE_SUIT.HEART:
				image[6].sprite = sprite[4];
				image[7].sprite = sprite[5];
				break;

			case DEFINE.PUZZLE_PIECE_SUIT.CLUB:
				image[6].sprite = sprite[6];
				image[7].sprite = sprite[7];
				break;
		}

		// キャラ2
		switch (party.Chara_2.Skill1)
		{
			case DEFINE.PUZZLE_PIECE_SUIT.SPADE:
				image[8].sprite = sprite[0];
				image[9].sprite = sprite[1];

				break;

			case DEFINE.PUZZLE_PIECE_SUIT.DIAMOND:
				image[8].sprite = sprite[2];
				image[9].sprite = sprite[3];
				break;

			case DEFINE.PUZZLE_PIECE_SUIT.HEART:
				image[8].sprite = sprite[4];
				image[9].sprite = sprite[5];
				break;

			case DEFINE.PUZZLE_PIECE_SUIT.CLUB:
				image[8].sprite = sprite[6];
				image[9].sprite = sprite[7];
				break;
		}

		switch (party.Chara_2.Skill2)
		{
			case DEFINE.PUZZLE_PIECE_SUIT.SPADE:
				image[10].sprite = sprite[0];
				image[11].sprite = sprite[1];

				break;

			case DEFINE.PUZZLE_PIECE_SUIT.DIAMOND:
				image[10].sprite = sprite[2];
				image[11].sprite = sprite[3];
				break;

			case DEFINE.PUZZLE_PIECE_SUIT.HEART:
				image[10].sprite = sprite[4];
				image[11].sprite = sprite[5];
				break;

			case DEFINE.PUZZLE_PIECE_SUIT.CLUB:
				image[10].sprite = sprite[6];
				image[11].sprite = sprite[7];
				break;
		}

		// キャラ3
		switch (party.Chara_3.Skill1)
		{
			case DEFINE.PUZZLE_PIECE_SUIT.SPADE:
				image[12].sprite = sprite[0];
				image[13].sprite = sprite[1];

				break;

			case DEFINE.PUZZLE_PIECE_SUIT.DIAMOND:
				image[12].sprite = sprite[2];
				image[13].sprite = sprite[3];
				break;

			case DEFINE.PUZZLE_PIECE_SUIT.HEART:
				image[12].sprite = sprite[4];
				image[13].sprite = sprite[5];
				break;

			case DEFINE.PUZZLE_PIECE_SUIT.CLUB:
				image[12].sprite = sprite[6];
				image[13].sprite = sprite[7];
				break;
		}

		switch (party.Chara_3.Skill2)
		{
			case DEFINE.PUZZLE_PIECE_SUIT.SPADE:
				image[14].sprite = sprite[0];
				image[15].sprite = sprite[1];

				break;

			case DEFINE.PUZZLE_PIECE_SUIT.DIAMOND:
				image[14].sprite = sprite[2];
				image[15].sprite = sprite[3];
				break;

			case DEFINE.PUZZLE_PIECE_SUIT.HEART:
				image[14].sprite = sprite[4];
				image[15].sprite = sprite[5];
				break;

			case DEFINE.PUZZLE_PIECE_SUIT.CLUB:
				image[14].sprite = sprite[6];
				image[15].sprite = sprite[7];
				break;
		}

		// パズルの色を初期化
		for(int Cnt = 1; Cnt < image.Length; Cnt += 2)
		{
			image[Cnt].color = Low;
		}
	}

	// Update is called once per frame
	void Update()
	{
		// リスト情報取得
		List <GameObject> list = pieceList.GetRemovaleList();

		// デバッグ
		SetSkillFlag(false);

		// リストが一つ以下なら
		if (list.Count <= 1 && skillFlag[0] == false && skillFlag[1] == false && skillFlag[2] == false && skillFlag[3] == false)
		{
			// パズルの色を初期化
			for (int Cnt = 1; Cnt < image.Length; Cnt += 2)
			{
				image[Cnt].color = Low;
			}
		}

		// リストと比較してアイコンを光らせる
		for(int Cnt = 0; Cnt < list.Count; Cnt++)
		{
			// リーダー

			// スキル1と同じ柄があったら
			if (list[Cnt].GetComponent<PuzzlePiece>().GetSuit() == party.Chara_0.Skill1)
			{
				// キャップ
				if(Cnt + 1 != list.Count)
				{
					// スキル2と同じ柄があったら
					if (list[Cnt + 1].GetComponent<PuzzlePiece>().GetSuit() == party.Chara_0.Skill2)
					{
						image[1].color = High;
						image[3].color = High;
						skillFlag[0] = true;
					}
				}
				// スキル1だけ
				else
				{
					image[1].color = High;
				}
			}
			// 色を戻す
			else if(skillFlag[0] == false)
			{
				image[1].color = Low;
				image[3].color = Low;
			}

			// キャラ1

			// スキル1と同じ柄があったら
			if (list[Cnt].GetComponent<PuzzlePiece>().GetSuit() == party.Chara_1.Skill1)
			{
				// キャップ
				if (Cnt + 1 != list.Count)
				{
					// スキル2と同じ柄があったら
					if (list[Cnt + 1].GetComponent<PuzzlePiece>().GetSuit() == party.Chara_1.Skill2)
					{
						image[5].color = High;
						image[7].color = High;
						skillFlag[1] = true;
					}
				}
				// スキル1だけ
				else
				{
					image[5].color = High;
				}
			}
			// 色を戻す
			else if (skillFlag[1] == false)
			{
				image[5].color = Low;
				image[7].color = Low;
			}

			// キャラ2

			// スキル1と同じ柄があったら
			if (list[Cnt].GetComponent<PuzzlePiece>().GetSuit() == party.Chara_2.Skill1)
			{
				// キャップ
				if (Cnt + 1 != list.Count)
				{
					// スキル2と同じ柄があったら
					if (list[Cnt + 1].GetComponent<PuzzlePiece>().GetSuit() == party.Chara_2.Skill2)
					{
						image[9].color = High;
						image[11].color = High;
						skillFlag[2] = true;
					}
				}
				// スキル1だけ
				else
				{
					image[9].color = High;
				}
			}
			// 色を戻す
			else if (skillFlag[2] == false)
			{
				image[9].color = Low;
				image[11].color = Low;
			}

			// キャラ3

			// スキル1と同じ柄があったら
			if (list[Cnt].GetComponent<PuzzlePiece>().GetSuit() == party.Chara_3.Skill1)
			{
				// キャップ
				if (Cnt + 1 != list.Count)
				{
					// スキル2と同じ柄があったら
					if (list[Cnt + 1].GetComponent<PuzzlePiece>().GetSuit() == party.Chara_3.Skill2)
					{
						image[13].color = High;
						image[15].color = High;
						skillFlag[3] = true;
					}
				}
				// スキル1だけ
				else
				{
					image[13].color = High;
				}
			}
			// 色を戻す
			else if (skillFlag[3] == false)
			{
				image[13].color = Low;
				image[15].color = Low;
			}
		}
	}

	// スキルフラグ設定
	void SetSkillFlag(bool flag)
	{
		skillFlag = new bool[]{ flag, flag, flag, flag};
	}
}
