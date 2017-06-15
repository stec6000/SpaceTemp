using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public PlayerController playerController;
    public MeteorSpawn meteorSpawn;
    public Text scoreText;
    public Text livesText;

    private float scores = 0;
    private float level = 1;

	void Start () {
		
	}
	
	void Update () {
        
		if(scores > level * 10)
        {
            meteorSpawn.SpawnTimeDecreas();
            level++;
        }
        scoreText.text = "" + scores;
        livesText.text = "" + playerController.GetLives();
	}

    public void IncreaseScores()
    {
        scores++;
    }
}
