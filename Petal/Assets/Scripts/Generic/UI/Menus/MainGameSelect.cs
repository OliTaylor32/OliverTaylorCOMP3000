using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameSelect : MonoBehaviour
{
    public bool newGame;
    public GameObject newGameSelect;
    public GameObject continueSelect;
    // Start is called before the first frame update
    void Start()
    {
        newGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (newGame == true)
        {
            newGameSelect.SetActive(true);
            continueSelect.SetActive(false);
        }
        else
        {
            newGameSelect.SetActive(false);
            continueSelect.SetActive(true);
        }

        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            newGame = true;
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            newGame = false;
        }

        if (Input.GetButtonDown("Attack"))
        {
            Application.LoadLevel("MainMenu");
        }

        if (Input.GetButton("Jump"))
        {
            if (newGame == true)
            {
                Application.LoadLevel("Tutorial");
            }
            else
            {
                //Load save data, load player to hub of last place docked.
            }
        }
    }
}
