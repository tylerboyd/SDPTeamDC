using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButtonHandler : MonoBehaviour
{
    Button button;
    void ButtonDisable()
    {
        if(PlayerInfo.FindObjectOfType<PlayerInfo>().inventory.Count == 2 || PlayerInfo.FindObjectOfType<PlayerInfo>().gold < 50)
        {
            button.gameObject.SetActive(false);
        }
    }
}
