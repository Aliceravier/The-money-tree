using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // The hitpoints the entity can withstand.
    public uint MAX_HP = 50;
    public uint HP = MAX_HP;

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
