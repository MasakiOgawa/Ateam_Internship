using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Piece : MonoBehaviour
{
    public GameObject piecePrefab;
    public Sprite[] pieceSprites;

    private LineRenderer lineRenderer;
    private GameObject lineObj;
    private GameObject startPiece;      // 最初にドラッグしたピース
    private GameObject endPiece;        // 最後にドラッグしたピース
    private string currentName;         // 名前判定用のstring変数
    private int nCnt;                   // 塗った回数
   

    //削除するピースのリスト
    List<GameObject> removablePieceList = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        StartCoroutine(SetPiece(39));

        nCnt = 0;
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
    private void OnDragStart()
    {
        // クリックした位置のオブジェクトを取得
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            GameObject hitObj = hit.collider.gameObject;

            //オブジェクトの名前を前方一致で判定
            string pieceName = hitObj.name;

            if (pieceName.StartsWith("sample"))
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

    // クリック中の処理
    private void OnDragging()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            GameObject hitObj = hit.collider.gameObject;

            // 最後とは別オブジェクトである時
            if (startPiece != hitObj && endPiece != hitObj)     //hitObj.name == currentName && 
            {
                //２つのオブジェクトの距離を取得
                float fDistance = Vector2.Distance(hitObj.transform.position, endPiece.transform.position);

                if (fDistance < 1.0f)
                {
                    //削除対象のオブジェクトを格納
                    endPiece = hitObj;

                    PushToList(hitObj);

                    // 線を引く
                    lineRenderer.positionCount = removablePieceList.Count;

                    for (int i = 0; i < removablePieceList.Count; i++)
                    {
                       GameObject obj = removablePieceList[i];
                       lineRenderer.SetPosition(i, obj.transform.position);
                    }
                }
            }
        }
    }

    // クリック終了時処理
    private void OnDragEnd()
    {
        int nRemoveCnt = removablePieceList.Count;

        if (nRemoveCnt >= 2 && nRemoveCnt <= 8)
        {
            for (int i = 0; i < nRemoveCnt; i++)
            {
                ChangeColor(removablePieceList[i], new Color(0.5f, 0.5f, 1.0f, 0.5f));

                lineRenderer.positionCount = 0;
            }

            nCnt++;
        }
        else
        {
            //色の透明度を戻す
            for (int i = 0; i < nRemoveCnt; i++)
            {
                ChangeColor(removablePieceList[i], new Color(1.0f, 1.0f, 1.0f, 1.0f));

                lineRenderer.positionCount = 0;
            }
        }

        if(nCnt >= 4)
        {
            for (int i = 0; i < nRemoveCnt; i++)
            {
                Destroy(removablePieceList[i]);
            }

            //ピース生成
            StartCoroutine(SetPiece(nRemoveCnt));

            nCnt = 0;
        }

        // 初期化
        startPiece = null;
        endPiece = null;
    }

    // ピースセット
    IEnumerator SetPiece(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector2 pos = new Vector2(Random.Range(-2.0f, 2.0f), 7);

            GameObject piece = Instantiate(piecePrefab, pos, Quaternion.AngleAxis(Random.Range(0, 0), Vector3.forward)) as GameObject;

            int nPieceId = Random.Range(0, 4);

            piece.name = "sample" + nPieceId;

            SpriteRenderer spriteObj = piece.GetComponent<SpriteRenderer>();

            spriteObj.sprite = pieceSprites[nPieceId];

            yield return new WaitForSeconds(0.5f);
        }
    }

    void PushToList(GameObject obj)
    {
        removablePieceList.Add(obj);

        ChangeColor(obj, new Color(1.0f, 1.0f, 1.0f, 0.5f));
    }

    // 色変え
    void ChangeColor(GameObject obj, Color color)
    {
        //SpriteRendererコンポーネントを取得
        SpriteRenderer pieceTexture = obj.GetComponent<SpriteRenderer>();

        //Colorプロパティのうち、透明度のみ変更する
        pieceTexture.color = new Color(color.r, color.g, color.b, color.a);
    }
}