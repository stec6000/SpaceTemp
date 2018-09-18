using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    private float x, y;
    private float xmin;
    private float xmax;
    private float padding = 0.5f;
    private float bonusChance = 50f;
    private bool isSpawned;

    private GameObject enemy;
    //private GameObject bonus;


    void Start()
    {
        //bonus = Resources.Load("Bonus") as GameObject;
        enemy = Resources.Load("Enemy") as GameObject;
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
        isSpawned = false;
    }

    void Update()
    {
        if (!isSpawned)
        {
            StartCoroutine(Wait());
            isSpawned = true;
        }
    }

    public void Spawn(GameObject toSpawn)
    {
        x = Random.Range(xmin, xmax);
        y = 6f;

        Instantiate(toSpawn, new Vector3(x, y, 0), Quaternion.Euler(180, 0, 0));
    }

    public void SpawnBonus(GameObject toSpawn, Vector3 pos)
    {
        Instantiate(toSpawn, pos, Quaternion.Euler(180, 0, 0));
    }

    public void SetIsSpawned(bool value)
    {
        isSpawned = value;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);

        Spawn(enemy);
    }
}