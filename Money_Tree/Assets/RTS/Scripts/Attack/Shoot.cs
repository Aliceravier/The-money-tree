using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject Bullet;

    public int Range;

    // How the enemies to shoot are tagged
    public string EnemyTag = "EnemyUnit";

    Positioning _positioning;

    public int cooldownTime = 10;

    public float timeOfLastShot = 0;


	// Use this for initialization
	void Start()
    {
        _positioning = GetComponent<Positioning>();

	}
	
	// Update is called once per frame
	void Update () {
        GameObject nearestEnemy = _positioning.FindNearestTagged(EnemyTag);
        if (this.GetComponent<Positioning>().inFarRangeOf(nearestEnemy) && (Time.time - timeOfLastShot) > cooldownTime)
        {
            ShootEntity(nearestEnemy);
            timeOfLastShot = Time.time;
        }
	}


    // Shoot the given entity
    public void ShootEntity(GameObject entity)
    {
        Object.Instantiate(Bullet, this.transform.position, Quaternion.identity);
        Bullet.GetComponent<Rigidbody>().velocity = Bullet.transform.forward * 6;
    }
}
