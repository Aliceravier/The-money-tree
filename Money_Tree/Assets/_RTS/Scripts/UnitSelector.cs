using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelector : MonoBehaviour
{
    // The camera to use for raycasting to the scene
    public Camera Camera = null;

    // The tag that selectable objects need
    public string SelectableTag = "PlayerUnit";

    void Start()
    {
    }

    void Update()
    {
        if(Input.GetAxis("SelectAll") > 0.0f)
        {
            var entities = GameObject.FindGameObjectsWithTag(SelectableTag);
            if(entities == null || entities.Length == 0)
            {
                // No selectable units
                return;
            }

            foreach(GameObject entity in entities)
            {
                var selectable = entity.GetComponent<Selectable>();
                if(selectable != null)
                {
                    selectable.Select();
                }
            }
        }
    }

    void MouseDown()
    {
    }
}
