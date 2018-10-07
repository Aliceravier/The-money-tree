using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clickable : MonoBehaviour {
    int treeSize = 0;

    public Text display;
    // Use this for initialization
    void Start () {
        display = GetComponent<Text>();
        
    }

    private void OnMouseDown()
    {
        treeSize++;
    }
    // Update is called once per frame
    void Update () {
        display.text = treeSize.ToString();
	}
}
