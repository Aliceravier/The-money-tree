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
}
