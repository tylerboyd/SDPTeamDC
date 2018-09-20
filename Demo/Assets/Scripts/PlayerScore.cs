using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{

    private int count;
    public Text countText;

    void Start()
    {
        count = 0;
        SetCountText();
    }

    void OnTriggerEnter(Collider Enemy)
    {
        if (Enemy.gameObject.CompareTag("Enemy 1"))
        {
            Enemy.gameObject.SetActive(false);
            //Enemy.gameObject.Destroy();
            count = count + 1;
            SetCountText();
        }
    }

    void AddScore()
    {
        count = count + 1;
        SetCountText();
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
    }
}
