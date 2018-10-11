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
    // Note that prefabs are only spawned in the XZ plane!
    public float Radius = 20.0f;

    // If 0, no limit
    public int Limit = 0;

    // If not null, the entity that needs to get in radius for the spawner to start spawning
    // NOTE: "Getting in radius" means on the XZ plane!
    public GameObject TriggerUnit = null;

    // The offset above ground where to spawn an entity
    public Vector3 Offset = new Vector3(0.0f, 0.3f, 0.0f);

    uint _nSpawned;


    // Use this for initialization
    void Start()
    {
        this.InvokeRepeating("Spawn", Interval, Interval);
        _nSpawned = 0;
    }

    void OnDrawGizmos()
    {
        // FIXME: Should actually draw an uncapped cylinder!
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(this.transform.position, this.Radius);
    }

    // Spawns an enemy
    public void Spawn()
    {
        if(Prefab == null)
        {
            return;
        }

        _nSpawned ++;
        if(Limit > 0 && _nSpawned > Limit)
        {
            return;
        }

        if(TriggerUnit != null)
        {
            // Calculate XZ distance
            var triggerPosXZ = TriggerUnit.transform.position;
            triggerPosXZ.y = 0.0f;

            var selfPosXZ = this.transform.position;
            selfPosXZ.y = 0.0f;

            if((triggerPosXZ - selfPosXZ).magnitude > Radius)
            {
                // Unit out of range, don't spawn
                return;
            }
        }


        var randOffset = new Vector3(Random.Range(-Radius, Radius),
                                     0.0f,
                                     Random.Range(-Radius, Radius));
        var spawnPoint = this.transform.position + randOffset;

        RaycastHit spawnRayHit;
        var spawnRay = new Ray(spawnPoint, Vector3.down);
        if(Physics.Raycast(spawnRay, out spawnRayHit))
        {
            Object.Instantiate(Prefab, spawnRayHit.point + Offset, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Raycast to ground failed, could not spawn prefab!");
        }

    }
}
