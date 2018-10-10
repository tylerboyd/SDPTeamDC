//Tarran O'Shaughness hcv3389

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

    public int Gold_Test(int gold, int gold_increment)
    {
        gold += gold_increment;

        return gold;
    }

    public int Score_Test(int score, int score_increment)
    {
        score += score_increment;

        return score;
    }

	void Awake () {
        gold = 0;
        score = 0;
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

    /*void OnGUI()for testing
    {
        if (GUI.Button(new Rect(10, 100, 100, 30), "Score up"))
        {
            AddScore();
        }
        if (GUI.Button(new Rect(10, 140, 100, 30), "Gold up"))
        {
            AddGold();
        }*/
    }

   /* void OnCompletion()
    {
        if//user is defeated
        {
            PlayerInfo.info.gold = PlayerInfo.info.gold + gold;
            if (PlayerInfo.info.highscore < score)
            {
                PlayerInfo.info.highscore = score;
                PlayerInfo.info.Save();
            }
            PlayerInfo.info.Save();
        }
    }
}*/
