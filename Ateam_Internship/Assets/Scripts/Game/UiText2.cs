using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiText2 : MonoBehaviour
{

    // メンバ変数
    private int nSetNum;                            // Win = 0 / Lose = 1                  
    private SpriteRenderer spriteRenderer;          // スプライトレンダラー
    private float fAlpha;                           // アルファ値
    private bool bAlphaOn;
    private bool bFirstTime;
    private int nSetCnt;

    [SerializeField] private Sprite win;     // プレイヤーターン
    [SerializeField] private Sprite lose;      // エネミーターン

    // Use this for initialization
    void Start()
    {
        fAlpha = 0.0f;
        nSetCnt = 0;
        bAlphaOn = false;
        bFirstTime = true;

        // スプライトレンダラー取得
        spriteRenderer = GetComponent<SpriteRenderer>();

        
        spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        nSetCnt++;

        // プレイヤーがセットされてたら
        if (nSetNum == 0)
        {
            
            spriteRenderer.sprite = win;
        }
        // エネミーがセットされてたら
        else if (nSetNum == 1)
        {
        
            spriteRenderer.sprite = lose;

        }

        if (nSetCnt >= 60)
        {
            if (bAlphaOn == false && bFirstTime == true)
            {
                fAlpha += 0.03f;
            }

            if (fAlpha >= 1.0f)
            {
                fAlpha = 1.0f;
                bAlphaOn = true;
            }
        }

        spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, fAlpha);
    }

    // UI情報を設定
    public void SetUiNum(int setNum)
    {
        nSetNum = setNum;

        spriteRenderer.enabled = true;
        bFirstTime = true;
        //fAlpha = 0;
        nSetCnt = 0;
    }

    // UI情報を取得
    public bool GetAlphaOn()
    {
        return bAlphaOn;
    }

    public bool GetShowUi()
    {
        return bFirstTime;
    }
}
