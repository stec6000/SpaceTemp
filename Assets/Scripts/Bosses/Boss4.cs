using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss4 : MonoBehaviour
{

    public int hp;
    public float timeBetween5Bullets;
    public float timeBetweenShots;
    public float timeBetweenAim;
    public int aimNumber;
    

    private float tempTime = 0f;
    private float aimTiming = 0f;
    private bool isAiming = false;
    private int counter = 0;

    private Bullet bullet;


    void Start()
    {
        bullet = GetComponent<Bullet>();
        bullet.InvokeRepeating("FiveBullets", .5f, timeBetween5Bullets);
    }

    void Update()
    {
        aimTiming += Time.deltaTime;
        if (aimTiming > timeBetweenAim) isAiming = true;


        tempTime += Time.deltaTime;

        //Aim bullet
        if (tempTime > timeBetweenShots && isAiming)
        {
            bullet.AimPlayer();
            counter++;
            tempTime = 0;
        }
        if (counter >= aimNumber)
        {
            counter = 0;
            isAiming = false;
            aimTiming = 0f;
        }

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
