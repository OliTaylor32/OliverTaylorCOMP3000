using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float time;
    public float timer;
    private Text text;
    private bool end;
    // Start is called before the first frame update
    void Start()
    {
        end = false;
        time = Time.time;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (end == false)
        {
            timer = (Time.time - time);
            timer = Mathf.Round(timer * 100f) / 100f;
            text.text = "Time: " + timer;
        }
    }

    public void Stop()
    {
        end = true;
    }
}
