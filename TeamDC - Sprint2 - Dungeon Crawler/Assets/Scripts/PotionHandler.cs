using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Tarran O'Shaughnessy hcv3389

public class PotionHandler : MonoBehaviour {

    public float SpeedBoostTimer = 1;
    float timer;
    public GameObject healthpotion;
    public GameObject speedpotion;
    private readonly int hPotionHealAmount = 70;


    void Update()
    {
        if (PlayerInfo.FindObjectOfType<PlayerInfo>().healthpotions == 0)
        {
            healthpotion.SetActive(false);
        }
        else if (PlayerInfo.FindObjectOfType<PlayerInfo>().healthpotions > 0)
        {
            healthpotion.SetActive(true);
        }
        if (PlayerInfo.FindObjectOfType<PlayerInfo>().speedpotions == 0)
        {
            speedpotion.SetActive(false);
        }
        else if (PlayerInfo.FindObjectOfType<PlayerInfo>().healthpotions > 0)
        {
            speedpotion.SetActive(true);
        }
    }

	void HealthPotionUsed()
    {
        GameObject.FindGameObjectWithTag("Hero").GetComponent<HealthSystem>().Heal(hPotionHealAmount);
        PlayerInfo.FindObjectOfType<PlayerInfo>().SendMessage("RemoveHealthPotion");

        if (PlayerInfo.FindObjectOfType<PlayerInfo>().healthpotions == 0)
        {
            healthpotion.SetActive(false);
        }
	}

    void SpeedPotionUsed()
    {
        StartCoroutine(SpeedTimer());     
        PlayerInfo.FindObjectOfType<PlayerInfo>().SendMessage("RemoveSpeedPotion");

        if(PlayerInfo.FindObjectOfType<PlayerInfo>().speedpotions == 0)
        {
            speedpotion.SetActive(false);
        }
    }

    IEnumerator SpeedTimer()
    {
        PlayerMovement.FindObjectOfType<PlayerMovement>().speed = 14;
        yield return new WaitForSeconds(5);
        PlayerMovement.FindObjectOfType<PlayerMovement>().speed = 7;
    }
}
