using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationControl : MonoBehaviour
{
    public float targetRotation;
    private float turnspeed;
    // Start is called before the first frame update
    void Start()
    {
        turnspeed = 10f;   
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.rotation.x, targetRotation, transform.rotation.z), turnspeed * Time.deltaTime);
    }

    //public IEnumerator NewTarget()
    //{
    //    print("New Target called");
    //    if (transform.rotation.y < targetRotation)
    //    {
    //        while(transform.rotation.y < targetRotation)
    //        {
    //            transform.Rotate(Vector3.RotateTowards(new Vector3 (transform.rotation.x, transform.rotation.y, transform.rotation.z), new Vector3(transform.rotation.x, targetRotation, transform.rotation.z), turnspeed * Time.deltaTime, 0f)); 
    //            print("rotate Right");
    //            yield return new WaitForSeconds(0.01f);
    //        }
    //        yield return null;
    //    }
    //    else if (transform.rotation.y > targetRotation)
    //    {
    //        while (transform.rotation.y > targetRotation)
    //        {
    //            transform.Rotate(Vector3.RotateTowards(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z), new Vector3(transform.rotation.x, targetRotation, transform.rotation.z), turnspeed, 0f));
    //            print("rotate Right");
    //            yield return new WaitForSeconds(0.01f);
    //        }
    //        yield return null;
    //    }
    //}
}
