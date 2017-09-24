using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEffect : MonoBehaviour {

    public Vector3 startMarker;     // 始点
    public Vector3 P1Marker;        // 中間点１
    public Vector3 P2Marker;        // 中間点2
    public Vector3 endMarker;       // 終点

    public GameObject EffectObject; // 発生させるエフェクト

    public  float speed = 1.0F;
    private float startTime;
    private float journeyLength;

    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker, endMarker);
    }
    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        
        // 粒子座標を更新
        transform.position = GetPoint(startMarker, P1Marker, P2Marker, endMarker, distCovered);

        
        // 終点まで来たら
        if (transform.position.y <= endMarker.y)
        {
            // 粒子は破棄
            Destroy(gameObject);

            // スキル・エフェクト生成
            Instantiate(EffectObject, new Vector2( 0.0f, 2.6f ), Quaternion.identity );
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
}
