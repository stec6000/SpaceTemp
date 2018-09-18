using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour {

    private ParticleSystem ps;

	void Start () {
        ps = GetComponent<ParticleSystem>();
        //Destroy(gameObject, ps.main.duration);
	}
	
	// Update is called once per frame
	void Update () {
        if (!ps.IsAlive())
        {
            Destroy(this.gameObject);
        }
    }
}
