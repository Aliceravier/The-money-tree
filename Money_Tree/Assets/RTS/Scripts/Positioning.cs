using System.Collections;
using System.Collections.Generic;
using System;
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


    protected class DistanceComparer : IComparer
    {
        Positioning _parent;

        public DistanceComparer(Positioning parent)
        {
            _parent = parent;
        }

        int IComparer.Compare(object xObj, object yObj)
        {
            var x = (GameObject)xObj;
            var y = (GameObject)yObj;
            
            float xDist = _parent.DistanceTo(x);
            float yDist = _parent.DistanceTo(y);
            if(xDist > yDist)
            {
                return 1;
            }
            else if(yDist > xDist)
            {
                return -1
            }
            else
            {
                return 0;
            }
        }
    }

    // Finds the GameObjects tagged tag, ranked by distance to self
    public GameObject[] FindAllTaggedByDistance(string tag)
    {
        var entities = GameObject.FindGameObjectsWithTag(tag);
        if(entities == null || entities.Length == 0)
        {
            return null;
        }

        var comparer = new DistanceComparer(this);
        Array.Sort(entities, comparer);
        return entities;
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
