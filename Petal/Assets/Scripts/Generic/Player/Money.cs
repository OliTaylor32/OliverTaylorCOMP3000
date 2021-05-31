using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    private int money;
    public Text display;
    public Text xpDisplay;
    public SaveControl saveControl;
    private int xp;
    // Start is called before the first frame update
    void Start()
    {
        saveControl.Load();
        money = saveControl.gold;
        xp = saveControl.xp;
        UpdateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetMoney()
    {
        return money;
    }

    public int GetXP()
    {
        return xp;
    }

    public void ChangeMoney(int amount)
    {
        money = money + amount;
        UpdateDisplay();
        saveControl.gold = money;
        saveControl.Save();
    }

    public void ChangeXP(int amount)
    {
        money = money + amount;
        UpdateDisplay();
        saveControl.xp = xp;
        saveControl.Save();
    }

    private void UpdateDisplay()
    {
        if (money == 0)
        {
            display.text = "000000G";
        }
        else if (money < 100)
        {
            display.text = "0000" + money.ToString() + "G";
        }
        else if (money < 1000)
        {
            display.text = "000" + money.ToString() + "G";
        }
        else if (money < 10000)
        {
            display.text = "00" + money.ToString() + "G";
        }
        else if (money < 100000)
        {
            display.text = "0" + money.ToString() + "G";
        }
        else
        {
            display.text = money.ToString() + "G";
        }

        if (xp == 0)
        {
            xpDisplay.text = "000000XP";
        }
        else if (xp < 100)
        {
            xpDisplay.text = "0000" + xp.ToString() + "XP";
        }
        else if (xp < 1000)
        {
            xpDisplay.text = "000" + xp.ToString() + "XP";
        }
        else if (xp < 10000)
        {
            xpDisplay.text = "00" + xp.ToString() + "XP";
        }
        else if (xp < 100000)
        {
            xpDisplay.text = "0" + xp.ToString() + "XP";
        }
        else
        {
            xpDisplay.text = xp.ToString() + "XP";
        }
    }
}
