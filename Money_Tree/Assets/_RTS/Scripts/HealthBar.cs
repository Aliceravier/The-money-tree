using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Health _health; // (of the PARENT gameobject)
    TextMesh _textMesh;

    // Use this for initialization
    void Start()
    {
        _health = this.transform.parent.GetComponent<Health>();
        _textMesh = this.GetComponent<TextMesh>();
    }

    void Update()
    {
        _textMesh.text = _health.HP + "/" + _health.MaxHP;
    }
}
