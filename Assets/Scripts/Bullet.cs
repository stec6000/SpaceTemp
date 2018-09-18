using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private GameObject player;
    private GameObject bulletPrefab;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bulletPrefab = Resources.Load("bullet") as GameObject;
	}
	
	void Update () {
		
	}


    public void Fire( Vector3 direction,int number = 0, float speed = 5f)
    {
        GameObject bullet = Instantiate(bulletPrefab, gameObject.transform.position, gameObject.transform.rotation);
        bullet.transform.tag = "bullet" + gameObject.transform.tag;

        SpriteChanger spriteChanger = bullet.GetComponent<SpriteChanger>();
        spriteChanger.Change(number);
        bullet.transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, direction.x / direction.y);

        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        rigid.velocity = direction * speed;
    }

    public void FireDouble(Vector3 direction, int number = 1, float speed = 5f)
    {
        GameObject bullet = Instantiate(bulletPrefab, gameObject.transform.position - new Vector3(.2f,0,0), gameObject.transform.rotation);
        bullet.transform.tag = "bullet" + gameObject.transform.tag;

        GameObject bullet2 = Instantiate(bulletPrefab, gameObject.transform.position + new Vector3(.2f, 0, 0), gameObject.transform.rotation);
        bullet2.transform.tag = "bullet" + gameObject.transform.tag;

        SpriteChanger spriteChanger = bullet.GetComponent<SpriteChanger>();
        spriteChanger.Change(number);

        SpriteChanger spriteChanger2 = bullet2.GetComponent<SpriteChanger>();
        spriteChanger2.Change(number);

        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        rigid.velocity = direction * speed;

        Rigidbody2D rigid2 = bullet2.GetComponent<Rigidbody2D>();
        rigid2.velocity = direction * speed;
    }

    public void FireTriple(Vector3 direction, int number = 1, float speed = 5f)
    {
        GameObject bullet = Instantiate(bulletPrefab, gameObject.transform.position - new Vector3(.2f, 0, 0), gameObject.transform.rotation);
        bullet.transform.tag = "bullet" + gameObject.transform.tag;

        GameObject bullet2 = Instantiate(bulletPrefab, gameObject.transform.position + new Vector3(.2f, 0, 0), gameObject.transform.rotation);
        bullet2.transform.tag = "bullet" + gameObject.transform.tag;

        GameObject bullet3 = Instantiate(bulletPrefab, gameObject.transform.position, gameObject.transform.rotation);
        bullet3.transform.tag = "bullet" + gameObject.transform.tag;

        SpriteChanger spriteChanger = bullet.GetComponent<SpriteChanger>();
        spriteChanger.Change(number);

        SpriteChanger spriteChanger2 = bullet2.GetComponent<SpriteChanger>();
        spriteChanger2.Change(number);

        SpriteChanger spriteChanger3 = bullet.GetComponent<SpriteChanger>();
        spriteChanger3.Change(number);

        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        rigid.velocity = direction * speed;

        Rigidbody2D rigid2 = bullet2.GetComponent<Rigidbody2D>();
        rigid2.velocity = direction * speed;

        Rigidbody2D rigid3 = bullet3.GetComponent<Rigidbody2D>();
        rigid3.velocity = direction * speed;
    }

    public void AimPlayer()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 direction = new Vector3((playerPos.x - gameObject.transform.position.x),
            (playerPos.y - gameObject.transform.position.y),
            0);

        Fire(direction, 1, .5f);
    }

    public void ThreeBullets()
    {
        Vector3 direction1 = new Vector3(0, -1, 0);
        Vector3 direction2 = new Vector3(-0.3f , -1, 0);
        Vector3 direction3 = new Vector3(0.3f, -1, 0);
        Fire(direction1,5);
        Fire(direction2,5);
        Fire(direction3,5);
    }

    public void FiveBullets()
    {
        Vector3 direction1 = new Vector3(0, -1, 0);
        Vector3 direction2 = new Vector3(-0.17f, -1, 0);
        Vector3 direction3 = new Vector3(-0.35f, -1, 0);
        Vector3 direction4 = new Vector3(0.17f, -1, 0);
        Vector3 direction5 = new Vector3(0.35f, -1, 0);
        Fire(direction1,5);
        Fire(direction2,5);
        Fire(direction3,5);
        Fire(direction4,5);
        Fire(direction5,5);
    }
    }
