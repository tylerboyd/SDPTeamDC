using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPotionUpdater : MonoBehaviour {

    public Text health_potion_count;

	void Awake ()
    {
        PlayerInfo.FindObjectOfType<PlayerInfo>().SendMessage("HealthPotionTotal");
        SetHealthPotionCount();
    }

    void SetHealthPotionCount()
    {
        health_potion_count.text = PlayerInfo.FindObjectOfType<PlayerInfo>().healthpotions + "x";
    }
}
