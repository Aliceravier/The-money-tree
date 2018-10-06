﻿using System.Collections;
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

    void OnTriggerEnter(Collider collision)
    {
        var health = collision.gameObject.GetComponent<Health>();
        if (health != null && health.team != team){
            health.HP -= damage;
        }
    }
}
