using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelector : MonoBehaviour
{
    // The camera to use for raycasting to the scene
    public Camera Camera = null;

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

    public float BoxDepth = 100.0f;


    HashSet<GameObject> _selection = new HashSet<GameObject>();
    bool _selecting = false;
    Vector2 _selectionStartPos = Vector2.zero; // (pixels)
    Vector2 _selectionEndPos = Vector2.zero; // (pixels)


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
        bool mouseDown = Input.GetMouseButtonDown(MouseButton);
        bool mouseUp = Input.GetMouseButtonUp(MouseButton);
        {
            RaycastHit clickRayHit;
            var clickRay = Camera.ScreenPointToRay(Input.mousePosition);
            //Debug.DrawRay(clickRay.origin, clickRay.direction);
            if(!Physics.Raycast(clickRay, out clickRayHit))
            {
                // No hit
                return;
            }

            var resolution = new Vector2(Screen.width, Screen.height);
            var clickPos = Input.mousePosition;
            if(mouseDown && !_selecting)
            {
                // Selection started; set start point
                _selectionStartPos = clickPos;
                _selecting = true;
            }
            else if(mouseUp && _selecting)
            {
                // Selection end, recalculate selection 
                _selectionEndPos = clickPos;
                _selecting = false;

                UpdateBoxSelection();
            }

           
        }
    }

    // Updates the box collider to match the user's selection
    // WARNING: This will move the object to the center of the selection!
    void UpdateBoxSelection()
    {
        Debug.Log("Update box selection");

        _selection.Clear();

        if(gameObject.GetComponent<BoxCollider>())
        {
            // Need to remove old colliders to update their size
            Object.Destroy(gameObject.GetComponent<BoxCollider>());
        }

        var boxStartWorld = Camera.ScreenToWorldPoint(_selectionStartPos);
        var boxEndWorld = Camera.ScreenToWorldPoint(_selectionEndPos);
        var boxExtents = Abs(boxStartWorld - boxEndWorld);
        boxExtents.y = BoxDepth;

        var boxCenterWorld = (boxStartWorld + boxEndWorld) / 2.0f;
        var boxCenterLocal = this.transform.InverseTransformPoint(boxCenterWorld);

        var box = gameObject.AddComponent<BoxCollider>();
        box.transform.position = boxCenterLocal;
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
