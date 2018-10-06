using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // The GameObject to follow.
    public GameObject TargetEntity;

    // The speed of the camera per fixedupdate.
    public float CameraSpeed = 0.1f;

    // The offset to try and keep vs the TargetEntity's position.
    public Vector3 CameraOffset = new Vector3(10.0f, 10.0f, 10.0f);


    Camera _camera;


    // Use this for initialization
    void Start()
    {
        _camera = GetComponent<Camera>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        var targetPos = TargetEntity.transform.position;
        var curPos = this.transform.position;

        // Try to move towards (target's position + offset) for XZ,
        // and (ground level + offset.y) for Y - so that the camera won't
        // clip into the ground
        var wantedPos = targetPos + CameraOffset;

        RaycastHit downRayHit;
        Ray downRay = new Ray(wantedPos, Vector3.down);
        if(Physics.Raycast(downRay, out downRayHit))
        {
            // Ray hit ground, adjust Y
            wantedPos.y = downRayHit.point.y + CameraOffset.y; 
        }

        this.transform.position = Vector3.MoveTowards(curPos, wantedPos, CameraSpeed);
        this.transform.LookAt(targetPos);
    }
}
