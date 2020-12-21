using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageNPC : MonoBehaviour
{
    public string name;
    public string[] message;
    public string[] altmessage;
    public GameObject textBox;
    public GameObject text;
    public GameObject player;
    public GameObject gate;
    private bool alt;
    private bool axisFree;
    private bool started;
    private int i;
    // Start is called before the first frame update
    void Start()
    {
        alt = false;
        axisFree = true;
        started = false;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (started == true)
        {
            text.SetActive(true);
            textBox.SetActive(true);
            if (alt == false)
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

            if (alt == true)
            {
                text.GetComponent<Text>().text = altmessage[i];
                if (Input.GetAxisRaw("Attack") == 1 && axisFree == true)
                {
                    i++;
                    if (i >= altmessage.Length)
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
        text.SetActive(false);
        textBox.SetActive(false);
        started = false;
        gate.GetComponent<SubGate>().Activate();
        i = 0;
        StartCoroutine(player.GetComponent<PlayerControl>().EndInteraction());
    }
}
