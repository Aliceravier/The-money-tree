using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // The percentage width/height of the screen that will trigger a camera movement.
    public float MouseTriggerZone = 0.1f;

    // The speed of the camera per fixedupdate.
    public float CameraSpeed = 0.1f;

    Camera _camera;


    // Use this for initialization
    void Start()
    {
        _camera = GetComponent<Camera>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        var mousePos = Input.mousePosition;

        // Mouse X and Y in UV coordinates
        var mouseUV = _camera.ScreenToViewportPoint(mousePos);

        // Move the camera when the cursor nears the edges
        var posDelta = Vector3.zero;
        if(mouseUV.x < MouseTriggerZone)
        {
            posDelta.x -= CameraSpeed;
        }
        else if(mouseUV.x > (1.0f - MouseTriggerZone))
        {
            posDelta.x += CameraSpeed;
        }
        if(mouseUV.y < MouseTriggerZone)
        {
            posDelta.y -= CameraSpeed;
        }
        else if(mouseUV.y > (1.0f - MouseTriggerZone))
        {
            posDelta.y += CameraSpeed;
        }

        this.transform.Translate(posDelta);
    }

    void OnMouseDown()
    {
    }
}
