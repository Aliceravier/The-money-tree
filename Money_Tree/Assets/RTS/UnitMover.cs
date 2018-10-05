using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMover : MonoBehaviour 
{
    bool _selected = false;
    Vector3 _targetPos = Vector3.zero;

	void Start()
	{
	}
	
	void Update()
	{
		
	}

	void OnMouseDown()
	{
        // Clicking on an unit's collider [de]selects it
        _selected = !_selected;
	}


    // Tell the unit to start moving towards a point
    public void UnitMoveTowards(Vector3 point)
    {
        // TODO IMPLEMENT
    }
}
