using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndConditions : MonoBehaviour {
    private GameObject[] getPCount;
    private GameObject[] getECount;
    public static SceneManager marvin;
    // Use this for initialization
    void Start () {
		getPCount = GameObject.FindGameObjectsWithTag("PlayerUnit");
        getECount = GameObject.FindGameObjectsWithTag("EnemyUnit");
        marvin = GetComponent<SceneManager>();
    }
	
	// Update is called once per frame
	void Update () {
        getPCount = GameObject.FindGameObjectsWithTag("PlayerUnit");
        getECount = GameObject.FindGameObjectsWithTag("EnemyUnit");
        if (getPCount.Length < 3)
        {
            SceneManager.LoadScene("yall_dead");
            SceneManager.UnloadScene("RTS");
            Debug.Log("Attempted to load yall dead");
        }
        if (getECount.Length < 3)
        {
            SceneManager.LoadScene("yall_won");
            SceneManager.UnloadScene("RTS");
        }
        Debug.Log("Pcount is " + getPCount.Length);
        Debug.Log("Ecount is " + getECount.Length);
    }
}
