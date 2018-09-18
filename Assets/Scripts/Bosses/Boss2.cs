using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss2 : MonoBehaviour
{

    public int hp;
    public float timeBetweenShots = 2f;
    

    private Bullet bullet;


    void Start()
    {
        bullet = GetComponent<Bullet>();
        bullet.InvokeRepeating("ThreeBullets", .5f, 3f);
        bullet.InvokeRepeating("AimPlayer", 1f, timeBetweenShots);
    }

    void Update()
    {
        
        //Destroy boss
        if (hp <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Game");
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "bulletPlayer")
        {
            hp--;
            Destroy(collision.gameObject);
        }
    }
}
