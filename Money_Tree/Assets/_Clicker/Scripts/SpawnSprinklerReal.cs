using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSprinklerReal : MonoBehaviour
{
    public Transform sprinkler;
    private GameObject sprinklerInstance;
    public int spawnX;
    public int spawnY;
    
    int timer;
    // Use this for initialization
    void Start()
    {
        
        spawnX = 450;
        spawnY = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //If this is not a clone, check if we bought a new sprinkler
        if (!gameObject.name.Contains("Clone") && BuySprinkler.sprinkler)
        {
            sprinklerInstance = Instantiate(Resources.Load("Sprinkler"),
            new Vector3(spawnX, spawnY),
            Quaternion.identity) as GameObject;
            spawnX += 10;
            if (spawnX > 550)
            {
                spawnX = 450;
                spawnY += 10;
            }
            BuySprinkler.sprinkler = false;
        }

        //Water the tree occasionally if this is a clone
        if (gameObject.name.Contains("Clone"))
        {
            if (timer == 0)
            {
                Clickable_Tree.treeSize++;
            }
            timer++;
            if (timer > 80)
            {
                timer = 0;
            }
            
        }

        

    }
}
