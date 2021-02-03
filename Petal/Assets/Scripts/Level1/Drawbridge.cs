using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawbridge : MonoBehaviour
{
    private Animator anim;
    public Button[] buttons;
    private bool complete;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        complete = false;
        anim = GetComponent<Animator>();
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (complete == false)
        {
            bool passed = true;
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].down == false)
                {
                    passed = false;
                    break;
                }
            }
            if (passed == true)
            {
                anim.enabled = true;
                complete = true;
            }
            if (Time.time - time > 0.1f && Time.time - time < 1f)
            {
                anim.enabled = false;
            }
        }
        
    }
}
