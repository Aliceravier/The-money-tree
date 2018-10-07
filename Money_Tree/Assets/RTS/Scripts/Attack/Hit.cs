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
    Animator _animator;

    // Use this for initialization
    void Start()
    {
        _positioning = this.GetComponent<Positioning>();
        _animator = this.GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
    }


    // Deal Damage to entity
    // Note that if Damage is negative the entity is healed!
    public void HitEntity(GameObject entity)
    {
        _animator.SetTrigger("isAttacking");
        entity.GetComponent<Health>().HP -= Damage;
    }

    // Deal Damage to nearest entity
    public void HitNearest()
    {
        var nearest = _positioning.FindNearestTagged(EnemyTag);
        if(nearest != null)
        {
            this.HitEntity(nearest);
        }
    }

    // Finds all enemy entities in hit range
    public List<GameObject> FindAllInRange()
    {
        var list = new List<GameObject>();

        var nearest = _positioning.FindAllTaggedByDistance(EnemyTag);
        if(nearest != null)
        {
            // Someone is in range
            foreach(GameObject ent in nearest)
            {
                if(_positioning.DistanceTo(ent) > Range)
                {
                    break; // NOTE: nearest is sorted by distance!
                }
                list.Add(ent);
            }
        }

        return list;
    }

    // Deal Damage to all entities in range
    public void HitAllInRange()
    {
        var inRange = FindAllInRange();
        foreach(GameObject ent in inRange)
        {
            this.HitEntity(ent);
        }
    }
}
