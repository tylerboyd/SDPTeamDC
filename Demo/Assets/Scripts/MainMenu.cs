using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Tyler Boyd: 16951977

public class MainMenu : MonoBehaviour {

    //Loads the Game Scene
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Prints QUIT to Console 
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}


