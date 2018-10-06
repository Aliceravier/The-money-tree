using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject Bullet;

    public int Range;

    // How the enemies to shoot are tagged
    public string EnemyTag = "EnemyUnit";

    Positioning _positioning;


	// Use this for initialization
	void Start()
    {
        _positioning = GetComponent<Positioning>();
	}
	
	// Update is called once per frame
	void Update () {
        GameObject nearestEnemy = _positioning.FindNearestTagged(EnemyTag);
        if(nearestEnemy != null && _positioning.DistanceTo(nearestEnemy) < Range)
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
