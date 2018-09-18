using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour {

    public float speed = 0.08f;

	void Start () {
		gameObject.transform.Rotate(new Vector3(180, 0, 0));
	}
	
	void Update () {
        gameObject.transform.Translate(0, -1 * speed, Time.deltaTime);
        
        if (gameObject.transform.position.y < -8) Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") Destroy(gameObject);
    }
}
