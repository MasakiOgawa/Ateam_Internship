using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEffect : MonoBehaviour {


    [SerializeField]
    GameObject tapEffect;
    
    [SerializeField]
    Camera _camera;

    int FCount = 0;

    // Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {

        if (FCount >= 60)
        {
            if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
            {
                GameObject GO = Instantiate(tapEffect, 
                    _camera.ScreenToWorldPoint(Input.mousePosition + _camera.transform.forward * 10), Quaternion.Euler(0.0f, 0.0f, 0.0f));
                 
                GO.GetComponent<ParticleSystem>().Emit(1);
                
                FCount = 0;
            }

        }
        else
        { 
            FCount++;
        }
        
    }

}
