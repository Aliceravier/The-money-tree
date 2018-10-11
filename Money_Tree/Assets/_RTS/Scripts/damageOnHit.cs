using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageOnHit : MonoBehaviour {

    public int damage;

    public Team team;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collider collision)
    {
        var health = collision.gameObject.GetComponent<Health>();
        if (health != null && health.Team != team){
            health.HP -= damage;
        }
    }
}
