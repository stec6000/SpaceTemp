using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 10f;

    void Start()
    {      

    }

	void FixedUpdate () {
        
        float x = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(x, 0, 0);
        transform.position += movement * speed * Time.deltaTime;

	}
}
