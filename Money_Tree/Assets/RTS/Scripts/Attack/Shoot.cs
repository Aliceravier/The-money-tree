using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject Bullet;
    public int BulletSpeed = 10;
    public int DefaultDestructionTime = 5;
    public int Range = 10;

    // How the enemies to shoot are tagged
    public string EnemyTag = "EnemyUnit";

    public int CooldownTime = 3;
    public float TimeOfLastShot = 0;
    public int Damage = 10;

    Positioning _positioning;
    UnitMover _unitMover;


	// Use this for initialization
	void Start()
    {
        _positioning = GetComponent<Positioning>();
        _unitMover = GetComponent<UnitMover>();
	}
	
	// Update is called once per frame
	void Update () {
        GameObject nearestEnemy = _positioning.FindNearestTagged(EnemyTag);
        if (nearestEnemy == null)
        {
            return;
        }

        if (_positioning.DistanceTo(nearestEnemy) < Range
            && (Time.time - TimeOfLastShot) > CooldownTime
            && !_unitMover.Moving)
        {
            ShootEntity(nearestEnemy);
            TimeOfLastShot = Time.time;
        }
	}


    // Shoot the given entity
    public void ShootEntity(GameObject entity)
    {
        GameObject newBullet = Object.Instantiate(Bullet, this.transform.position, Quaternion.identity);
        newBullet.transform.LookAt(entity.transform);
        newBullet.GetComponent<Rigidbody>().velocity = newBullet.transform.forward * BulletSpeed;
        newBullet.GetComponent<damageOnHit>().damage = Damage;
        newBullet.AddComponent<destroyAfterTime>();
        newBullet.GetComponent<destroyAfterTime>().timeTillDestruction = DefaultDestructionTime;
    }
}
