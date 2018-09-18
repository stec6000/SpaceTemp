using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    
    public CameraShake cameraShake;

    private Bullet bullet;
    private Transform sprite;
    private float speed = 4f;
    private float padding = 0.5f;
    private float xmin;
    private float xmax;
    private float tempTime = 0;
    private float timeBetweenShots = 1f;
    private int lifes;
    private int bonusCounter = 0;
    private enum Bullets { one, two, three };
    private Bullets bullets;

    void Start()
    {

        lifes = 3;
        timeBetweenShots = PlayerPrefs.GetFloat("Shoot");
        bullet = GetComponent<Bullet>();
        sprite = gameObject.transform.GetChild(0);

        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;

        bullets = (Bullets)PlayerPrefs.GetInt("BulletsState");
    }

    void Update()
    {
        tempTime += Time.deltaTime;
        //if (Input.GetKey(KeyCode.Space) || Input.touchCount > 0)
            if (tempTime > timeBetweenShots)
            {
                {
                    Fire();
                    tempTime = 0;
                }
            }

        if(bonusCounter % 5 == 0 && bonusCounter > 0)
        {
            bonusCounter++;
            if((int)bullets < 3)
            {
                bullets++;
            }
            
        }
    }

    void FixedUpdate () {

        //Moveing by touching sides of spaceship
        if (Input.touchCount > 0)
        {
            Vector3 touchedPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            float direction = Mathf.Clamp(touchedPos.x - transform.position.x, -1, 1);
            transform.Translate(direction * speed * Time.deltaTime, 0, 0);
            sprite.transform.rotation = Quaternion.Euler(0,direction * 30,0);
        }


#if UNITY_EDITOR
        float x = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(x, 0, 0);
        transform.position += movement * 5f * Time.deltaTime;

        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        sprite.transform.rotation = Quaternion.Euler(0, movement.x * 30, 0);
        //Rotate while moving
        //if (x > 0) transform.rotation = Quaternion.AngleAxis(40, Vector3.up);
        //else if (x < 0) transform.rotation = Quaternion.AngleAxis(-40, Vector3.up);
        //else transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
#endif



        ////#if UNITY_ANDROID

        //        float direction = Input.acceleration.x;
        //        if (direction > -0.05f && direction < 0.05f) direction = 0;
        //        transform.Translate(direction * speed, 0, 0);

        //        //Rotate while moving
        //        //if (direction > 0) transform.rotation = Quaternion.AngleAxis(40, Vector3.up);
        //        //else if (direction < 0) transform.rotation = Quaternion.AngleAxis(-40, Vector3.up);
        //        //else transform.rotation = Quaternion.AngleAxis(0, Vector3.up);

        ////#endif



    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "meteor" ||
            collision.transform.tag == "meteorGod")
        {
            StartCoroutine(cameraShake.Shake(.1f, .1f));
            lifes--;
        }
        if(collision.transform.tag == "bulletmeteor" || collision.transform.tag == "bulletboss" || collision.transform.tag == "bulletenemy")
        {
            StartCoroutine(cameraShake.Shake(.1f, .1f));
            lifes--;
            Destroy(collision.gameObject);
        }
        if (collision.tag == "bonus")
        {
            bonusCounter++;
            timeBetweenShots *= 0.9f;
        }
    }

    public int GetLifes()
    {
        return lifes;
    }

    public float GetTimeBetweenShoots()
    {
        return timeBetweenShots;
    }

    public int GetBullets()
    {
        return (int)bullets;
    }
    

    public void Fire()
    {
        switch (bullets)
        {
            case Bullets.one:
                bullet.Fire(new Vector3(0, 1, 0));
                break;
            case Bullets.two:
                bullet.FireDouble(new Vector3(0, 1, 0));
                break;
            case Bullets.three:
                bullet.FireTriple(new Vector3(0, 1, 0));
                break;
        }

    }
}
