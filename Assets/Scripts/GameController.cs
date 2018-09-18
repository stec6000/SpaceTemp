using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public PlayerController playerController;
    public MeteorSpawn meteorSpawn;
    public EnemySpawn enemySpawn;
    public Text scoreText;
    public Text livesText;

    private int scores;
    private int level;
    private int playerLifes;
    private List<int> highScore;

	void Start () {
        highScore = new List<int>();
        scores = PlayerPrefs.GetInt("Scores");
        level = PlayerPrefs.GetInt("Level");
        if(SceneManager.GetActiveScene().name.Equals("Game"))
        for(int i = 1; i< level; i++)
        {
            meteorSpawn.SpawnTimeDecreas();
        }
	}
	
	void Update () {
        

		if (scores > level * level * 10 + 20 && SceneManager.GetActiveScene().name.Equals("Game"))
        {
            level++;
            ++scores;
            Save();
            SceneManager.LoadScene("Boss" + level);
        }

        playerLifes = playerController.GetLifes();
        scoreText.text = "" + scores;
        livesText.text = "" + playerLifes;
        

        //if player is dead
        if(playerLifes <= 0)
        {
            PlayerPrefs.SetInt("HighScore", scores);
            SceneManager.LoadScene("Menu");
        }
	}

    public void IncreaseScores()
    {
        scores += level + 1;
    }

    public int GetLevel()
    {
        return level;
    }
    
    public void Save()
    {
        
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.SetInt("Scores", scores);
        PlayerPrefs.SetFloat("Shoot", playerController.GetTimeBetweenShoots());
        PlayerPrefs.SetInt("BulletsState", playerController.GetBullets());
    }
}
