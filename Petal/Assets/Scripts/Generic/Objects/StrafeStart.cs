using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrafeStart : MonoBehaviour
{
    private float rotation;
    private float x;
    private float z;
    public float stepDistance;
    public bool reverse;
    // Start is called before the first frame update
    void Start()
    {
        rotation = transform.rotation.eulerAngles.y - 90f;
        x = transform.position.x;
        z = transform.position.z;
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
            print("Object is Player");
            other.gameObject.GetComponent<PlayerControl>().StrafeStart(rotation, x, z, stepDistance, reverse);
            //StartCoroutine(other.gameObject.GetComponent<RotationControl>().NewTarget());
        }
    }
}
