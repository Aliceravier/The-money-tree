using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBasket : MonoBehaviour
{
    public Transform basket;
    private GameObject basketInstance;
    public int spawnX;
    public int spawnY;
    // Use this for initialization
    void Start()
    {

        spawnX = 350;
        spawnY = 30;
    }

    // Update is called once per frame
    void Update()
    {
        //If this is not a clone, check if we bought a new sprinkler
        if (!gameObject.name.Contains("Clone") && BuyBasket.basket)
        {
            basketInstance = Instantiate(Resources.Load("Basket"),
            new Vector3(spawnX, spawnY),
            Quaternion.identity) as GameObject;
            spawnX -= 10;
            if (spawnX < 200)
            {
                spawnX = 650;
                spawnY += 5;
            }
            BuyBasket.basket = false;
            this.name = "basket";
        }
    }
}
