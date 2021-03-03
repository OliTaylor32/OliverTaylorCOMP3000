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
    // Start is called before the first frame update
    void Start()
    {
        opened = false;
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
        }
        anim.enabled = true;
        StartCoroutine(player.EndInteraction());
    }
}
