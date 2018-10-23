//Tarran O'Shaughnessy hcv3389

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerInfo : MonoBehaviour
{
    public PlayerInfo info;
    public int highscore;
    public int gold;
    public int healthpotions;
    public int speedpotions;
    public ArrayList inventory = new ArrayList();

    void Awake()
    {
        if (info == null)
        {
            DontDestroyOnLoad(gameObject);
            info = this;
        }
        else if (info != this)
        {
            Destroy(gameObject);
        }
    }

    void HealthPotionTotal()
    {
        healthpotions = healthpotions - healthpotions;
        for (int i = 0; i < 3; i++)
        {
            if (inventory[i] == "Health")
            {
                healthpotions = healthpotions + 1;
            }
        }
    }

    void RemoveHealthPotion()
    {
        for(int i = 0; i < 3; i++)
        {
            if(inventory[i] == "Health")
            {
                inventory.RemoveAt(i);
                healthpotions = healthpotions - 1;
                i = 3;
            }
        }
        HealthPotionUpdater.FindObjectOfType<HealthPotionUpdater>().SendMessage("SetHealthPotionCount");
    }

    void SpeedPotionTotal()
    {
        speedpotions = speedpotions - speedpotions;
        for (int i = 0; i < 3; i++)
        {
            if (inventory[i] == "Speed")
            {
                speedpotions = speedpotions + 1;
            }
        }
    }

    void RemoveSpeedPotion()
    {
        for (int i = 0; i < 3; i++)
        {
            if (inventory[i] == "Speed")
            {
                inventory.RemoveAt(i);
                speedpotions = speedpotions - 1;
                i = 3;
            }
        }
        SpeedPotionUpdater.FindObjectOfType<SpeedPotionUpdater>().SendMessage("SetSpeedPotionCount");
    }

    public void Save()//awaiting implementation
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Open(Application.persistentDataPath + "/playerscores.dat", FileMode.Open);

        PlayerData data = new PlayerData();
        data.highscore = highscore;
        data.gold = gold;
        data.healthpotions = healthpotions;
        data.speedpotions = speedpotions;

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
            healthpotions = data.healthpotions;
            speedpotions = data.speedpotions;
        }
    }
}

[System.Serializable]
class PlayerData
{
    public int highscore;
    public int gold;
    public int healthpotions;
    public int speedpotions;
}