using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public Scoring scoring;
    public PlayerControl player;
    public int points;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            player.boost = player.boost + points;
            scoring.AddScore(points);
        }   
    }

    public void Attacked(int damage)
    {
        health = health - damage;
    }
}
