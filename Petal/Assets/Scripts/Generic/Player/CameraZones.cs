using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZones : MonoBehaviour
{
    public int degrees;
    public bool scripted;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0 ,degrees, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter(Collider other)
    {
        print("Trigger Enter");
        if (other.gameObject.GetComponent<PlayerControl>() != null)
        {
            print("Object is Player");
            other.gameObject.GetComponent<PlayerControl>().targetRotation = transform.rotation;
            //StartCoroutine(other.gameObject.GetComponent<RotationControl>().NewTarget());
            //print("New target message sent");
        }
    }
}
