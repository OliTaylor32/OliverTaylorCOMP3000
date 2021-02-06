using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public Scene stage;
    public Ranking ranking;
    public Vector3 cameraPos;
    public Quaternion cameraRot;
    public Camera cam;
    public PlayerControl player;
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
        if (other.gameObject.GetComponent<PlayerControl>() != null)
        {
            StartCoroutine(rankingTime());
        }
    }

    private IEnumerator rankingTime()
    {
        ranking.StageEnd();
        player.controlType = 4;
        cam.transform.parent = null;
        cam.transform.rotation = cameraRot;
        cam.transform.position = cameraPos;
        yield return new WaitForSecondsRealtime(10.0f);
        Application.LoadLevel(stage.handle);
    }
}
