using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Melee : MonoBehaviour
{
    // Melee: when enemies get in DetectionRange, move towards them

    enum State
    {
        Idle,
        Targetting,
    }

    public float DetectionRange = 50.0f;

    State _state = State.Idle;
    Positioning _positioning;
    NavMeshAgent _navAgent;
    Hit _hit;

    // Use this for initialization
    void Start()
    {
        _positioning = GetComponent<Positioning>();
        _hit = GetComponent<Hit>();
        _navAgent = GetComponent<NavMeshAgent>();
    }
    
    // Update is called once per frame
    void Update()
    {
        var nearestTargets = _positioning.FindAllTaggedByDistanceInRange(_hit.EnemyTag, DetectionRange);
        if(nearestTargets.Length == 0)
        {
            // No one in range
            _state = State.Idle;
        }
        else
        {
            // Move towards nearest
            _state = State.Targetting;
            _navAgent.SetDestination(nearestTargets[0].transform.position);
        }
    }
}
