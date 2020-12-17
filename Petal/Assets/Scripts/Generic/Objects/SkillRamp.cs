using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillRamp : MonoBehaviour
{
    public float height;
    // Start is called before the first frame update
    void Start()
    {
        
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
            other.gameObject.GetComponent<PlayerControl>().SkillRamp(height);
            //StartCoroutine(other.gameObject.GetComponent<RotationControl>().NewTarget());
        }
    }
}
