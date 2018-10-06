using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageOnHit : MonoBehaviour {

    public int damage;

    public Team team = Team.player;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider collision)
    {
        var health = collision.gameObject.GetComponent<Health>();
        if ((health != null) && health.team != team){
            collision.gameObject.GetComponent<Health>().HP -= damage;
        }
    }
}
