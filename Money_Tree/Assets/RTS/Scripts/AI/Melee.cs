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

    // The range when to chase enemies to hit
    public float DetectionRange = 50.0f;

    // Optional, only set for friendlies: if set, the agent to follow when idle.
    // Grabs the default MainUnit's agent if null.
    public NavMeshAgent MainAgent = null;

    State _state = State.Idle;
    Positioning _positioning;
    NavMeshAgent _navAgent;
    Hit _hit;
    Animator _animator;
    UnitMover _unitMover; // (Optional, only set for friendlies)

    // Use this for initialization
    void Start()
    {
        _positioning = GetComponent<Positioning>();
        _hit = GetComponent<Hit>();
        _navAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _unitMover = GetComponent<UnitMover>();

        if(this.MainAgent == null)
        {
            this.MainAgent = GameObject.Find("MainUnit").GetComponent<NavMeshAgent>();
        }
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
            // No one reachable in range
            _state = State.Idle;

            if(_unitMover != null && this.MainAgent != null)
            {
                // If this is a friendly unit, move towards MainUnit's target if idle
                _unitMover.UnitMoveTowards(this.MainAgent.destination);
            }
        }
        else
        {
            var nearest = nearestTargets[0];
            NavMeshPath pathToNearest = new NavMeshPath();
            bool nearestReachable = _navAgent.CalculatePath(nearest.transform.position, pathToNearest);
            if(!nearestReachable)
            {
                // No one reachable in range
                _state = State.Idle;
                return;
            }

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
