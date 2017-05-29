using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed = 10f;
    public Text scoreText;

    private float scores = 0;
    private float scoreRate = 1;

    void Start()
    {      

    }

    void Update()
    {
        scores += Time.deltaTime;
        scoreText.text = "" + Mathf.Round(scores);
    }

    void FixedUpdate () {
        
        float x = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(x, 0, 0);
        transform.position += movement * speed * Time.deltaTime;

	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "meteor")
        {
            Destroy(gameObject);
        }
    }

    public float GetScores()
    {
        return scores;
    }

    public void BonusScores(float bonus)
    {
        scores +=bonus;
    }
}
