using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Running,
    Pause
}

public class GameStateManager : MonoBehaviour {
    public static GameStateManager _instance;

    public GameState gameState = GameState.Running;

    private void Awake()
    {
        _instance = this;
    }


    // Update is called once per frame
    void Update () {
		
	}

    public void ChangeGameState()
    {
        if(gameState == GameState.Running)
        {
            GamePause();
        }
        else if(gameState == GameState.Pause)
        {
            ContinueGame();
        }
    }

    public void GamePause()
    {
        Time.timeScale = 0;
        gameState = GameState.Pause;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        gameState = GameState.Running;
    }



}
