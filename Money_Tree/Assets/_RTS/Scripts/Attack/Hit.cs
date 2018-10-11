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

    public void setIsAttacking()
    {
        _animator.SetBool("isAttacking", true);
    }

    public void unsetIsAttacking()
    {
        _animator.SetBool("isAttacking", false);
    }


    // Deal Damage to entity
    // Note that if Damage is negative the entity is healed!
    public void HitEntity(GameObject entity)
    {
        //_animator.SetBool("isAttacking", true);
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

    // Deal Damage to all entities in range
    public void HitAllInRange()
    {
        var inRange = _positioning.FindAllTaggedByDistanceInRange(EnemyTag, Range);
        foreach(GameObject ent in inRange)
        {
            this.HitEntity(ent);
        }
    }
}
