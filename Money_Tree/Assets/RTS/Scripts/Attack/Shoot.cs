using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject Bullet;

    public int Range;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject nearestEnemy = this.GetComponent<Positioning>().FindNearestEnemyUnit();
        if (this.GetComponent<Positioning>().inFarRangeOf(nearestEnemy))
        {
            ShootEntity(nearestEnemy);
        }
	}


    // Shoot the given entity
    public void ShootEntity(GameObject entity)
    {
        // FIXME IMPLEMENT: Spawn bullet towards entity
    }
}
