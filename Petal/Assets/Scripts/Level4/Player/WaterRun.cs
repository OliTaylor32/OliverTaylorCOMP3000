using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRun : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.name == "Water")
        {
            if (GetComponent<PlayerControl>().speed < GetComponent<PlayerControl>().maxSpeed * 0.75f)
            {
                hit.gameObject.GetComponent<MeshCollider>().convex = true;
                hit.gameObject.GetComponent<MeshCollider>().isTrigger = true;
                yield return new WaitForSeconds(1);
                hit.gameObject.GetComponent<MeshCollider>().isTrigger = false;
                hit.gameObject.GetComponent<MeshCollider>().convex = false;
            }
        }
    }
}
