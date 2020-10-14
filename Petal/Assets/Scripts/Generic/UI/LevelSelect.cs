using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public string level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        Application.LoadLevel(level);
#pragma warning restore CS0618 // Type or member is obsolete
    }
}
