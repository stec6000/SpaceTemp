using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour {

    public float speed = 0.1f;

    private int x, y;
    private int randX, randY;
    
	void Start () {
        
        if (gameObject.transform.position.x < 0)
        {
            x = 1;
        }
        else x = -1;

        randX = Random.Range(1, 10) * x;
        randY = Random.Range(1, 10) * -1;
        
	}
	
	void Update () {
        gameObject.transform.Translate(randX * speed, randY * speed, Time.deltaTime);

        if (gameObject.transform.position.y < -8 || gameObject.transform.position.y < -8 || gameObject.transform.position.y > 8) Destroy(gameObject);
    }
}
