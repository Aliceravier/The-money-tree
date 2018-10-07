using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyBasket : MonoBehaviour
{
    public static bool basket;
    // Use this for initialization
    void Start()
    {
        basket = false;
    }

    void OnMouseDown()
    {
        Debug.Log("Purchase basket clicked");
        if (MakeItRain.money >= 5)
        {
            MakeItRain.money -= 5;
            basket = true;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
