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

    // The unit to restrict movement around
    public MainUnit MainUnit = null;

    // The number of frames that need to pass between consecutive
    // sprite flips so that they don't keep flipping erratically
    const uint FLIP_COOLDOWN = 10;

    // See flipping code
    const float SHOOT_FLIP_TRIGGER_TIME = 1.0f;

    Animator _animator;

    uint _flipCooldown; // How many frames have to pass 'til the next sprite flip
    SpriteRenderer _spriteRenderer;
    NavMeshAgent _navAgent;
    Selectable _selectable;
    Shoot _shoot; // OPTIONAL, see flipping code

	void Start()
	{
        _flipCooldown = 0;
        _navAgent = GetComponent<NavMeshAgent>();
        _selectable = GetComponent<Selectable>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _shoot = GetComponent<Shoot>();

        // Try to get the default main unit
        var mainUnitEnt = GameObject.Find("MainUnit");
        if(mainUnitEnt != null)
        {
            MainUnit = mainUnitEnt.GetComponent<MainUnit>();
        }
	}

    // Tell the unit to start moving towards a point if it was selected
    public void UnitMoveTowards(Vector3 point)
    {
        if(_selectable.Selected)
        {
            //Debug.Log("Unit " + this + " move towards " + point);
            _navAgent.destination = point;
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
        // Get to _targetPos, BUT ONLY IF IN RANGE OF MAINUNIT
        var mainUnitPos = MainUnit.transform.position;
        var distToMainUnit = (_navAgent.nextPosition - mainUnitPos).magnitude;
        var desiredDistToMainUnit = (_navAgent.destination - mainUnitPos).magnitude;

        // Stop moving if we're out of range AND we're trying to move further out of range
        _navAgent.isStopped = (distToMainUnit > MainUnit.LeechingRange)
                            && (desiredDistToMainUnit > MainUnit.LeechingRange);

        _animator.SetBool("isWalking", Moving && !_navAgent.isStopped);

        if(FlipSpriteX)
        {
            if(_flipCooldown == 0)
            {
                // Flip sprite:
                // - If we are shooting, based on where we are shooting
                // - If we are moving, based on where we are going
                // IN THIS PRIORITY

                // IMPORTANT: By default sprites should look to their left!
                // FIXME: Sometimes desiredVelocity flips at a very high rate;
                //        smooth it over time to reduce flipping at a too high rate
                Vector3 facingDir = _navAgent.desiredVelocity;
                if(_shoot != null)
                {
                    var now = Time.time;
                    if((now - _shoot.TimeOfLastShot) < SHOOT_FLIP_TRIGGER_TIME)
                    {
                        // We're shooting, so give priority to the shooting over the navigation
                        facingDir = _shoot.DirOfLastShot;
                    }
                }

                bool shouldBeFlipped = facingDir.x < 0.0f;
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
