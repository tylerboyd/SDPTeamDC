//Tarran O'Shaughness hcv3389

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo info;
    public int highscore;
    public int gold;

    void Awake()
    {
        if(info == null)
        {
            DontDestroyOnLoad(gameObject);
            info = this;
        }
        else if(info != this){
            Destroy(gameObject);
        }
    }

    public void Save()//awaiting implementation
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Open(Application.persistentDataPath + "/playerscores.dat", FileMode.Open);

        PlayerData data = new PlayerData();
        data.highscore = highscore;
        data.gold = gold;

        bf.Serialize(fs, data);
        fs.Close();
    }

    public void Load()//awaiting implementation
    {
        if (File.Exists(Application.persistentDataPath + "/playerscores.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.OpenRead(Application.persistentDataPath + "/playerscores.dat");
            PlayerData data = (PlayerData)bf.Deserialize(fs);
            fs.Close();

            highscore = data.highscore;
            gold = data.gold;
        }
    }

    /*void OnGUI()
    {
        GUI.Label(new Rect(10, 5, 200, 50), "Score: " + highscore);
        GUI.Label(new Rect(1380, 5, 200, 50), "Gold: " + gold);
    }*/
}

[System.Serializable]
class PlayerData
{
    public int highscore;
    public int gold;
}