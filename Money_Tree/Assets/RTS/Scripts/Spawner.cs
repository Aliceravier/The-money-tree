using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	// The interval in seconds between consecutive spawns
	public float Interval = 10.0f;

	// The prefab to spawn
	public GameObject Prefab = null;

	// The radius around this.Transform.origin where to spawn Prefabs
	public float Radius = 1.0f;


	// Use this for initialization
	void Start()
    {
        this.InvokeRepeating("Spawn", Interval, Interval);
	}

	// Called when gizmos are to be drawn
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(this.transform.position, Radius);
    }

	
	// Spawns an enemy
	public void Spawn()
    {
        // FIXME IMPLEMENT Object.Instantiate(Prefab, );
	}
}
