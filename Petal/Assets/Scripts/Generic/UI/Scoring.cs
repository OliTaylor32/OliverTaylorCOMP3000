using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public int score;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        score = 0;
        text.text = "score: " + "00000";
    }

    // Update is called once per frame
    void Update()
    {
        if (score <= 9)
        {
            text.text = "Score: " + "0000" + score;
        }
        else if (score <= 99)
        {
            text.text = "Score: " + "000" + score;
        }
        else if (score <= 999)
        {
            text.text = "Score: " + "00" + score;
        }
        else if (score <= 9999)
        {
            text.text = "Score: " + "0" + score;
        }
        else if (score <= 99999)
        {
            text.text = "Score: " + score;
        }

    }

    public void AddScore(int add)
    {
        score = score + add;
    }
}
