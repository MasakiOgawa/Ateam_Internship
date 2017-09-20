using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillChecker : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	// スキルが発動しているかチェック
	public bool[] SkillCheckList(DEFINE.Party party, PieceList pieceList)
	{
		// スキル発動フラグ
		bool[] SkillFlag = { false, false, false, false };

		// リストに入っているスート
		List<DEFINE.PUZZLE_PIECE_SUIT> SuitList  = new List<DEFINE.PUZZLE_PIECE_SUIT>();

		// パズルリストの情報を取得
		List<GameObject> list = pieceList.GetRemovaleList();

		// スート情報をリストに格納
		for (int Cnt = 0; Cnt < list.Count; Cnt++)
		{
			SuitList.Add(list[Cnt].GetComponent<PuzzlePiece>().GetSuit());
		}

		// スキルを比較
		for (int Cnt = 0; Cnt < SuitList.Count - 1; Cnt++)
		{
			// リーダー
			if(party.Chara_0.Skill1 == SuitList[Cnt])
			{
				if (party.Chara_0.Skill2 == SuitList[Cnt + 1])
				{
					SkillFlag[0] = true;
				}
			}

			// キャラ1
			if (party.Chara_1.Skill1 == SuitList[Cnt])
			{
				if (party.Chara_1.Skill2 == SuitList[Cnt + 1])
				{
					SkillFlag[1] = true;
				}
			}

			// キャラ2
			if (party.Chara_2.Skill1 == SuitList[Cnt])
			{
				if (party.Chara_2.Skill2 == SuitList[Cnt + 1])
				{
					SkillFlag[2] = true;
				}
			}

			// キャラ3
			if (party.Chara_3.Skill1 == SuitList[Cnt])
			{
				if (party.Chara_3.Skill2 == SuitList[Cnt + 1])
				{
					SkillFlag[3] = true;
				}
			}
		}

		// ピースのリストを初期化
		pieceList.ListInit();

		return SkillFlag;
	}
}
