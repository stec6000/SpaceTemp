using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour {

    private float spawnTime = 1f;
    private float x, y;
    private float tempTime = 0;
    private float bonusTime = 0;
    private float xmin;
    private float xmax;
    private float padding = 0.5f;
    private float bonusChance = 100f;

    private GameObject meteor;
    private GameObject meteorIndestructible;
    private GameObject bonus;

    void Start () {
        meteor = Resources.Load("Meteor") as GameObject;
        meteorIndestructible = Resources.Load("MeteorGod") as GameObject;
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
            Spawn(meteor);
            tempTime -= spawnTime;
        }
        bonusTime += Time.deltaTime;
        if (bonusTime > 5f)
        {
            float bonusX = Random.Range(0, 100);
            if (bonusX < bonusChance) Spawn(meteorIndestructible);
            bonusTime -= 5f;
        }
	}

    public void Spawn(GameObject toSpawn)
    {
        x = Random.Range(xmin, xmax);
        y = 6;

        Instantiate(toSpawn, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 0));
    }


    public void SpawnTimeDecreas()
    {
        spawnTime *= 0.95f;
    }
}
