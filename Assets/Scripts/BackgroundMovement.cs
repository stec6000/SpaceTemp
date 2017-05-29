using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour {

    public float speed = 0.1f;
    public GameObject starsPrefab;
    
    private GameObject stars;
    private bool once = true;

    void Start () {
    }
	
	void Update () {
        gameObject.transform.Translate(0, -1 * speed, Time.deltaTime);
        
        if(gameObject.transform.position.y < -10 && once)
        {
            once = false;
            stars = Instantiate(starsPrefab, new Vector3(0, 20, 0), Quaternion.Euler(0,0,0)) as GameObject;
        }
        if (gameObject.transform.position.y < -20)
        {
            once = true;
            Destroy(gameObject);
        }
	}
}
