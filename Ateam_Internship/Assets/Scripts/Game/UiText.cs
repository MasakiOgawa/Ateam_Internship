using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiText : MonoBehaviour {

    // メンバ変数
    private int nSetNum;                            // プレイヤー = 0 / エネミー = 1                  
    private SpriteRenderer spriteRenderer;          // スプライトレンダラー
    private float fAlpha;                           // アルファ値
    private bool bAlphaOn;
    private bool bFirstTime;
    private int nCnt;
    private int nSetCnt;
	private bool se;

    [SerializeField] private Sprite playerTurn;     // プレイヤーターン
    [SerializeField] private Sprite enemyTurn;      // エネミーターン
	[SerializeField] private SEManager SE;

    // Use this for initialization
    void Start ()
    {
        nSetNum = 0;
        fAlpha = 0.0f;
        nCnt = 0;
        nSetCnt = 0;
        bAlphaOn = false;
        bFirstTime = true;

        // スプライトレンダラー取得
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.enabled = true;
        spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        nSetCnt++;

        // プレイヤーがセットされてたら
        if (nSetNum == 0)
        {
            spriteRenderer.sprite = playerTurn;
        }
        // エネミーがセットされてたら
        else if (nSetNum == 1)
        {
            spriteRenderer.sprite = enemyTurn;
            
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
                nCnt++;
                bAlphaOn = true;
				if(se == false)
				{
					SE.PlaySE(16);
					se = true;
				}
				
            }

            if (nCnt >= 30)
            {
                fAlpha -= 0.03f;

                if (fAlpha <= 0)
                {
                    fAlpha = 0;
                    nCnt = 0;
                    bAlphaOn = false;
                    bFirstTime = false;
					se = false;
				}
            }
        }

        spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, fAlpha);
    }
        
    // UI情報を設定
    public void SetUiNum(int setNum)
    {
        nSetNum = setNum;

        bFirstTime = true;
        fAlpha = 0;
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

    public void SetShowUi(bool setshowUi)
    {
        bFirstTime = setshowUi;

    }

	public void SetSEFlag(bool flag)
	{
		se = flag;
	}
}
