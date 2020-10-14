using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float time;
    private float timer;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer = (Time.time - time);
        timer = Mathf.Round(timer * 100f) / 100f;
        text.text = "Time: " + timer;
    }
}
