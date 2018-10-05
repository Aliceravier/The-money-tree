using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour {

    public int range;
    public uint damage;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        GameObject nearestEnemy = this.GetComponent<Positioning>().FindNearestEnemyUnit();
        if (this.GetComponent<Positioning>().inNearRangeOf(nearestEnemy))
        {
            hit(nearestEnemy);
        }
    }

    public void hit(GameObject enemy)
    {
        enemy.GetComponent<Health>().HP -= damage;
    }
}
