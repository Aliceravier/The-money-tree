using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject Bullet;

    public int bulletSpeed = 10;

    public int defaultDestructionTime = 5;

    public int Range = 10;

    // How the enemies to shoot are tagged
    public string EnemyTag = "EnemyUnit";

    Positioning _positioning;

    public int cooldownTime = 3;

    public float timeOfLastShot = 0;


	// Use this for initialization
	void Start()
    {
        _positioning = GetComponent<Positioning>();

	}
	
	// Update is called once per frame
	void Update () {
        GameObject nearestEnemy = _positioning.FindNearestTagged(EnemyTag);
        if (nearestEnemy == null)
        {
            return;
        }
        if (_positioning.DistanceTo(nearestEnemy) < Range && (Time.time - timeOfLastShot) > cooldownTime)
        {
            ShootEntity(nearestEnemy);
            timeOfLastShot = Time.time;
        }
	}


    // Shoot the given entity
    public void ShootEntity(GameObject entity)
    {
        GameObject newBullet = Object.Instantiate(Bullet, this.transform.position, Quaternion.identity);
        newBullet.transform.LookAt(entity.transform);
        newBullet.GetComponent<Rigidbody>().velocity = newBullet.transform.forward * bulletSpeed;
        newBullet.AddComponent<destroyAfterTime>();
        newBullet.GetComponent<destroyAfterTime>().timeTillDestruction = defaultDestructionTime;
    }
}
