using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour {

    private float spawnTime = 1f;
    private float x, y;
    private GameObject meteor;
    private float tempTime = 0;

	void Start () {
        meteor = Resources.Load("Meteor") as GameObject;
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
        x = Random.Range(-5f, 5f);
        Debug.Log(x);
        y = 6;

        Instantiate(meteor, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 0));
    }

    public void SpawnTimeDecreas()
    {
        spawnTime *= 0.9f;
    }
}
