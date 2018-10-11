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

    public GameObject DeathParticle;
    public float DeathParticleSpeed = 4;
    public float TimeUntilParticleDestruction = 2;
    // A list of death sounds from which to choose from
    public AudioClip[] DeathSounds = null;

    // If non-null/empty, change scene to DeathScene on death 
    public string DeathScene = null;

    public Team Team = Team.player;

    int _hp; // (Stores HP)
    private AudioSource _source;
    Animator _animator;

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


	// Use this for initialization
	void Start()
	{
        _hp = MaxHP;
        _animator = GetComponent<Animator>();
        _source = GetComponent<AudioSource>();
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
            //TODO: Play random sound on death

            // Trigger scene change if necessary
            // (Now with 100% less Marvin)
            if(this.DeathScene != null && this.DeathScene.Length > 0)
            {
                Debug.Log(this + "died, loading scene " + this.DeathScene);
                SceneManager.LoadScene(this.DeathScene, LoadSceneMode.Single);
            }
            
            // Entity took excessive damage and will now die (only applies if you somehow are still in RTS scene)
            GameObject.Destroy(this.gameObject);
            int nbParticles = 100;
            for (int i = 0; i < nbParticles; i++)
            {
                GameObject newParticle = Object.Instantiate(DeathParticle, this.transform.position, Quaternion.identity);
                newParticle.transform.rotation = Random.rotation;
                newParticle.GetComponent<Rigidbody>().velocity = newParticle.transform.forward * DeathParticleSpeed;
                newParticle.AddComponent<destroyAfterTime>();
                newParticle.GetComponent<destroyAfterTime>().timeTillDestruction = TimeUntilParticleDestruction;
            }
        }
    }
}
