using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubGate : MonoBehaviour
{
    public bool open;
    public Material closedGate;
    public Material openGate;
    public Scene level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (open == false)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = closedGate;
            GetComponent<MeshCollider>().isTrigger = false;
        }

        if (open == true)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = openGate;
            GetComponent<MeshCollider>().isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerControl>() != null)
        {
            Application.LoadLevel(level.name);
        }
    }

    public void Activate()
    {
        open = true;
    }


}
