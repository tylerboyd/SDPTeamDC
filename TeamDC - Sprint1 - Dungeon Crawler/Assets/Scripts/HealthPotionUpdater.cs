using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Tarran O'Shaughnessy hcv3389

public class HealthPotionUpdater : MonoBehaviour {

    public Text health_potion_count;

	void Awake ()
    {
        SetHealthPotionCount();
    }

    void SetHealthPotionCount()
    {
        PlayerInfo.FindObjectOfType<PlayerInfo>().SendMessage("HealthPotionTotal");
        health_potion_count.text = PlayerInfo.FindObjectOfType<PlayerInfo>().healthpotions + "x";
    }
}
