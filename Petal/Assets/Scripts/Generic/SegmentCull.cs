using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentCull : MonoBehaviour
{
    GameObject[] children;
    public bool isFirstSegment;
    // Start is called before the first frame update
    void Start()
    {
        int i = 0;

        children = new GameObject[transform.childCount];

        foreach (Transform child in transform)
        {
            children[i] = child.gameObject;
            i++;
        }

        if (isFirstSegment == false)
        {
            foreach (GameObject child in children)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerControl>() != null)
        {
            foreach (GameObject child in children)
            {
                child.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerControl>() != null)
        {
            foreach (GameObject child in children)
            {
                child.gameObject.SetActive(false);
            }

        }
    }
}
