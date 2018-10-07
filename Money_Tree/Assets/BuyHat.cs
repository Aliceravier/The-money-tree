using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyHat : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnMouseDown()
    {
       System.Random gen = new System.Random();
       if (MakeItRain.money >= 20)
        {
            int newHat = -1; //error value, will throw null pointer if processed
            do
            {
                newHat = (gen.Next(1, 5) * 2) + 1;
            }
            while (newHat == Watering.hat);
            Watering.hat = newHat;
            MakeItRain.money -= 20;
        } 
    }
    // Update is called once per frame
    void Update () {
		
	}
}
