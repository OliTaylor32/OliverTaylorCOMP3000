using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AwardSelector : MonoBehaviour
{
    private bool cooldown;
    public GameObject selector;
    public int selected;
    public Transform[] positions;
    public Text description;
    private string[] awards;
    
    // Start is called before the first frame update
    void Start()
    {
        awards = new string[18];
        awards[0] = "The Beggining: Beat Solicia's Main Stage";
        awards[1] = "Cold Encounter: Win the snowboard race down Schenvic's frosty peak";
        awards[2] = "To The Far East: Dock ship at Bata-Mishu's Harbour";
        awards[3] = "I Know You're Better Than This: Restore humanity to your recovered team-mate";
        awards[4] = "To The Stars: Reach the launch site at Neo-Chora";
        awards[5] = "It Ends Here: Defeat the corrupt horde's leader and escape the space-station";
        awards[6] = "Stage Mastery: Get your first A rank";
        awards[7] = "You Call That A Challenge?: Get an A rank in a challenge stage";
        awards[8] = "Halfway There: A rank 7 different stages";
        awards[9] = "Ultimate Mastery: A rank all 14 stages";
        awards[10] = "Rematch: Complete boss rush";
        awards[11] = "Not So Tough Now Eh?: Achieve an A rank in boss rush";
        awards[12] = "Fast Behind The Wheel: Achieve an A rank in every race";
        awards[13] = "Natural Explorer: Discover your first hidden island";
        awards[14] = "No Stone Unturned: Discover all 7 hidden islands";
        awards[15] = "Decked Out: Install all upgrades onto your ship";
        awards[16] = "The Ultimate Hero: Reach max level in all stats";
        awards[17] = "All The Gear, Some Idea: Purchase all the cosmetics in the shops";


        cooldown = false;
        selected = 0;
        selector.transform.position = new Vector3(positions[0].transform.position.x, selector.transform.position.y, positions[0].position.z);
    }

    // Update is called once per frame
    void Update()
    {
        selector.transform.position = new Vector3(positions[selected].transform.position.x, selector.transform.position.y, positions[selected].position.z);
        description.text = awards[selected];
        if (Input.GetAxis("Vertical") > 0.1f && cooldown == false)
        {
            if (selected >= 6)
            {
                selected = selected - 6;
                StartCoroutine(CoolDown());
            }
        }

        if (Input.GetAxis("Vertical") < -0.1f && cooldown == false)
        {
            if (selected <= positions.Length - 7)
            {
                selected = selected + 6;
                StartCoroutine(CoolDown());
            }
        }

        if (Input.GetAxis("Horizontal") > 0.1f && cooldown == false)
        {
            if (selected < positions.Length - 1)
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
