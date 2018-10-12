//Tarran O'Shaughness hcv3389

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

    public GameObject playerscores;
    
    public Text scoreText;
    public Text goldText;
    public Text deathScore;
    public Text deathGold;
    public int score;
    public int gold;

	void Awake () {
        SetScoreText();
        SetGoldText();
        SetDeathGoldText();
        SetDeathScoreText();
	}
	
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void SetDeathScoreText()
    {
        deathScore.text = "Score: " + score.ToString();
    }

    void AddScore()
    {
        score = score + 200;
        SetScoreText();
        SetDeathScoreText();
    }

    public int AddScore_Test(int score)
    {
        score = score + 200;
        return score;
    }

    void SetGoldText()
    {
        goldText.text = ": " + gold.ToString();
    }

    void SetDeathGoldText()
    {
        deathGold.text = ": " + gold.ToString();
    }

    void AddGold()
    {
        gold = gold + 20;
        SetGoldText();
        SetDeathGoldText();
    }

    public int AddGold_Test(int gold)
    {
        gold = gold + 20;
        return gold;
    }

    void OnCompletion()
    {
        PlayerInfo.FindObjectOfType<PlayerInfo>().gold = PlayerInfo.FindObjectOfType<PlayerInfo>().gold + gold;
        if (PlayerInfo.FindObjectOfType<PlayerInfo>().highscore < score)
        {
            PlayerInfo.FindObjectOfType<PlayerInfo>().highscore = score;
            PlayerInfo.FindObjectOfType<PlayerInfo>().SendMessage("Save");
        }
        PlayerInfo.FindObjectOfType<PlayerInfo>().SendMessage("Save");
        Debug.LogFormat(PlayerInfo.FindObjectOfType<PlayerInfo>().highscore + "total score");
    }
}
