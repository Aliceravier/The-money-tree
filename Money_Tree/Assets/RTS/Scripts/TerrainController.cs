using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{
    // If null, use Camera.main
    public Camera Camera = null;
    
    public string UnitTag = "PlayerUnit";


    // Use this for initialization
    void Start()
    {
        if(this.Camera == null)
        {
            this.Camera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        var clickRay = this.Camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit clickRayHit;
        Physics.Raycast(clickRay, out clickRayHit);

        var units = GameObject.FindGameObjectsWithTag(UnitTag);
        foreach (GameObject unit in units)
        {
            unit.SendMessage("UnitMoveTowards", clickRayHit.point);
        }
    }
}
