using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public Scoring scoring;
    public PlayerControl player;
    public int points;
    public bool shield;
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

    public void Attacked(int damage, bool heavy)
    {
        if (heavy == true)
        {
            shield = false;
        }
        if (shield == false)
        {
            health = health - damage;
        }
    }
}
