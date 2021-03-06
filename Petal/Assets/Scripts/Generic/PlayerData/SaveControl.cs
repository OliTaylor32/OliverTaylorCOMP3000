﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveControl : MonoBehaviour
{
    //Player Data
    public int gold = 0;
    public int speedXP = 0;
    public int attackXP = 0;
    public int boostXP = 0;
    public int lastArea = 0; //0-Solicia, 1-Solicia2, 2-Solicia3
    public int speedLvl = 0;
    public int attackLvl = 0;
    public int boostLvl = 0;
    public int headwear = 0;
    public int costume = 0;
    public int gloves = 0;
    public int shoes = 0;

    //Solicia Data
    public int solicia1 = 0; //0-not completed, 1-C, 2-B, 3-A
    public int solicia2 = -1; //-1 not unlocked, 0-not completed, 1-C, 2-B, 3-A
    public bool sQuest1 = false; //Talking to veg seller
    public bool sQuest2 = false; //Finding the Wallet
    public bool sChest1 = false;
    public bool sChest2 = false;
    public bool sChest3 = false;
    public bool sChest4 = false;


    // Start is called before the first frame update
    void Start()
    {
        //Save(); //Use to reset game to default value
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        print("Saved");
        string dest = Application.persistentDataPath + "/mainsave.dat";
        FileStream file;

        if (File.Exists(dest)) 
        {
            file = File.OpenWrite(dest);
        }
        else
        {
            file = File.Create(dest);
        }

        MainGameData savedata = new MainGameData(gold, speedXP, attackXP, boostXP, lastArea, speedLvl, attackLvl, boostLvl, headwear, costume, gloves, shoes, 
            solicia1, solicia2, sQuest1, sQuest2, sChest1, sChest2, sChest3, sChest4);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(file, savedata);
        file.Close();
    }

    public void Load()
    {
        print("Loaded");
        string dest = Application.persistentDataPath + "/mainsave.dat";
        FileStream file;

        if (File.Exists(dest))
        {
            file = File.OpenRead(dest);

            BinaryFormatter formatter = new BinaryFormatter();
            MainGameData savedata = (MainGameData)formatter.Deserialize(file);
            file.Close();

            gold = savedata.gold;
            speedXP = savedata.speedXP;
            attackXP = savedata.attackXP;
            boostXP = savedata.boostXP;
            lastArea = savedata.lastArea;
            speedLvl = savedata.speedLvl;
            attackLvl = savedata.attackLvl;
            boostLvl = savedata.boostLvl;
            headwear = savedata.headwear;
            costume = savedata.costume;
            gloves = savedata.gloves;
            shoes = savedata.shoes;

            solicia1 = savedata.solicia1;
            solicia2 = savedata.solicia2;
            sQuest1 = savedata.sQuest1;
            sQuest2 = savedata.sQuest2;
            sChest1 = savedata.sChest1;
            sChest2 = savedata.sChest2;
            sChest3 = savedata.sChest3;
            sChest4 = savedata.sChest4;

        }
        else
        {
            print("No Save Data Found");
        }
    }

    public void GetArea()
    {
        lastArea = 0;
        switch (SceneManager.GetActiveScene().name)
        {
            case "Solicia":
                lastArea = 0;
                break;
            case "Solicia2":
                lastArea = 1;
                break;
            default:
                lastArea = 0;
                break;
        }
    }

    public void ResetData()
    {
        int gold = 0;
        int speedXP = 0;
        int attackXP = 0;
        int boostXP = 0;
        int lastArea = 0; //0-Solicia, 1-Solicia2, 2-Solicia3
        int speedLvl = 0;
        int attackLvl = 0;
        int boostLvl = 0;
        int headwear = 0;
        int costume = 0;
        int gloves = 0;
        int shoes = 0;

        //Solicia Data
        int solicia1 = 0; //0-not completed, 1-C, 2-B, 3-A
        int solicia2 = -1; //-1 not unlocked, 0-not completed, 1-C, 2-B, 3-A
        bool sQuest1 = false; //Talking to veg seller
        bool sQuest2 = false; //Finding the Wallet
        bool sChest1 = false;
        bool sChest2 = false;
        bool sChest3 = false;
        bool sChest4 = false;
        Save();
    }
}
