using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watering : MonoBehaviour {
    public Sprite[] farmerSprites;
    public static int hat;
    int timer;
    // Use this for initialization
    void Start () {
        farmerSprites = Resources.LoadAll<Sprite>("farmer");
        hat = 1;
        timer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        //Animation for watering
        timer++;
		if (timer < 20)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = farmerSprites[hat - 1];
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = farmerSprites[hat];
        }
        if (timer > 40)
        {
            timer = 0;
        }

	}
}
