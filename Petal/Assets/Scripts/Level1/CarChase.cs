using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarChase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().StopPlayback();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerControl>() != null)
        {
            GetComponent<Animator>().Play("CarChase");
            Destroy(GetComponent<BoxCollider>());
        }
    }
}
