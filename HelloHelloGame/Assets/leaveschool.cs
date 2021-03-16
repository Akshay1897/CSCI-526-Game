using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leaveschool : MonoBehaviour
{
    public GameObject leaveforschool;
    public GameObject DemoSceneRef;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        leaveforschool.SetActive(true);
        DemoSceneRef.SetActive(false);
    }
}
