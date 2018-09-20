//Tarran O'Shaughness hcv3389

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

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
        score = score + 1;
        SetScoreText();
    }

    void SetGoldText()
    {
        GoldText.text = "Gold: " + gold.ToString();
    }

    void AddGold()
    {
        gold = gold + 1;
        SetGoldText();
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 100, 100, 30), "Score up"))
        {
            AddScore();
        }
        if (GUI.Button(new Rect(10, 140, 100, 30), "Gold up"))
        {
            AddGold();
        }
    }

    /*void OnCompletion()
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
    }*/

}
