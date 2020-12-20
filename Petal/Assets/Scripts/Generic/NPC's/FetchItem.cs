using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetchItem : MonoBehaviour
{
    public GameObject NPC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        NPC.GetComponent<FetchNPC>().ItemCollected();
        this.gameObject.SetActive(false);
    }
}
