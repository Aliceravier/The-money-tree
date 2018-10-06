using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour {

    public int Range;

    // If negative, the target entity is healed
    public int Damage;


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        GameObject nearestEnemy = this.GetComponent<Positioning>().FindNearestEnemyUnit();
        if (nearestEnemy != null && this.GetComponent<Positioning>().inNearRangeOf(nearestEnemy))
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
