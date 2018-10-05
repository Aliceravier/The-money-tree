using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMover : MonoBehaviour 
{
    /// The speed the unity moves at
    float UnitSpeed = 10.0f;

    bool _selected = false;
    Vector3 _targetPos = Vector3.zero;

	void Start()
	{
	}
	
	void Update()
	{
        var curPos = this.transform.position;
        var nextPos = Vector3.MoveTowards(curPos, _targetPos, UnitSpeed * Time.deltaTime);
        this.transform.position = nextPos;
	}

	void OnMouseDown()
	{
        // Clicking on an unit's collider [de]selects it
        _selected = !_selected;
	}


    // Tell the unit to start moving towards a point if it was selected
    public void UnitMoveTowards(Vector3 point)
    {
        if(_selected)
        {
            _targetPos = point;
        }
    }
}
