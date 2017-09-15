using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Line : MonoBehaviour
{

	private LineRenderer lineRenderer;

	//削除するボールのリスト
	public List<GameObject> removablePieceList;

	// Use this for initialization
	void Start()
	{
		lineRenderer = GetComponent<LineRenderer>();

		// 線の描画を有効にする
		lineRenderer.enabled = true;

		lineRenderer.sortingLayerName = "line";

		// 色
		lineRenderer.startColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		lineRenderer.endColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);

		// 幅
		lineRenderer.startWidth = 0.05f;
		lineRenderer.endWidth = 0.05f;
	}

	// Update is called once per frame
	void Update()
	{
		// ピース情報を取得
		removablePieceList = GetComponent<PieceList>().GetRemovaleList();

		if (removablePieceList.Count > 0)
		{
			lineRenderer.positionCount = removablePieceList.Count;

			for (int Cnt = 0; Cnt < removablePieceList.Count; Cnt++)
			{
				lineRenderer.SetPosition(Cnt, new Vector3(removablePieceList[Cnt].transform.position.x, removablePieceList[Cnt].transform.position.y, removablePieceList[Cnt].transform.position.z + -1));
			}
		}
		else
		{
			lineRenderer.positionCount = 0;
		}
	}
}