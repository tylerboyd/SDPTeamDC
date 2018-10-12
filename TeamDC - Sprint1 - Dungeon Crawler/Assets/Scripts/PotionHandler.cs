using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionHandler : MonoBehaviour {

    public float SpeedBoostTimer = 5;
    float timer;
    public Button button;
    public GameObject healthpotion;
    public GameObject speedpotion;

    void Update()
    {

    }

	void HealthPotionUsed()
    {
        HealthSystem.FindObjectOfType<HealthSystem>().Heal(70);
        PlayerInfo.FindObjectOfType<PlayerInfo>().SendMessage("RemoveHealthPotion");


        if(PlayerInfo.FindObjectOfType<PlayerInfo>().healthpotions == 0)
        {
            healthpotion.SetActive(false);
        }
	}

    void SpeedPotionUsed()
    {    
        timer += Time.deltaTime;
        PlayerMovement.FindObjectOfType<PlayerMovement>().speed = 14;
        if (timer == SpeedBoostTimer)
        {
            PlayerMovement.FindObjectOfType<PlayerMovement>().speed = 7;
        }        
        PlayerInfo.FindObjectOfType<PlayerInfo>().SendMessage("RemoveSpeedPotion");

        if(PlayerInfo.FindObjectOfType<PlayerInfo>().speedpotions == 0)
        {
            speedpotion.SetActive(false);
        }
    }
}
