using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContinueDataDisplay : MonoBehaviour
{
    private string location;
    private string gold;
    private string speedlvl;
    private string attacklvl;
    private string boostlvl;

    public SaveControl save;

    // Start is called before the first frame update
    void Start()
    {
        save.Load();
        switch (save.lastArea)
        {
            case 0:
                location = "Solicia1";
                break;
            case 1:
                location = "Solicia2";
                break;
            case 2:
                location = "Solicia3";
                break;
            
            default:
                location = "Unknown";
                break;
        }

        gold = save.gold.ToString();
        speedlvl = save.speedLvl.ToString();
        attacklvl = save.attackLvl.ToString();
        boostlvl = save.boostLvl.ToString();

        GetComponent<TextMeshPro>().text = "Location: " + location + System.Environment.NewLine +
                                           "Gold: " + gold + System.Environment.NewLine +
                                           "Speed Lvl: " + speedlvl + System.Environment.NewLine +
                                           "Attack Lvl: " + attacklvl + System.Environment.NewLine +
                                           "Boost Lvl: " + boostlvl;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
