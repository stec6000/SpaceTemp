using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss1 : MonoBehaviour {
    
    public int hp;
    public float bulletSpeed;

    private float tempTime = 0;
    private float timeBetweenShots = 2f;
    
    private Bullet bullet;
    

	void Start () {
        bullet = GetComponent<Bullet>();
	}
	
	void Update ()
    {
        tempTime += Time.deltaTime;

        //Aim bullet
        if (tempTime > timeBetweenShots)
        {
            bullet.AimPlayer();
            tempTime = 0;
        }

        //Destroy boss
        if(hp <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Game");
        }
	}



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "bulletPlayer")
        {
            hp--;
            Destroy(collision.gameObject);
        }
    }
}
