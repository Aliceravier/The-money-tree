using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprinklerSpray : MonoBehaviour {
    int timer;
    public Sprite[] sprinklerSprites;
    // Use this for initialization
    void Start () {
        timer = 0;
        sprinklerSprites = Resources.LoadAll<Sprite>("sprinkler");
    }
	
	// Update is called once per frame
	void Update () {
        //Sprinkle the water
        if (timer < 40)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprinklerSprites[0];
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprinklerSprites[1];
        }
        timer++;
        if (timer > 80)
        {
            timer = 0;
        }
    }
}
