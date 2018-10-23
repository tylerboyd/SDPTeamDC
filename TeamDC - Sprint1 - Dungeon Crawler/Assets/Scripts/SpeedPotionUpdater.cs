using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Tarran O'Shaughnessy hcv3389

public class SpeedPotionUpdater : MonoBehaviour {

    public Text speed_potion_count;

    void Awake ()
    {
        SetSpeedPotionCount();
    }

    void SetSpeedPotionCount()
    {
        PlayerInfo.FindObjectOfType<PlayerInfo>().SendMessage("SpeedPotionTotal");
        speed_potion_count.text = PlayerInfo.FindObjectOfType<PlayerInfo>().speedpotions + "x";
    }
}
