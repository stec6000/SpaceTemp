using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSlave : MonoBehaviour {

    public float timeBetweenShots;
    public int lives;
    public float speed;

    public GameObject boss;

    private float timer = 0f;

    private Bullet bullet;
    private GameObject particle;

    void Start () {

        bullet = GetComponent<Bullet>();
        particle = Resources.Load("Destroy") as GameObject;
        timeBetweenShots += Random.Range(1f, 10f);
    }
	
	
	void Update () {

        timer += Time.deltaTime;

        
        if (timer > timeBetweenShots)
        {
            bullet.Fire(new Vector3(0,-1,0), 3);

            timer = 0;
        }

        if (lives <= 0)
        {

            Instantiate(particle, transform.position, transform.rotation);
            
            Destroy(gameObject);

        }

    }

    private void FixedUpdate()
    {
        transform.RotateAround(boss.transform.position, Vector3.forward, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bulletPlayer")
        {
            Destroy(collision.gameObject);
            lives--;
        }
    }
}
