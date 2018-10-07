using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyCapitalism : MonoBehaviour {
    public static SceneManager marvin;
    // Use this for initialization
    void Start () {
        //marvin = GetComponent<SceneManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        if (MakeItRain.money >= 1000000)
        {
            SceneManager.LoadScene("You_Win!");
            SceneManager.UnloadScene("PartOne");
        }
    }
}
