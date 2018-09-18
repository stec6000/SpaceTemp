using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissileController : MonoBehaviour {

    private GameObject missilePrefab;
    private float time = 10f;
    private float counter = 10f;
    private bool fire = true;
    private Image image;

    public GameObject button;

	void Start () {
        missilePrefab = Resources.Load("Missile") as GameObject;
        image = button.GetComponent<Image>();
        image.fillAmount = 100;
    }
	
	void Update () {
        counter += Time.deltaTime;
        if (counter <= time) fire = false;
        else fire = true;

        if (!fire)
        {
            image.fillAmount += 1f / time * Time.deltaTime;
        }

	}

    public void Fire()
    {
        if (fire)
        {
            GameObject missile = Instantiate(missilePrefab);
            missile.transform.position = new Vector3(3, -4, 0);
            counter = 0;
            image.fillAmount = 0;
        }
    }
}
