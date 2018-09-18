using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    private Rigidbody2D rig;
    private GameController gameController;
    private GameObject[] meteorCollection;
    private GameObject[] enemyCollider;

    void Start () {
        gameController = FindObjectOfType<GameController>();
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = new Vector3(-2, 3, 0);
	}
	
	void Update () {
		if(transform.position.y > 0)
        {
            CollectMeteors();
            for(int i = 0; i < meteorCollection.Length; i++)
            {
                gameController.IncreaseScores();
                Destroy(meteorCollection[i]);
            }
            Destroy(gameObject);
        }
	}

    public void CollectMeteors()
    {
        meteorCollection = GameObject.FindGameObjectsWithTag("meteor");
    }

}
