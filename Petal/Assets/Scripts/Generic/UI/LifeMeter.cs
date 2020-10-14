using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeMeter : MonoBehaviour
{
    public Sprite[] icons = new Sprite[4];
    private Image image;
    public PlayerControl player;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = icons[player.life];
    }
}
