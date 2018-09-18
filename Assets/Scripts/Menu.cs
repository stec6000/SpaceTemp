using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public Canvas CreditsCanvas;
    public Canvas MenuCanvas;
    public Text highScore;
    

	void Start () {
        
        if (SceneManager.GetActiveScene().name.Equals("Menu"))
        {
            PlayerPrefs.SetInt("BulletsState", 0);
            PlayerPrefs.SetInt("Lifes", 3);
            PlayerPrefs.SetInt("Level", 0);
            PlayerPrefs.SetFloat("Shoot", 1f);
            PlayerPrefs.SetInt("Scores", 0);
            highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
        
	}
	
	void Update () {
		
	}

    public void LoadScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        MenuCanvas.enabled = false;
        CreditsCanvas.enabled = true;
    }

    public void Back()
    {
        CreditsCanvas.enabled = false;
        MenuCanvas.enabled = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
}
