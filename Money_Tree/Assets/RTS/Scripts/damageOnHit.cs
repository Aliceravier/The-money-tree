using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageOnHit : MonoBehaviour {

    public int damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (!CompareTag(collision.gameObject.tag) && (collision.gameObject.GetComponent("Health")) != null){
            collision.gameObject.GetComponent<Health>().HP -= damage;
        }
    }
}
