using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrows : MonoBehaviour {
    public Sprite[] treeSprites;
    bool resized1 = false;
    bool resized2 = false;
    bool resized3 = false;
    public static bool watering;
    public static int timer;
    private AudioSource source;
    // Use this for initialization
    void Start () {
        treeSprites = Resources.LoadAll<Sprite>("real_tree");
        timer = 0;
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (timer > 0)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
        watering = false;
        //Update the tree sprite
        if (Clickable_Tree.treeSize < 100)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = treeSprites[0];
        }
        else if (Clickable_Tree.treeSize < 500)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = treeSprites[1];
        }
        else if (Clickable_Tree.treeSize < 800)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = treeSprites[2];
        }
        else 
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = treeSprites[3];
        }

        if (Clickable_Tree.treeSize == 100 && !resized1)
        {
            gameObject.AddComponent<PolygonCollider2D>();
            resized1 = true;
        }
        if (Clickable_Tree.treeSize == 500 && !resized2)
        {
            gameObject.AddComponent<PolygonCollider2D>();
            resized2 = true;
 
        }
        if (Clickable_Tree.treeSize == 800 && !resized3)
        {
            gameObject.AddComponent<PolygonCollider2D>();
            resized3 = true;
        }
        if (timer > 0)
        {
            timer--;
        }
    }

    void OnMouseDown()
    {
        source.Play();
        watering = true;
        Clickable_Tree.treeSize++;
        timer = 10;
    }
}
