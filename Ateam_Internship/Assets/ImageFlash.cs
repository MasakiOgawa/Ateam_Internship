using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFlash : MonoBehaviour {

    [SerializeField]
    private float FlashColor;
    [SerializeField]
    private float AddColor;

    bool Flg = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Image>().color = new Color(FlashColor, FlashColor, FlashColor, 1.0f);


        if (FlashColor >= 0.7f || FlashColor <= 0.5f)
            Flg = true;

        if (Flg)
        {
            AddColor *= -1;
            Flg = false;
        }

        FlashColor += AddColor;
    }
}
