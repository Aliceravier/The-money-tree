using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positioning : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }
	
	// Update is called once per frame
	void Update()
    {
	}

    // Returns the distance inbetween this and the given entity
    public float DistanceTo(GameObject entity)
    {
        return (this.transform.position - entity.transform.position).magnitude;
    }

    // Finds the nearest GameObject tagged tag, or null if none was found
    public GameObject FindNearestTagged(string tag)
    {
        var entities = GameObject.FindGameObjectsWithTag(tag);
        if(entities == null || entities.Length == 0)
        {
            return null;
        }

        GameObject nearestEntity = null;
        float minDistance = float.MaxValue; // (Always bigger than any real distance)
        foreach(GameObject entity in entities)
        {
            var distance = DistanceTo(entity);
            if(distance < minDistance)
            {
                nearestEntity = entity;
                minDistance = distance;
            }
        }
        return nearestEntity;
    }
}
