using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportlevel4 : MonoBehaviour
{
    public GameObject btnRef;
    public GameObject movementRef;

    private void OnTriggerEnter(Collider other)
    {
        movementRef.SetActive(false);
        btnRef.SetActive(true);
    }
}
