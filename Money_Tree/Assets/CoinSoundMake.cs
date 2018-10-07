using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinSoundMake : MonoBehaviour {
    private static AudioSource source;
    public static SceneManager marvin;
    public static int timer; //This is for the hidden win condition
    int lastTreeVal;
    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
        marvin = GetComponent<SceneManager>();
        timer = 0;
        lastTreeVal = Clickable_Tree.treeSize;
    }

    public static void MakeCoinSound()
    {
        source.Play();
    }
	
	// Update is called once per frame
	void Update () {
        timer++;
        if (lastTreeVal != Clickable_Tree.treeSize)
        {
            timer = 0;
        }
        lastTreeVal = Clickable_Tree.treeSize;
        if (timer > 2000)
        {
            SceneManager.LoadScene("Life_Goes_On");
            SceneManager.UnloadScene("PartOne");
        }
        Debug.Log("Timer is " + timer);
    }
}
