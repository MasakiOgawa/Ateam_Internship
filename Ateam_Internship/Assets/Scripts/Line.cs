//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//public class Line : MonoBehaviour
//{

//    private LineRenderer lineRenderer;
//    public 


//    //削除するボールのリスト
//    List<GameObject> removablePieceList = new List<GameObject>();

//    // Use this for initialization
//    void Start()
//    {
//        lineRenderer = GetComponent<LineRenderer>();

//        // 線の描画を有効にする
//        lineRenderer.enabled = true;

//        lineRenderer.sortingLayerName = "line";

//        // 頂点数
//        lineRenderer.positionCount = 2;

//        // 色
//        lineRenderer.startColor = new Color(0.0f, 1.0f, 0.0f, 1.0f);
//        lineRenderer.endColor = new Color(0.0f, 1.0f, 0.0f, 1.0f);

//        // 幅
//        lineRenderer.startWidth = 0.05f;
//        lineRenderer.endWidth = 0.05f;

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        lineRenderer.SetPosition(0, Vector3.zero);
//        lineRenderer.SetPosition(1, new Vector3(1f, -11f, -1f));
//        //lineRenderer.SetPosition(2, new GameObject );
//    }
//}