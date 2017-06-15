using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed = 10f;
    

    private GameObject bulletPrefab;
    private float padding = 0.5f;
    private float xmin;
    private float xmax;
    private float tempTime = 0;
    private float timeBetweenShots = 1f;
    private float lives = 3f;

    void Start()
    {
        bulletPrefab = Resources.Load("bullet") as GameObject;
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
    }

    void Update()
    {
        tempTime += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && tempTime > timeBetweenShots)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position;
            Rigidbody2D rig = bullet.GetComponent<Rigidbody2D>();
            rig.velocity = new Vector3(0, 10f, 0);
            tempTime = 0;
        }

    }

    void FixedUpdate () {
        
        float x = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(x, 0, 0);
        transform.position += movement * speed * Time.deltaTime;


        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "meteor")
        {
            lives--;
        }
    }

    public float GetLives()
    {
        return lives;
    }
}
