using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private bool cooldown;
    public GameObject selector;
    public int selected;
    public Transform[] positions;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = false;
        selected = 0;
        selector.transform.position = new Vector3(selector.transform.position.x, selector.transform.position.y, positions[0].position.z);  
    }

    // Update is called once per frame
    void Update()
    {
        selector.transform.position = new Vector3(selector.transform.position.x, selector.transform.position.y, positions[selected].position.z);

        if (Input.GetAxis("Vertical") > 0.1f && cooldown == false)
        {
            if (selected != 0)
            {
                selected--;
                StartCoroutine(CoolDown());
            }
        }

        if (Input.GetAxis("Vertical") < -0.1f && cooldown == false)
        {
            if (selected != positions.Length - 1)
            {
                selected++;
                StartCoroutine(CoolDown());
            }
        }

        if (Input.GetButton("Jump"))
        {
            if (selected == 0)
            {
                Application.LoadLevel("MainGameMenu");
            }

            if (selected == 2)
            {
                Application.LoadLevel("Extras");
            }

            if (selected == 3)
            {
                Application.LoadLevel("Awards");
            }

            if (selected == 4)
            {
                Application.Quit();
            }
        }
    }

    private IEnumerator CoolDown()
    {
        cooldown = true;
        yield return new WaitForSeconds(0.2f);
        cooldown = false;
    }
}
