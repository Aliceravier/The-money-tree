using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMover : MonoBehaviour 
{
    // The offset from the target point where to move the unit to.
    public Vector3 Offset = Vector3.zero;

    // Flip the sprite's X based on where we are moving towards?
    public bool FlipSpriteX = true;

    // The number of frames that need to pass between consecutive
    // sprite flips so that they don't keep flipping erratically
    const uint FLIP_COOLDOWN = 10;

    Animator anim;


    uint _flipCooldown; // How many frames have to pass 'til the next sprite flip
    SpriteRenderer _spriteRenderer;
    NavMeshAgent _navAgent;
    Selectable _selectable;


	void Start()
	{
        _flipCooldown = 0;
        _navAgent = GetComponent<NavMeshAgent>();
        _selectable = GetComponent<Selectable>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
	}

    // Tell the unit to start moving towards a point if it was selected
    public void UnitMoveTowards(Vector3 point)
    {
        if(_selectable.Selected)
        {
            //Debug.Log("Unit " + this + " move towards " + point);
            _navAgent.SetDestination(point + Offset);
        }
    }

    // Is the unit currently moving?
    public bool Moving
    {
        get
        {
            return _navAgent.desiredVelocity.magnitude > 0.1f;
        }
    }

	void Update()
	{
        if (Moving)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        if(FlipSpriteX)
        {
            if(_flipCooldown == 0)
            {
                // Flip sprite based on where we are going
                // IMPORTANT: By default sprites should look to their left!
                // FIXME: Sometimes desiredVelocity flips at a very high rate;
                //        smooth it over time to reduce flipping at a too high rate
                var velocity = _navAgent.desiredVelocity;

                bool shouldBeFlipped = velocity.x < 0.0f;
                if(shouldBeFlipped != _spriteRenderer.flipX)
                {
                    _spriteRenderer.flipX = shouldBeFlipped; // Flip now
                    _flipCooldown = FLIP_COOLDOWN; // Stop flipping for a while
                }
            }
            else
            {
                // Can't flip this frame, need to wait a bit more
                _flipCooldown --;
            }
        }
    }
}
