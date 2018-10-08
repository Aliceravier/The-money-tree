using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    // The camera to face towards. If null, uses Camera.main
    public Camera Camera = null; 

    Quaternion _baseRotation;

    // Use this for initialization
    void Start()
    {
        if(this.Camera == null)
        {
            this.Camera = Camera.main;
        }

        _baseRotation = this.transform.rotation;
    }
    
    // Update is called once per frame when `Update()`s are done
    void LateUpdate()
    {
        this.transform.rotation = _baseRotation
                                  * Camera.transform.rotation;
    }
}
