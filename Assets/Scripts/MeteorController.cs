using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteorController : MonoBehaviour {

    public float speed = 10f;

    private GameController gameController;
    private int x, y;
    private int randX, randY;
    
	void Start () {

        gameController = FindObjectOfType<GameController>();
     /*   if (gameObject.transform.position.x < 0)
        {
            x = 1;
        }
        else x = -1;

        randX = Random.Range(1, 10) * x;
        randY = Random.Range(1, 10) * -1;
        */
	}
	
	void Update () {
        gameObject.transform.Translate(0, -1 * speed, Time.deltaTime);

        if (gameObject.transform.position.y < -8) Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        if (collision.tag == "bullet")
        {
            gameController.IncreaseScores();
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    
}
