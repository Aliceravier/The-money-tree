using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    public string UnitTag = "PlayerUnit";

	// Use this for initialization
	void Start()
    {
	}
	
	// Update is called once per frame
	void Update()
    {
	}

    void OnMouseDown()
    {
        var clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);    
        RaycastHit clickRayHit;
        var clickHit = Physics.Raycast(clickRay, out clickRayHit);

        var units = GameObject.FindGameObjectsWithTag(UnitTag);
        foreach(GameObject unit in units)
        {
            unit.SendMessage("UnitMoveTowards", clickRayHit.point);
        }
    }
}
