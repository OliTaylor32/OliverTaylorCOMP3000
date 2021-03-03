using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    private int money;
    public Text display;
    // Start is called before the first frame update
    void Start()
    {
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

    public void ChangeMoney(int amount)
    {
        money = money + amount;
        UpdateDisplay();
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
    }
}
