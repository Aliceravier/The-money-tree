using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashMoney : MonoBehaviour {
    public Text cash;
    // Use this for initialization
    void Start () {
        cash = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Clickable_Tree.treeSize < 1500)
        {
            cash.text = "Money: " + MakeItRain.money.ToString();
        }
        else
        {
            cash.text = "CONSUME";
        }
    }
}
