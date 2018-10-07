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
    Animator _animator;

    // Use this for initialization
    void Start()
    {
        _positioning = GetComponent<Positioning>();
        _hit = GetComponent<Hit>();
        _navAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    // Draw detection range
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, DetectionRange);
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
            var nearest = nearestTargets[0];

            // Move towards nearest
            _state = State.Targetting;
            _navAgent.SetDestination(nearest.transform.position);

            // Hit nearest if in range
            if(_positioning.DistanceTo(nearest) <= _hit.Range)
            {
                _animator.SetTrigger("startAttack");
            }
        }
    }
}
