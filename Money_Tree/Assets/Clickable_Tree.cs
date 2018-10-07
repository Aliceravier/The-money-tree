using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Clickable_Tree : MonoBehaviour
{
    public static SceneManager marvin;
    public static int treeSize;
    public Text size;

    // Use this for initialization
    void Start()
    {
        size = GetComponent<Text>();
        treeSize = 0;
        marvin = GetComponent<SceneManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (treeSize < 100)
        {
            size.text = "Progress to Next Stage: " + treeSize.ToString() + "%";
        }
        else if (treeSize < 500)
        {
            size.text = "Progress to Next Stage: " + ((treeSize - 100)/4).ToString() + "%";
        }
        else if (treeSize < 800)
        {
            size.text = "Progress to Next Stage: " + ((treeSize - 500) / 3).ToString() + "%";
        }
        else if (treeSize < 1500)
        {
            size.text = "Progress to Next Stage: " + ((treeSize - 800) / 7).ToString() + "%";
        }
        else
        {
            size.text = "CONSUME";
            SceneManager.LoadScene("RTS");
            SceneManager.UnloadScene("PartOne");
        }
    }
}
