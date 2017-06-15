using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour {

    private float spawnTime = 1f;
    private float x, y;
    private GameObject meteor;
    private float tempTime = 0;
    private float xmin;
    private float xmax;
    private float padding = 0.5f;

    void Start () {
        meteor = Resources.Load("Meteor") as GameObject;
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
        //InvokeRepeating("Spawn",1f, spawnTime);
    }
	
	void Update () {

        tempTime += Time.deltaTime;
        if (tempTime > spawnTime)
        {
            Spawn();
            tempTime -= spawnTime;
        }
	}

    public void Spawn()
    {
        x = Random.Range(xmin, xmax);
        y = 6;

        Instantiate(meteor, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 0));
    }

    public void SpawnTimeDecreas()
    {
        spawnTime *= 0.9f;
    }
}
