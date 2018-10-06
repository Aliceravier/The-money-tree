using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelector : MonoBehaviour
{
    // The camera to use for raycasting to the scene
    public Camera camera = null;

    // The currently= selection
    public HashSet<GameObject> Selection
    {
        get
        {
            return _selection;
        }
    }

    // The mouse button used to trigger the box selection
    public int MouseButton = 1;


    HashSet<GameObject> _selection = new HashSet<GameObject>();
    bool _selecting = false;
    Vector3 _selectionStart = Vector2.zero, _selectionEnd = Vector2.zero;


    // Use this for initialization
    void Start()
    {
        _selecting = false;
    }


    // Returns the vector with the absolute values of vector's X, Y, Z
    Vector3 Abs(Vector3 vector)
    {
        return new Vector3(Mathf.Abs(vector.x),
                           Mathf.Abs(vector.y),
                           Mathf.Abs(vector.z));
    }


    // LateUpdate is called once per frame after Update
    void LateUpdate()
    {
        if(Input.GetMouseButton(MouseButton))
        {
            if(!_selecting)
            {
                // Selection started; set start point
                var clickRay = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit clickRayHit;
                Debug.DrawRay(clickRay.origin, clickRay.direction);
                if(Physics.Raycast(clickRay, out clickRayHit))
                {
                    _selectionStart = clickRayHit.point;
                    _selecting = true;
                }
            }
            else
            {
                // Selection end; set endpoint
                var clickRay = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit clickRayHit;
                Debug.DrawRay(clickRay.origin, clickRay.direction);
                if(Physics.Raycast(clickRay, out clickRayHit))
                {
                    _selectionEnd = clickRayHit.point;
                    _selecting = false;

                    // Recalculate selection 
                    UpdateBoxSelection();
                }
            }
        }
    }

    // Updates the box collider to match the user's selection
    // WARNING: This will move the object to the center of the selection!
    void UpdateBoxSelection()
    {
        Debug.Log("Update box selection: "
                  + _selectionStart + " to " + _selectionEnd);

        _selection.Clear();

        if(gameObject.GetComponent<BoxCollider>())
        {
            // Need to remove old colliders to update their size
            Object.Destroy(gameObject.GetComponent<BoxCollider>());
        }

        var boxCenter = (_selectionStart + _selectionEnd) / 2.0f; // (world space)
        var boxExtents = Abs(_selectionEnd - _selectionStart); // (world space)

        this.transform.position = boxCenter;

        var box = gameObject.AddComponent<BoxCollider>();
        box.transform.position = Vector2.zero; // (local space)
        box.size = boxExtents;
        box.isTrigger = true; // IMPORTANT!
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Box selected: " + other);
        _selection.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Box deselected: " + other);
        _selection.Remove(other.gameObject);
    }

}
