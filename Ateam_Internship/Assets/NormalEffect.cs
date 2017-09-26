using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEffect : MonoBehaviour
{
    private static int nSkillCnt;
    private int nID;

    private Vector3 startMarker;     // 始点
    private Vector3 P1Marker;        // 中間点１
    private Vector3 P2Marker;        // 中間点2
    private Vector3 endMarker;       // 終点

    private EffectManager EffectObject; // 発生させるエフェクト
    private int EffectID;

    public float speed = 0.5f;
    private float startTime;
    private float journeyLength;
    private bool bflag;

    private GameManager gameManager;

    void Awake()
    {
       
    }

    void Start()
    {
        nID = nSkillCnt;
        nSkillCnt++;
     

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker, endMarker);

        EffectObject = GameObject.Find("EffectManager").GetComponent<EffectManager>();
    }
    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;

        // 粒子座標を更新
        transform.position = GetPoint(startMarker, P1Marker, P2Marker, endMarker, distCovered);


        // 終点まで来たら
        if (transform.position.x >= endMarker.x | transform.position.y >= endMarker.y)
        {
            if(nID == 3)
            {
                gameManager.SetEffectFlag(true);
                nSkillCnt = 0;
            }
            // 粒子は破棄
            Destroy(gameObject);

            if (bflag == false)
            {
                // スキル・エフェクト生成
                EffectObject.PlayEffect(EffectID, endMarker, new Quaternion(0, 0, 0, 0));
                bflag = true;
            }
        }
    }

    Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        var oneMinusT = 1f - t;
        return oneMinusT * oneMinusT * oneMinusT * p0 +
               3f * oneMinusT * oneMinusT * t * p1 +
               3f * oneMinusT * t * t * p2 +
               t * t * t * p3;
    }

    public void SetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, int ID)
    {
        startMarker = p0;
        P1Marker = p1;
        P2Marker = p2;
        endMarker = p3;
        EffectID = ID;
    }
}