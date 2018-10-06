using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Vector2 Size = new Vector2(100.0f, 10.0f);


    Health _health;

    // Use this for initialization
    void Start()
    {
        _health = GetComponent<Health>();
    }
    
    // Update is called once per frame
    void OnGUI()
    {
        GUI.BeginGroup(new Rect(0.0f, 0.0f, Size.x, Size.y));
        {
            GUI.Box(new Rect(0.0f, 0.0f, Size.x, Size.y), "Hello world");
        }
        GUI.EndGroup();
    }
}
