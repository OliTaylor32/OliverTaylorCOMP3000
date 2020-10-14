using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunStart : MonoBehaviour
{
    private float rotation;
    // Start is called before the first frame update
    void Start()
    {
        rotation = transform.rotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        //print("Trigger Enter");
        if (other.gameObject.GetComponent<PlayerControl>() != null)
        {
            //print("Object is Player");
            other.gameObject.GetComponent<PlayerControl>().RunStart(rotation);
            //StartCoroutine(other.gameObject.GetComponent<RotationControl>().NewTarget());
        }
    }
}
