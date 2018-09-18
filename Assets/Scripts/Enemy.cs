using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private float padding = 0.5f;
    private float xmin;
    private float xmax;
    private float speed = 0.05f;
    private int direction = 1;
    private float tempTime = 0;
    private float timeBetweenShots = 1f;

    private int lives;

    private Bullet bullet;
    private EnemySpawn enemySpawn;
    private GameController gameController;
    private GameObject bonus;
    private GameObject particle;

    void Start ()
    {

        particle = Resources.Load("Destroy") as GameObject;
        bonus = Resources.Load("Bonus") as GameObject;
        enemySpawn = FindObjectOfType<EnemySpawn>();
        gameController = FindObjectOfType<GameController>();
        bullet = GetComponent<Bullet>();
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;

        lives = gameController.GetLevel() + 1;
    }
	
	void Update () {

        if (transform.position.y > 4.25f)
            transform.Translate(0, speed, 0);

        transform.Translate(direction * speed, 0, 0);
        if (transform.position.x <= xmin || transform.position.x >= xmax) direction *= -1;


        tempTime += Time.deltaTime;
            if (tempTime > timeBetweenShots)
            {
                {
                    bullet.Fire(new Vector3(0,-1,0), 3);
                    tempTime = 0;
                }
            }

        if (lives <= 0)
        {

            Instantiate(particle, transform.position, transform.rotation);
            float bonusX = Random.Range(0, 100);
            if(bonusX <= 80)
            {
                enemySpawn.SpawnBonus(bonus, gameObject.transform.position);
            }
            enemySpawn.SetIsSpawned(false);
            Destroy(gameObject);
            
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "bulletPlayer")
        {
            gameController.IncreaseScores();
            
            Destroy(collision.gameObject);
            lives--;
        }
    }

    }
