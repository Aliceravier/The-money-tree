using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject bullet;
    public int range;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject nearestEnemy = this.GetComponent<Positioning>().findNearestEnemy();
        if (this.GetComponent<Positioning>().inRangeOfEnemy(nearestEnemy))
        {
            shoot(nearestEnemy);
        }
	}

    public void shoot(GameObject enemy)
    {

    }
}
