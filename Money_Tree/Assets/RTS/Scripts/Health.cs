using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // The hitpoints the entity can withstand.
    public uint HP = 50;

    Animator _animator;

	// Use this for initialization
	void Start()
	{
        _animator = GetComponent<Animator>();
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
            // Entity took excessive damage and will now die
            if(_animator != null)
            {
                _animator.SetTrigger("Die");
                // FIXME: Wait until the animation ends
            }
            GameObject.Destroy(this.gameObject);
        }
    }
}
