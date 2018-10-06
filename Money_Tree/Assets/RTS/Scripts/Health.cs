﻿using Math = System.Math;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // The maximum HP of the entity.
    public int MaxHP = 50;

    // The current HP of the entity.
    // The setter internally calls `TakeDamage()`
    public int HP
    {
        get
        {
            return _hp;
        }
        set
        {
            TakeDamage(_hp - value);
        }
    }

    int _hp; // (Stores HP)
    Animator _animator;


	// Use this for initialization
	void Start()
	{
        _hp = MaxHP;
        _animator = GetComponent<Animator>();
	}


    // Clamps an integer to two values
    static int Clamp(int value, int min, int max)
    {
        return Math.Min(Math.Max(value, min), max);
    }
	
    // Makes the entity take some damage; destroys it if HP < 0
    // If negative damage is given, HP will actually be increased!
    public void TakeDamage(int damage)
    {
        _hp -= damage;
        _hp = Clamp(_hp, 0, MaxHP);

        if(_hp <= 0)
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
