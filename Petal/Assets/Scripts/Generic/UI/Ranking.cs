using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public int timeGoal;
    public int scoreGoal;
    public Timer time;
    public Scoring score;

    public Sprite a, b, c;

    public SaveControl save;

    public string stage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StageEnd()
    {
        time.Stop();
        int rank = 0;
        if (time.timer < timeGoal)
        {
            rank++;
        }
        if (score.score >= scoreGoal)
        {
            rank++;
        }
        if (rank == 0)
        {
            GetComponent<Image>().sprite = c;
            save.xp = save.xp + 250 + (score.score / 2);
        }
        else if (rank == 1)
        {
            GetComponent<Image>().sprite = b;
            save.xp = save.xp + 500 + (score.score / 2);
        }
        else if (rank == 2)
        {
            GetComponent<Image>().sprite = a;
            save.xp = save.xp + 750 + (score.score / 2);
        }
        else
        {
            GetComponent<Image>().sprite = c;
            save.xp = save.xp + 250 + (score.score / 2);
        }
        GetComponent<Image>().enabled = true;

        switch (stage)
        {
            case "SoliciaMain":
                if (save.solicia1 < rank + 1)
                {
                    save.gold = save.gold + (((rank + 1) - save.solicia1) * 100);
                    save.solicia1 = rank + 1;
                }
                break;

            default:
                break;
        }
        save.Save();
    }

}
