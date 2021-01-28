using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Button left;
    public Button right;
    public bool down;
    private bool changed;
    // Start is called before the first frame update
    void Start()
    {
        Animation();
        changed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Switch()
    {
        StartCoroutine(Cooldown());
        if (down == true)
        {
            down = false;
        }
        else
        {
            down = true;
        }
        Animation();
    }

    private void Animation()
    {
        if (down == true)
        {
            GetComponent<Animator>().Play("ButtonPress");
        }
        else
        {
            GetComponent<Animator>().Play("ButtonRelease");
        }
    }

    public void Contact()
    {
        if (changed == false && down == false)
        {
            changed = true;
            Switch();
            if (left != null)
            {
                left.Switch();
            }
            if (right != null)
            {
                right.Switch();
            }
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1.5f);
        changed = false;
    }
}
