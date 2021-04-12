using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    public int ground = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ground == 0)
        {
            print("No Ground");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerControl>() == null && other.gameObject.name != "PostProcessing" && other.GetComponent<SunEnergy>() == null && other.GetComponent<StrafeStart>() == null && other.gameObject.name != "DeathBarrier" && other.gameObject.name != "IceCreamVan" && other.gameObject.GetComponent<SegmentCull>() == null)
        {
            ground++;
            print("New Ground");
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerControl>() == null && other.gameObject.name != "PostProcessing" && other.GetComponent<SunEnergy>() == null && other.GetComponent<StrafeStart>() == null && other.gameObject.name != "DeathBarrier" && other.gameObject.name != "IceCreamVan" && other.gameObject.GetComponent<SegmentCull>() == null)
        {
            ground--;
            print("ground Gone");
        }
    }

    public bool isGrounded()
    {
        if (ground > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
