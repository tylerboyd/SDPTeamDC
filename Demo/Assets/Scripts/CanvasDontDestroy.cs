using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasDontDestroy : MonoBehaviour {

    public static GameObject rootCanvas;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
