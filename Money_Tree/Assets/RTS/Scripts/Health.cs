using Math = System.Math;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Team
{
    player, enemy
};


public class Health : MonoBehaviour
{
    // The maximum HP of the entity.
    public int MaxHP = 50;

    public static SceneManager marvin; //For game end condition

    public GameObject Particle;

    public float particleSpeed =4;

    public float timeTillParticleDestruction=2;

    public Team team;

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
        marvin = GetComponent<SceneManager>();
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
            
            // Entity took excessive damage and will now die (only applies if you somehow are still in RTS scene)
            GameObject.Destroy(this.gameObject);
            int nbParticles = 100;
            for (int i = 0; i < nbParticles; i++)
            {
                GameObject newParticle = Object.Instantiate(Particle, this.transform.position, Quaternion.identity);
                newParticle.transform.rotation = Random.rotation;
                newParticle.GetComponent<Rigidbody>().velocity = newParticle.transform.forward * particleSpeed;
                newParticle.AddComponent<destroyAfterTime>();
                newParticle.GetComponent<destroyAfterTime>().timeTillDestruction = timeTillParticleDestruction;
            }
            if (gameObject.name.Contains("MainUnit")) {
                SceneManager.LoadScene("yall_dead");
                SceneManager.UnloadScene("RTS");
            }
            
        }
    }
}
