using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Tarran O'Shaughnessy hcv3389

public class TotalGoldReader : MonoBehaviour {

    public Text TotalGold;
    public int total_gold;

	void Awake () {
        UpdateTotalGold();
        SetTotalGold();
	}

    void SetTotalGold()
    {
        TotalGold.text = ": " + total_gold.ToString();
    }

    void UpdateTotalGold()
    {
        total_gold = PlayerInfo.FindObjectOfType<PlayerInfo>().gold;
    }

    void HealthPurchase()
    {
        if (PlayerInfo.FindObjectOfType<PlayerInfo>().inventory.Count < 3)
        {
            if (total_gold >= 50)
            {
                total_gold = total_gold - 50;
                SetTotalGold();
                PlayerInfo.FindObjectOfType<PlayerInfo>().gold = total_gold;
                PlayerInfo.FindObjectOfType<PlayerInfo>().inventory.Add("Health");
                HealthPotionUpdater.FindObjectOfType<HealthPotionUpdater>().SendMessage("SetHealthPotionCount");
            }
        }
    }

    void SpeedPurchase()
    {
        if (PlayerInfo.FindObjectOfType<PlayerInfo>().inventory.Count < 3)
        {
            if (total_gold >= 50)
            {
                total_gold = total_gold - 50;
                SetTotalGold();
                PlayerInfo.FindObjectOfType<PlayerInfo>().gold = total_gold;
                PlayerInfo.FindObjectOfType<PlayerInfo>().inventory.Add("Speed");
                SpeedPotionUpdater.FindObjectOfType<SpeedPotionUpdater>().SendMessage("SetSpeedPotionCount");
            }
        }
    }
}
