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


    bool _selected = false;
    MaterialPropertyBlock _materialProps; // (Used to control the glow when selected)
    SpriteRenderer _spriteRenderer;
    NavMeshAgent _navAgent;

	void Start()
	{
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _navAgent = GetComponent<NavMeshAgent>();


        // Initialize defaults
        _materialProps = new MaterialPropertyBlock();
        _selected = false;
        ApplyGlowColor(Color.black); // Initially deselected = no glow
	}

	
	void Update()
	{
        // (Let _navAgent do its thing)
    }

    void OnCollisionEnter(Collision collision)
    {
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
}
