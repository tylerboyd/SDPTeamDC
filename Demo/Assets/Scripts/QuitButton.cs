using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour {

    private void OnMouseDown()
    {
        Application.Quit();
    }
}
