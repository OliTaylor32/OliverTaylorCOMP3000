using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FetchNPC : MonoBehaviour
{
    public string name;
    public string[] task;
    public string[] thankyou;
    public string[] completeMessage;
    public GameObject textBox;
    public GameObject text;
    public GameObject player;
    public GameObject questItem;
    private bool complete;
    public bool item;
    private bool axisFree;
    private bool started;
    private int i;
    public Money money;
    public int goldAmount;

    public string area;
    public int number;
    public SaveControl save;


    // Start is called before the first frame update
    void Start()
    {
        save.Load();
        if (area == "Solicia")
        {
            switch (number)
            {
                case 1:
                    complete = save.sQuest1;
                    item = save.sQuest1;
                    started = save.sQuest1;
                    break;
                case 2:
                    complete = save.sQuest2;
                    item = save.sQuest2;
                    started = save.sQuest2;
                    break;
                default:
                    break;
            }
        }
        axisFree = true;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (started == true)
        {
            text.SetActive(true);
            textBox.SetActive(true);
            if (complete == false && item == true)
            {
                text.GetComponent<Text>().text = thankyou[i];
                if (Input.GetAxisRaw("Attack") == 1 && axisFree == true)
                {
                    i++;
                    if (i >= thankyou.Length)
                    {
                        money.ChangeMoney(goldAmount);
                        EndInteraction();
                    }
                    axisFree = false;
                }

            }

            if (complete == false && item == false)
            {
                text.GetComponent<Text>().text = task[i];
                if (Input.GetAxisRaw("Attack") == 1 && axisFree == true)
                {
                    i++;
                    if (i >= task.Length)
                    {
                        questItem.SetActive(true);
                        if (questItem.GetComponent<TaskNPC>() != null)
                        {
                            questItem.GetComponent<TaskNPC>().taskStarted = true;
                        }
                        EndInteraction();
                    }
                    axisFree = false;
                }

            }

            if (complete == true)
            {
                text.GetComponent<Text>().text = completeMessage[i];
                if (Input.GetAxisRaw("Attack") == 1 && axisFree == true)
                {
                    i++;
                    if (i >= completeMessage.Length)
                    {
                        EndInteraction();
                    }
                    axisFree = false;
                }

            }
        }
        if (Input.GetAxisRaw("Attack") == 0)
        {
            axisFree = true;
        }
    }


    public void StartInteraction()
    {
        print("Interaction started");
        started = true;
        axisFree = false;
    }

    private void EndInteraction()
    {
        if (item == true)
        {
            complete = true;
            if (area == "Solicia")
            {
                switch (number)
                {
                    case 1:
                        save.sQuest1 = true;
                        break;
                    case 2:
                        save.sQuest2 = true;
                        break;
                    default:
                        break;
                }
            }
            save.Save();
        }

        text.SetActive(false);
        textBox.SetActive(false);
        started = false;
        i = 0;
        StartCoroutine(player.GetComponent<PlayerControl>().EndInteraction());
    }

    public void ItemCollected()
    {
        item = true;
    }
}
