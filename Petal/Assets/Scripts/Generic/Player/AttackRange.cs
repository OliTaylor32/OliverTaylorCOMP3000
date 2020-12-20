using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public GameObject[] attackable;
    public GameObject interactable;
    private int interactableType; // 0 = Basic 1 = fetch 2 = stage
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
        if (other.gameObject.GetComponent<BasicNPC>() != null)
        {
            print("BasicNPC In range");
            interactable = other.gameObject;
            interactableType = 0;
        }

        if (other.gameObject.GetComponent<FetchNPC>() != null)
        {
            print("BasicNPC In range");
            interactable = other.gameObject;
            interactableType = 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == interactable)
        {
            interactable = null;
        }
    }

    public void Interact()
    {
        if (interactableType == 0)
        {
            print("Start Interaction");
            interactable.GetComponent<BasicNPC>().StartInteraction();
        }
        if (interactableType == 1)
        {
            print("Start Interaction");
            interactable.GetComponent<FetchNPC>().StartInteraction();
        }
    }
}
