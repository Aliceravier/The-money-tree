using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
	// NOTE: Place this well over the maximum height of the terrain and set Bounds
	//       to match the terrain's size
	//       It will create Spawners in midair; each individual Spawner will raycast
	//       to the ground to spawn entities at a proper location

	public GameObject SpawnerPrefab;
	public GameObject[] ToSpawn;
	public int NEach = 20;
	public int NSpawners = 20;

	public Vector3 Bounds = new Vector3(100.0f, 0.1f, 100.0f);



	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireCube(this.transform.position, Bounds);
	}

	// Generates a random coordinate in the spawn box.
	Vector3 RandBoxCoord()
	{
		return new Vector3(Random.Range(-Bounds.x / 2, +Bounds.x /2),
						   Random.Range(-Bounds.y / 2, +Bounds.y /2), 
		                   Random.Range(-Bounds.z / 2, +Bounds.z /2));
	}
	
	// Use this for initialization
	void Start()
	{
		foreach(var prefab in ToSpawn)
		{
			for(int i = 0; i < NSpawners; i ++)
			{
				var spawnPoint = this.transform.position + this.RandBoxCoord();

				var spawner = Instantiate(SpawnerPrefab, spawnPoint, Quaternion.identity).GetComponent<Spawner>();
				spawner.Prefab = prefab;
				spawner.Limit = NEach;
			}
		}
	}
}
