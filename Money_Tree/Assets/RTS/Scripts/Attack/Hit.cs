using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour {

    public int Range;

    // If negative, the target entity is healed
    public int Damage;

    // How the enemies to hit are tagged
    public string EnemyTag = "EnemyUnit";


    Positioning _positioning;

    // Use this for initialization
    void Start()
    {
        _positioning = this.GetComponent<Positioning>();
	}

    // Update is called once per frame
    void Update()
    {
        GameObject nearestEnemy = _positioning.FindNearestTagged(EnemyTag);
        if (nearestEnemy != null && _positioning.DistanceTo(nearestEnemy) <= Range)
        {
            HitEntity(nearestEnemy);
        }
    }

    // Deal Damage to entity
    // Note that if Damage is negative the entity is healed!
    public void HitEntity(GameObject entity)
    {
        entity.GetComponent<Health>().HP -= Damage;
    }
}
