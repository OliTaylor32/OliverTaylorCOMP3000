using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskNPC : MonoBehaviour
{
    public string name;
    public string[] message;
    public string[] task;
    public string[] completeMessage;
    public GameObject textBox;
    public GameObject text;
    public GameObject player;
    public GameObject NPC;
    private bool complete;
    public bool taskStarted;
    private bool axisFree;
    private bool started;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        complete = false;
        axisFree = true;
        started = false;
        taskStarted = false;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (started == true)
        {
            text.SetActive(true);
            textBox.SetActive(true);
            if (complete == false && taskStarted == true)
            {
                text.GetComponent<Text>().text = task[i];
                if (Input.GetAxisRaw("Attack") == 1 && axisFree == true)
                {
                    i++;
                    if (i >= task.Length)
                    {
                        NPC.GetComponent<FetchNPC>().ItemCollected();
                        EndInteraction();
                    }
                    axisFree = false;
                }

            }

            if (complete == false && taskStarted == false)
            {
                text.GetComponent<Text>().text = message[i];
                if (Input.GetAxisRaw("Attack") == 1 && axisFree == true)
                {
                    i++;
                    if (i >= message.Length)
                    {
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
        //if (item == true)
        //{
        //    complete = true;
        //}
        text.SetActive(false);
        textBox.SetActive(false);
        started = false;
        i = 0;
        StartCoroutine(player.GetComponent<PlayerControl>().EndInteraction());

        if (taskStarted == true)
        {
            complete = true;
        }
    }

    //public void ItemCollected()
    //{
    //    item = true;
    //}
}
