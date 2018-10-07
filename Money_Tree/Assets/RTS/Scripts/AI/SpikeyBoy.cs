using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Spikey boy: roams around randomly;
// if one player unit in range, he attacks AOE in Hit.Range
public class SpikeyBoy : MonoBehaviour
{
    public float RoamingRadius = 50.0f;

    enum State
    {
        Roaming,
        Attacking,
    }

    State _state = State.Roaming;

    Positioning _positioning;
    Hit _hit;
    NavMeshAgent _navAgent;
    Animator _animator;


    // Use this for initialization
    void Start()
    {
        _positioning = GetComponent<Positioning>();
        _hit = GetComponent<Hit>();
        _navAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    // Draw roaming radius
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, RoamingRadius);
    }

    
    // Update is called once per frame
    void Update()
    {
        var inRange = _positioning.FindAllTaggedByDistanceInRange(_hit.EnemyTag, _hit.Range);
        if(inRange.Length > 0)
        {
            // Stay where we are and AOE all in Hit.Range
            _navAgent.SetDestination(this.transform.position);
            _state = State.Attacking;
            _animator.SetTrigger("startAttack");
        }
        else
        {
            // No one in hit range, roam around
            if(_navAgent.desiredVelocity.magnitude < 0.1f)
            {
                // We have reached the random destination; pick another
                var randOffset = new Vector3(Random.Range(-RoamingRadius, RoamingRadius),
                                            0.0f,
                                            Random.Range(-RoamingRadius, RoamingRadius));
                var randDest = this.transform.position + randOffset;
                _navAgent.SetDestination(randDest);
            }
        }
    }
}
