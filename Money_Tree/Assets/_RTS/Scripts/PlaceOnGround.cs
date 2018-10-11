using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceOnGround : MonoBehaviour
{
    // The offset above ground where to move the object to
    public Vector3 Offset = new Vector3(0.0f, 0.1f, 0.0f);

    // Use this for initialization
    void Start()
    {
        RaycastHit groundRayHit;
        var groundRay = new Ray(this.transform.position, Vector3.down);
        if(Physics.Raycast(groundRay, out groundRayHit))
        {
            this.transform.position = groundRayHit.point + Offset;
        }
        else
        {
            Debug.LogError("Failed to raycast to ground!");
        }
    }
}
