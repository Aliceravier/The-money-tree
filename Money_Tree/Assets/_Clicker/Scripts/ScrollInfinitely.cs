using UnityEngine;
using System.Collections;

public class ScrollInfinitely : MonoBehaviour
{
    public float scrollSpeed;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        scrollSpeed = 5f;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, 1);
        transform.position = startPosition + Vector3.forward * newPosition;
    }
}