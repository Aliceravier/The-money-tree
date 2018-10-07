using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMe : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnMouseDown()
    {
        Clickable_Tree.treeSize++;
        //Destroys old colliders when tree changes size
        if (Clickable_Tree.treeSize == 100)
        {
            Destroy(gameObject.GetComponent<PolygonCollider2D>());
        }
        if (Clickable_Tree.treeSize == 500)
        {
            Destroy(gameObject.GetComponent<PolygonCollider2D>());
        }
        if (Clickable_Tree.treeSize == 800)
        {
            Destroy(gameObject.GetComponent<PolygonCollider2D>());
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
