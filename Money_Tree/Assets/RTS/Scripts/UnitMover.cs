using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMover : MonoBehaviour 
{
    // The offset from the target point where to move the unit to.
    public Vector3 Offset = Vector3.zero;

    // The color the sprite will glow when selected
    public Color SelectionGlowColor = Color.yellow;

    // Flip the sprite's X based on where we are moving towards?
    public bool FlipSpriteX = true;

    // The number of frames that need to pass between consecutive
    // sprite flips so that they don't keep flipping erratically
    const uint FLIP_COOLDOWN = 10;


    uint _flipCooldown; // How many frames have to pass 'til the next sprite flip
    bool _selected = false;
    MaterialPropertyBlock _materialProps; // (Used to control the glow when selected)
    SpriteRenderer _spriteRenderer;
    NavMeshAgent _navAgent;

	void Start()
	{
        _flipCooldown = 0;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _navAgent = GetComponent<NavMeshAgent>();


        // Initialize defaults
        _materialProps = new MaterialPropertyBlock();
        _selected = false;
        ApplyGlowColor(Color.black); // Initially deselected = no glow
	}


    // Applies the given color to "Sprites/Edge"'s _EdgeGlowColor
    void ApplyGlowColor(Color color)
    {
        _spriteRenderer.GetPropertyBlock(_materialProps);
        _materialProps.SetColor("_EdgeGlowColor", color);
        _spriteRenderer.SetPropertyBlock(_materialProps);
    }

	void OnMouseDown()
	{
        // Clicking on an unit's collider [de]selects it
        _selected = !_selected;
        ApplyGlowColor(_selected ? SelectionGlowColor : Color.black);
	}


    // Tell the unit to start moving towards a point if it was selected
    public void UnitMoveTowards(Vector3 point)
    {
        if(_selected)
        {
            //Debug.Log("Unit " + this + " move towards " + point);
            _navAgent.SetDestination(point + Offset);
        }
    }

	void Update()
	{
        if(FlipSpriteX)
        {
            if(_flipCooldown == 0)
            {
                // Flip sprite based on where we are going
                // IMPORTANT: By default sprites should look to their left!
                // FIXME: Sometimes desiredVelocity flips at a very high rate;
                //        smooth it over time to reduce flipping at a too high rate
                var velocity = _navAgent.desiredVelocity;

                bool shouldBeFlipped = velocity.x > 0.0f;
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
