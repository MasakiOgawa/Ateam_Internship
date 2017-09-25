using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiText : MonoBehaviour {

    // メンバ変数
    private bool bSetUi;
    private GameManager gameManager;

    public Image image;

    // Use this for initialization
    void Start ()
    {
        image.enabled = false;
        bSetUi = false;
    }

    // Update is called once per frame
    void Update()
    {
        //UIがセットされてたら
        if (bSetUi == true)
        {
            // プレイヤーのターン
            if (gameManager.GetGameState() == DEFINE.GAME_STATE.PLAYER_TURN)
            {
                image.enabled = true;
                
                //PuzzlePiece[Cnt].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }
            // エネミーのターン
            else if (gameManager.GetGameState() == DEFINE.GAME_STATE.ENEMY_TURN)
            {
                image.enabled = true;
            }

            bSetUi = false;
        }
    }
        
    // UI情報を設定
    public void SetUI(bool setUi)
    {
        bSetUi = setUi;
    }

    // UI情報を取得
    public bool GetUi()
    {
        return bSetUi;
    }
}
