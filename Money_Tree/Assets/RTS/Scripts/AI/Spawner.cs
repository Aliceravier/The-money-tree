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
    public float Radius = 1.0f;

    // If 0, n limit
    public int Limit = 0;

    // If not null, the entity that needs to get in radius for the spawner to start spawning
    public GameObject TriggerUnit = null;

    uint _nSpawned;


    // Use this for initialization
    void Start()
    {
        this.InvokeRepeating("Spawn", Interval, Interval);
        _nSpawned = 0;
    }

    // Called when gizmos are to be drawn
    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(this.transform.position, Radius);
    }

    // Spawns an enemy
    public void Spawn()
    {
        if(TriggerUnit != null)
        {
            _nSpawned ++;
            if(Limit > 0 && _nSpawned > Limit)
            {
                return;
            }

            var triggerPos = TriggerUnit.transform.position;
            var selfPos = this.transform.position;
            if((triggerPos - selfPos).magnitude > Radius)
            {
                // Unit out of range, don't spawn
                return;
            }
        }

        var randOffset = new Vector3(Random.Range(-Radius, Radius),
                                     0.0f,
                                     Random.Range(-Radius, Radius));
        var spawnPos = this.transform.position + randOffset;
        Object.Instantiate(Prefab, spawnPos, Quaternion.identity);
    }
}
