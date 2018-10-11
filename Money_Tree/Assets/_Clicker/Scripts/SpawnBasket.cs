using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBasket : MonoBehaviour
{
    public Transform basket;
    private GameObject basketInstance;
    public int spawnX;
    public int spawnY;
    private bool placed;
    public Camera cam = null;
    // Use this for initialization
    void Start()
    {

        spawnX = 375;
        spawnY = 30;
        placed = false;
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If this is not a clone, check if we bought a new basket
        if (!gameObject.name.Contains("Clone") && BuyBasket.basket)
        {
            //Put the basket at the mouse pointer but have it follow pointer until placed
            basketInstance = Instantiate(Resources.Load("Basket"),
            cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y)),
            Quaternion.identity) as GameObject;
            this.placed = false;
            /**spawnX -= 15;
            if (spawnX < 200)
            {
                spawnX = 650;
                spawnY += 5;
            }*/
            BuyBasket.basket = false;
            this.name = "basket";
        }
        if  (!placed && !gameObject.name.Contains("basketball"))
        {
            gameObject.transform.SetPositionAndRotation(cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y + 20)), Quaternion.identity);
        }
    }

    void onMouseDown()
    {
        if (!placed)
        {
            placed = true; 
            if (!gameObject.name.Contains("basketball"))
            {
                Debug.Log("placed is " + placed);
            }
            
        }
    }
}
