using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Manager : MonoBehaviour
{
    public Transform Level4TeleportLocation;
    public GameObject level4UI;

    public GameObject playerModel;
    //public GameObject jumpBtn;
    public GameObject playerRef;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartLevel4()
    {
        playerRef.transform.position = Level4TeleportLocation.position;
        playerRef.transform.rotation = Level4TeleportLocation.rotation;
    }

    public void EndLevel2()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        StartLevel4();
    }

    public void StartLevel4UI()
    {
        level4UI.SetActive(true);
    }
}
