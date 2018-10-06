using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positioning : MonoBehaviour {

    GameObject[] enemies;
    GameObject[] players;


    // Use this for initialization
    void Start () {
        enemies = GameObject.FindGameObjectsWithTag("EnemyUnit");
        players = GameObject.FindGameObjectsWithTag("PlayerUnit");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject FindNearestEnemyUnit()
    {
        if(enemies == null || enemies.Length == 0)
        { 
            // No enemy units
            return null;
        }

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

    public GameObject findNearestPlayerUnit()
    {
        if(players == null || players.Length == 0)
        { 
            // No player units
            return null;
        }

        float minDistance = distanceTo(players[0]);
        GameObject nearestplayer = players[0];
        foreach (GameObject player in players)
        {
            if (distanceTo(player) < minDistance)
            {
                nearestplayer = player;
                minDistance = distanceTo(player);
            }
        }
        return nearestplayer;
    }

    public bool inNearRangeOf(GameObject thing)
    {
        int range = this.gameObject.GetComponent<Hit>().range;
        return thing != null && (distanceTo(thing) < range);
    }

    public bool inFarRangeOf(GameObject thing)
    {
        int range = this.gameObject.GetComponent<Shoot>().range;
        return thing != null && (distanceTo(thing) < range);
    }

    public float distanceTo(GameObject thing)
    {
        float xa = this.transform.position.x;
        float ya = this.transform.position.y;
        float xb = thing.transform.position.x;       
        float yb = thing.transform.position.y;
        return Mathf.Sqrt(Mathf.Pow(xb - xa, 2) + Mathf.Pow(yb - ya, 2));
    }
}
