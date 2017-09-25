using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEffect : MonoBehaviour {


    [SerializeField]
    ParticleSystem tapEffect;
    
    [SerializeField]
    Camera _camera;


	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {


        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
        {
            //particle.Play();
            var pos = _camera.ScreenToWorldPoint(Input.mousePosition + _camera.transform.forward * 10);
            tapEffect.transform.position = pos;
            tapEffect.Emit(1);
        }

	}
}
