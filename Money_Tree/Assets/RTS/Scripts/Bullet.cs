using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // How much damage the bullet will do when it collides
    // If negative, the bullet will heal the collided entity!
    public int Damage = 50;


    // Use this for initialization
    void Start()
    {
    }
    
    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        var otherObject = collision.gameObject;
        var otherHealth = otherObject.GetComponent<Health>();
        if(otherHealth != null && this.tag != otherObject.tag)
        {
            // Deal Damage to entity
            otherHealth.TakeDamage(Damage);
        }
    }
}
