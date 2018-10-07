using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySprinkler : MonoBehaviour {
    public static bool sprinkler;
	// Use this for initialization
	void Start () {
        sprinkler = false;
	}

    void OnMouseDown()
    {
        Debug.Log("Purchase sprinkler clicked");
        if (MakeItRain.money >= 10)
        {
            MakeItRain.money -= 10;
            sprinkler = true;
        }
        Debug.Log("Sprinkler is " + sprinkler);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
