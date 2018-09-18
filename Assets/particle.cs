using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour {

    private ParticleSystem ps;

	void Start () {
        ps = GetComponent<ParticleSystem>();
        //Destroy(gameObject, ps.main.duration);
	}
	
	void Update () {
        if (!ps.IsAlive())
        {
            Destroy(this.gameObject);
        }
    }
}
