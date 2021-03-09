using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private bool opened;
    public bool gold;
    public int amount;
    public string item;
    private Animator anim;
    public Money money;
    public PlayerControl player;
    public SaveControl save;
    public string area;
    public int number;
    // Start is called before the first frame update
    void Start()
    {
        save.Load();
        if (area == "Solicia" )
        {
            switch (number)
            {
                case 1:
                    opened = save.sChest1;
                    break;
                case 2:
                    opened = save.sChest2;
                    break;
                case 3:
                    opened = save.sChest3;
                    break;
                case 4:
                    opened = save.sChest4;
                    break;
                default:
                    break;
            }
        }
        anim = GetComponent<Animator>();
        if (opened == true)
        {
            anim.enabled = true;
        }
        else
        {
            anim.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartInteraction()
    {
        if (gold == true && opened == false)
        {
            money.ChangeMoney(amount);
            opened = true;
            if (area == "Solicia")
            {
                switch (number)
                {
                    case 1:
                        save.sChest1 = true;
                        break;
                    case 2:
                        save.sChest2 = true;
                        break;
                    case 3:
                        save.sChest3 = true;
                        break;
                    case 4:
                        save.sChest4 = true;
                        break;
                    default:
                        break;
                }
            }
            save.Save();
        }
        anim.enabled = true;
        StartCoroutine(player.EndInteraction());
    }
}
