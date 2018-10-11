using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBack : MonoBehaviour {
    public Vector3 pos;
    float constantSpeed;
    // Use this for initialization
    void Start () {
        constantSpeed = 10f;
    }
	
	// Update is called once per frame
	void Update () {
        //The following line is supposed to make it move at a constant velocity.
        //gameObject.GetComponent<Rigidbody2D>().velocity = constantSpeed * (gameObject.GetComponent<Rigidbody2D>().velocity.normalized);
        pos = transform.position;
        Debug.Log("pos x is " + pos.x);
        if (pos.x > 402)
        {
            transform.position = new Vector3(-378, 42, 0);
        }
	}

}
