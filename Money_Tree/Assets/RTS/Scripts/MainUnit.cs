using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUnit : MonoBehaviour
{
    // The range to restrict friendly units to
    public float LeechingRange = 10.0f;


    // Draw leeching range
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(this.transform.position, this.LeechingRange);
    }

    // Use this for initialization
    void Start()
    {
    }
    
    // Update is called once per frame
    void Update()
    {
    }
}
