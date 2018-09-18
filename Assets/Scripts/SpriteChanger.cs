using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour {

    private SpriteRenderer spriteR;
    private Sprite[] newSprite;

    void Awake () {
        spriteR = gameObject.GetComponentInChildren<SpriteRenderer>();
        newSprite = Resources.LoadAll<Sprite>("Sprites/bullets");
    }
	
	void Update () {
		
	}

    public void Change(int number)
    {
        
        spriteR.sprite = newSprite[number];
    }
}
