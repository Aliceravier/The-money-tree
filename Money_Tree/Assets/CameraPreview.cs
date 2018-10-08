using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPreview : MonoBehaviour
{
    // Use this for initialization
    public CameraPreview()
    {
    }

    // Always draw gizmos
    void OnDrawGizmos()
    {
        Camera orthoCam = this.gameObject.GetComponent<Camera>();
        var center = this.transform.position;
        var bounds = new Vector3(orthoCam.orthographicSize * orthoCam.aspect * 2.0f,
            orthoCam.orthographicSize * 2.0f,
            1.0f);

        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(center, bounds);
    }
}
