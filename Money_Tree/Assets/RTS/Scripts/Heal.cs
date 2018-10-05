using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour {

    public uint healPower = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject nearestPlayerUnit = this.GetComponent<Positioning>().findNearestPlayerUnit();
		if(this.GetComponent<Positioning>().inFarRangeOf(nearestPlayerUnit) && nearestPlayerUnit.GetComponent<Health>().HP < nearestPlayerUnit.GetComponent<Health>().MAX_HP)
        {
            heal(nearestPlayerUnit);
        }
	}

    void heal(GameObject unit)
    {
        unit.GetComponent<Health>().HP += healPower;
    }

}
