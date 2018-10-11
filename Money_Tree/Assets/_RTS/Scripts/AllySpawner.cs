using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllySpawner : MonoBehaviour
{
	// The entities to instantiate when the user clicks on the unit
	public GameObject[] PrefabsToSpawn;

	// The radius around the unity where to spawn the prefabs
	public float SpawnRadius = 10.0f;

	// The offset above ground where to put the spawned prefabs
	public Vector3 SpawnOffset = new Vector3(0.0f, 1.5f, 0.0f);

	void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere(this.transform.position, SpawnRadius);
	}


	// Generates a random coordinate in a circle.
	public Vector2 RandCircleCoord(float radius)
	{
		return new Vector2(Random.Range(-SpawnRadius, SpawnRadius),
						   Random.Range(-SpawnRadius, SpawnRadius));
	}
	
	void OnMouseDown()
	{
		foreach(var prefab in PrefabsToSpawn)
		{
			// Spawn each prefab at a random point; pick a point on a circle,
			// raycast to ground, spawn object at (raycasted point + offset)
			var offset2D = RandCircleCoord(SpawnRadius);

			var posAboveGround = this.transform.position;
			posAboveGround.x += offset2D.x;
			posAboveGround.z += offset2D.y;

			RaycastHit rayHit;
			Ray ray = new Ray(posAboveGround, Vector3.down);
			if(!Physics.Raycast(ray, out rayHit))
			{
				Debug.LogError("NeutralUnit spawn raycast failed!!");
			}

			var spawnPoint = rayHit.point + SpawnOffset;
			Object.Instantiate(prefab.gameObject, spawnPoint, Quaternion.identity);
		}

		// Goodbye, cruel world :(
		Object.Destroy(this.gameObject);
	}
}
