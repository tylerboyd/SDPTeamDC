using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        ContinueGame();
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

    public void OpenMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -1);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
