using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelector : MonoBehaviour
{
    // The camera to use for raycasting to the scene
    public Camera Camera = null;

    // The current selection
    public HashSet<GameObject> Selection
    {
        get
        {
            return _selection;
        }
    }

    // The tag that selectable objects need
    public string SelectableTag = "PlayerEntity";

    HashSet<GameObject> _selection = new HashSet<GameObject>();

    void Start()
    {
    }

    void Update()
    {
        if(Input.GetAxis("SelectAll") > 0.0f)
        {
            _selection.Clear();
            var entities = GameObject.FindGameObjectsWithTag(SelectableTag);
            foreach(GameObject entity in entities)
            {
                _selection.Add(entity);
            }
        }
    }
}
