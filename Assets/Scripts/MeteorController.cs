using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteorController : MonoBehaviour {

    public float speed = 5f;

    private GameController gameController;
    private Transform sprite;
    private Rigidbody2D rig;
    private GameObject particle;
    private int lifes;
    private int x, y;
    private int randX, randY;
    
	void Start () {

        particle = Resources.Load("Destroy") as GameObject;
        gameController = FindObjectOfType<GameController>();
        rig = GetComponent<Rigidbody2D>();
        sprite = gameObject.transform.GetChild(0);
        lifes = gameController.GetLevel() / 10 + 1;
        
        sprite.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        rig.velocity = new Vector2(0, -1 * speed + Random.Range(0f,1.5f));
	}
	
	void Update () {

        if (lifes <= 0)
        {
            Instantiate(particle, transform.position, transform.rotation);
            gameController.IncreaseScores();
            Destroy(gameObject);
        }

    }

    private void FixedUpdate() {

       // gameObject.transform.Translate(0,( -1 * speed + Random.Range(0.01f, 0.2f) * Time.deltaTime),0);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(particle, transform.position, transform.rotation);
            gameController.IncreaseScores();
            Destroy(gameObject);
        }

        if (collision.tag == "bulletPlayer")
        {
            if (gameObject.transform.tag != "meteorGod")
            {
                Instantiate(particle, transform.position, transform.rotation);
                gameController.IncreaseScores();
                lifes--;
                Destroy(collision.gameObject);
            }
            else Destroy(collision.gameObject);
        }

        

    }

    
}
