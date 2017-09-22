using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEffect : MonoBehaviour {

    //private ParticleSystem particle;

    [SerializeField]
    ParticleSystem tapEffect;
    
    [SerializeField]
    Camera _camera;

    //public static Vector3 pos;

	// Use this for initialization
	void Start () {
        //particle = this.GetComponent<ParticleSystem>();
        //particle.Stop();

        //Vector3 pos = new Vector3(0.0f, 0.0f, 0.0f);
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
