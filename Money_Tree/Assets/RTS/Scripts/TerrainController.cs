using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{
    public GameObject CameraObject = null;
    public string UnitTag = "PlayerUnit";

    Camera _camera;


	// Use this for initialization
	void Start()
    {
        _camera = CameraObject.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update()
    {
	}

    void OnMouseDown()
    {
        var clickRay = _camera.ScreenPointToRay(Input.mousePosition);    
        RaycastHit clickRayHit;
        Physics.Raycast(clickRay, out clickRayHit);

        var units = GameObject.FindGameObjectsWithTag(UnitTag);
        foreach(GameObject unit in units)
        {
            unit.SendMessage("UnitMoveTowards", clickRayHit.point);
        }
    }
}
