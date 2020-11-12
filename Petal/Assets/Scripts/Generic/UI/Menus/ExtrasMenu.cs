using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtrasMenu : MonoBehaviour
{
    private bool cooldown;
    public int selected;
    public GameObject boss;
    public GameObject rally;
    public GameObject gallery;
    public GameObject music;

    // Start is called before the first frame update
    void Start()
    {
        selected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (selected)
        {
            case 0:
                boss.SetActive(true);
                rally.SetActive(false);
                gallery.SetActive(false);
                music.SetActive(false);
                break;
            case 1:
                boss.SetActive(false);
                rally.SetActive(true);
                gallery.SetActive(false);
                music.SetActive(false);
                break;
            case 2:
                boss.SetActive(false);
                rally.SetActive(false);
                gallery.SetActive(true);
                music.SetActive(false);
                break;
            case 3:
                boss.SetActive(false);
                rally.SetActive(false);
                gallery.SetActive(false);
                music.SetActive(true);
                break;
            default:
                break;
        }

        if (Input.GetAxis("Vertical") > 0.1f && cooldown == false)
        {
            if (selected >= 2)
            {
                selected = selected - 2;
                StartCoroutine(CoolDown());
            }
        }

        if (Input.GetAxis("Vertical") < -0.1f && cooldown == false)
        {
            if (selected <= 1)
            {
                selected = selected + 2;
                StartCoroutine(CoolDown());
            }
        }

        if (Input.GetAxis("Horizontal") > 0.1f && cooldown == false)
        {
            if (selected < 3)
            {
                selected++;
                StartCoroutine(CoolDown());
            }
        }

        if (Input.GetAxis("Horizontal") < -0.1f && cooldown == false)
        {
            if (selected != 0)
            {
                selected--;
                StartCoroutine(CoolDown());
            }
        }

        if (Input.GetButtonDown("Attack"))
        {
            Application.LoadLevel("MainMenu");
        }
    }
    private IEnumerator CoolDown()
    {
        cooldown = true;
        yield return new WaitForSeconds(0.2f);
        cooldown = false;
    }
}
