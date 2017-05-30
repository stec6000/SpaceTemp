using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed = 10f;
    public Text scoreText;

    private float scores = 0;
    private float scoreRate = 1;
    private float padding = 0.5f;
    private float xmin;
    private float xmax;

    void Start()
    {

        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
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


        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

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
