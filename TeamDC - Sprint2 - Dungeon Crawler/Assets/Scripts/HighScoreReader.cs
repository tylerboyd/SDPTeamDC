using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreReader : MonoBehaviour {

    public Text HighScore;
    public int highscore;

	void Awake () {
        UpdateHighScore();
        SetHighScore();
	}
	
	void SetHighScore()
    {
        HighScore.text = "High Score: " + highscore;
    }

    void UpdateHighScore()
    {
        highscore = PlayerInfo.FindObjectOfType<PlayerInfo>().highscore;
    }
}
