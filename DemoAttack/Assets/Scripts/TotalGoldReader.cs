using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalGoldReader : MonoBehaviour {

    public Text TotalGold;
    public int total_gold;

	void Awake () {
        UpdateTotalGold();
        SetTotalGold();
	}

    void SetTotalGold()
    {
        TotalGold.text = "Total Gold: " + total_gold.ToString();
    }

    void UpdateTotalGold()
    {
        total_gold = PlayerInfo.FindObjectOfType<PlayerInfo>().gold;
    }
}
