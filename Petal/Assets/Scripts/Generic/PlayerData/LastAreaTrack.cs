using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastAreaTrack : MonoBehaviour
{
    public SaveControl save;
    // Start is called before the first frame update
    void Start()
    {
        save.GetArea();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
