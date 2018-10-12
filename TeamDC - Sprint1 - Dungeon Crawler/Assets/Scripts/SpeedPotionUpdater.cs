using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedPotionUpdater : MonoBehaviour {

    public Text speed_potion_count;

    void Awake()
    {
        PlayerInfo.FindObjectOfType<PlayerInfo>().SendMessage("SpeedPotionTotal");
        SetSpeedPotionCount();
    }

    void SetSpeedPotionCount()
    {
        speed_potion_count.text = PlayerInfo.FindObjectOfType<PlayerInfo>().speedpotions + "x";
    }
}
