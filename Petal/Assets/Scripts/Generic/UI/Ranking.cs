﻿using System.Collections;
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
        }
        else if (rank == 1)
        {
            GetComponent<Image>().sprite = b;
        }
        else if (rank == 2)
        {
            GetComponent<Image>().sprite = a;
        }
        else
        {
            GetComponent<Image>().sprite = c;
        }
        GetComponent<Image>().enabled = true;
    }
}