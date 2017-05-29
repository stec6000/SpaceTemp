using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public PlayerController playerController;
    public MeteorSpawn meteorSpawn;

    private float level = 1;

	void Start () {
		
	}
	
	void Update () {
		if(playerController.GetScores() > level * 10)
        {
            meteorSpawn.SpawnTimeDecreas();
            level++;
            playerController.BonusScores(level / 2);
        }
	}
}
