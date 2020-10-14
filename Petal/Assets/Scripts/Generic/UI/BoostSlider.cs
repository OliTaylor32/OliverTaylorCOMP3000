using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostSlider : MonoBehaviour
{
    private int current;
    private int max;
    private Slider slider;
    public PlayerControl player;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        //slider.maxValue = player.maxBoost;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = player.boost;
    }
}
