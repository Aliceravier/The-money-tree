using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSoundMake : MonoBehaviour {
    private static AudioSource source;
    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
    }

    public static void MakeCoinSound()
    {
        source.Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
