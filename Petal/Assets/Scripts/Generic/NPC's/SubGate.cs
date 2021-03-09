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
    public string location;
    public SaveControl save;
    // Start is called before the first frame update
    void Start()
    {
        save.Load();
        if (location == "Solicia")
        {
            if (save.solicia2 > -1)
            {
                Activate();
            }
        }
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
            save.Save();
            Application.LoadLevel(level.handle);
        }
    }

    public void Activate()
    {
        if (location == "Solicia")
        {
            if (save.solicia2 < 0)
            {
                save.solicia2 = 0;
            }
        }
        open = true;
        save.Save();
    }


}
