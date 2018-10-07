using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeGruntNoise : MonoBehaviour {
    public static AudioSource source;
    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
    }
	
    public static void someoneDied()
    {
        source.Play();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
