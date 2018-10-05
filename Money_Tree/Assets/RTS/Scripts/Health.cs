using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // The hitpoints the entity can withstand.
    public uint HP = 50;

	// Use this for initialization
	void Start()
	{
	}
	
    // Makes the entity take some damage; destroys it if HP < 0
    public void TakeDamage(uint damage)
    {
        if(damage < HP)
        {
            HP -= damage;
        }
        else
        {
            // Entity took excessive damage and is now dying
            // TODO: Trigger death animation
            GameObject.Destroy(this.gameObject);
        }
    }
}
