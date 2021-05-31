using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Money money;
    public GameObject backdrop;
    public Text[] costumeTXT;
    public string[] costumeNames;
    public GameObject player;
    private bool axisFree;
    private bool started;
    private bool cooldown;
    public SaveControl save;
    private bool[] purchased;

    private int selected;

    // Start is called before the first frame update
    void Start()
    {
        purchased = new bool[costumeNames.Length];
        purchased[0] = true;
        purchased[1] = save.sCostume1;
        purchased[2] = save.sCostume2;
        cooldown = false;
        selected = 0;
        axisFree = true;
        started = false;
        int currentCostume = save.costume;
        UpdateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (started == true)
        {
            if (Input.GetButton("Attack") && axisFree == true)
            {
                EndInteraction();
            }

            if (Input.GetAxisRaw("Attack") == 0)
            {
                axisFree = true;
            }

            if (Input.GetAxis("Vertical") > 0.1f && cooldown == false)
            {
                if (selected != 0)
                {
                    selected--;
                    StartCoroutine(CoolDown());
                }
            }

            if (Input.GetButton("Jump"))
            {
                if (selected == 0)
                {
                    save.costume = 0;
                    save.Save();
                    costumeTXT[0].text = costumeNames[0] + "   X";
                }

                if (selected == 1)
                {
                    if (purchased[1] == true)
                    {
                        save.costume = 1;
                        save.Save();
                        costumeTXT[1].text = costumeNames[1] + "   X";
                    }
                    if (purchased[1] == false)
                    {
                        if (money.GetMoney() > 249)
                        {
                            money.ChangeMoney(-250);
                            purchased[1] = true;
                            save.costume = 1;
                            save.sCostume1 = true;
                            save.Save();
                            costumeTXT[1].text = costumeNames[1] + "   X";
                        }
                    }
                }

                if (selected == 2)
                {
                    if (purchased[2] == true)
                    {
                        save.costume = 2;
                        save.Save();
                        costumeTXT[2].text = costumeNames[2] + "   X";
                    }
                    if (purchased[2] == false)
                    {
                        if (money.GetMoney() > 249)
                        {
                            money.ChangeMoney(-250);
                            purchased[2] = true;
                            save.costume = 2;
                            save.sCostume1 = true;
                            save.Save();
                            costumeTXT[2].text = costumeNames[2] + "   X";
                        }
                    }
                }
                UpdateDisplay();
                player.GetComponent<PlayerControl>().ChangeCostume();

            }

            if (Input.GetAxis("Vertical") < -0.1f && cooldown == false)
            {
                if (selected != costumeNames.Length - 1)
                {
                    selected++;
                    StartCoroutine(CoolDown());
                }
            }
            for (int i = 0; i < costumeTXT.Length; i++)
            {
                if (i == selected)
                {
                    costumeTXT[i].color = new Color(255, 255, 0);
                }
                else
                {
                    costumeTXT[i].color = new Color(255, 255, 255);
                }

                if (i == save.costume)
                {
                    costumeTXT[i].text = costumeNames[i] + "   X";
                }
            }
        }
    }

    public void StartInteraction()
    {
        print("Interaction started");
        started = true;
        axisFree = false;
        backdrop.SetActive(true);
        for (int i = 0; i < costumeTXT.Length; i++)
        {
            costumeTXT[i].gameObject.SetActive(true);
        }
    }

    private void EndInteraction()
    {
        backdrop.SetActive(false);
        started = false;
        StartCoroutine(player.GetComponent<PlayerControl>().EndInteraction());
        for (int i = 0; i < costumeTXT.Length; i++)
        {
            costumeTXT[i].gameObject.SetActive(false);
        }
    }

    private IEnumerator CoolDown()
    {
        cooldown = true;
        yield return new WaitForSeconds(0.2f);
        cooldown = false;
    }

    private void UpdateDisplay()
    {
        int currentCostume = save.costume;
        for (int i = 0; i < costumeTXT.Length; i++)
        {
            costumeTXT[i].text = costumeNames[i];

            if (i == currentCostume)
            {
                costumeTXT[i].text = costumeNames[i] + "   X";
            }
            if (purchased[i] == false)
            {
                costumeTXT[i].text = costumeNames[i] + "  250G";
            }
        }
    }
}
