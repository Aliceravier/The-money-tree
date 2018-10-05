using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positioning : MonoBehaviour {

    GameObject[] enemies;


	// Use this for initialization
	void Start () {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject findNearestEnemy()
    {
        float minDistance = distanceTo(enemies[0]);
        GameObject nearestEnemy = enemies[0];
        foreach(GameObject enemy in enemies)
        {
            if(distanceTo(enemy) < minDistance)
            {
                nearestEnemy = enemy;
                minDistance = distanceTo(enemy);
            }
        }
        return nearestEnemy;
    }

    public bool inRangeOfEnemy(GameObject enemy)
    {
        int range = this.gameObject.GetComponent<Shoot>().range;
        return (distanceTo(enemy) < range);
    }

    public float distanceTo(GameObject thing)
    {
        float xa = this.transform.position.x;
        float ya = this.transform.position.y;
        float xb = thing.transform.position.x;       
        float yb = thing.transform.position.y;
        return Mathf.Sqrt(Mathf.Pow(xb-xa, 2) + Mathf.Pow(yb - ya, 2))
    }
}
