//Tarran O'Shaughnessy hcv3389

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

    public GameObject playerscores;
    
    public Text ScoreText;
    public Text GoldText;
    public int score;
    public int gold;

	void Awake () {
        SetScoreText();
        SetGoldText();
	}
	
    void SetScoreText()
    {
        ScoreText.text = "Score: " + score.ToString();
    }

    void AddScore()
    {
        score = score + 200;
        SetScoreText();
    }

    void SetGoldText()
    {
        GoldText.text = "Gold: " + gold.ToString();
    }

    void AddGold()
    {
        gold = gold + 20;
        SetGoldText();
    }

    void OnCompletion()
    {
        PlayerInfo.FindObjectOfType<PlayerInfo>().gold = PlayerInfo.FindObjectOfType<PlayerInfo>().gold + gold;
        if (PlayerInfo.FindObjectOfType<PlayerInfo>().highscore < score)
        {
            PlayerInfo.FindObjectOfType<PlayerInfo>().highscore= score;
            PlayerInfo.FindObjectOfType<PlayerInfo>().SendMessage("Save");
        }
        PlayerInfo.FindObjectOfType<PlayerInfo>().SendMessage("Save");
        Debug.LogFormat(PlayerInfo.FindObjectOfType<PlayerInfo>().highscore + "total score");
    }
}
