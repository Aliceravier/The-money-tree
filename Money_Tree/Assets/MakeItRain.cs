using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class MakeItRain : MonoBehaviour {
    public static int money = 0;
    public Transform coin;
    private GameObject coinInstance;
    // Use this for initialization
    void Start () {
       
	}

    //Money disappears when clicked and adds to the global money variable
    
    // Update is called once per frame
    void Update () {
        if (!gameObject.name.Contains("Clone"))
        {
            System.Random gen = new System.Random();

            int x = gen.Next(-1500, 1500);
            if (x < Clickable_Tree.treeSize/5 && x > -Clickable_Tree.treeSize/5) {
                coinInstance = Instantiate(Resources.Load("Coin"),
                new Vector3(x, 200),
                Quaternion.identity) as GameObject;
            }
        } 
	}

    void OnMouseDown()
    {
        money++;
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Contains("basket"))
        {
            money++;
            Destroy(gameObject);
            Debug.Log("Collision occurred with basket");
        }
        else {
            Debug.Log("Collision occurred with nonbasket");
        }
        
    }

}
