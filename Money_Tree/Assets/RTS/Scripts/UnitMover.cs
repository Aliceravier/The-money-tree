using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMover : MonoBehaviour 
{
    // The speed the unity moves at
    public float UnitSpeed = 10.0f;

    // The offset from the target point where to move the unit to.
    public Vector3 Offset = Vector3.zero;


    bool _selected = false;
    Vector3 _targetPos = Vector3.zero;

	void Start()
	{
        // Stay where we are at the beginning
        _targetPos = this.transform.position;
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
            //Debug.Log("Unit " + this + " move towards " + point);
            _targetPos = point + Offset;
        }
    }
}
