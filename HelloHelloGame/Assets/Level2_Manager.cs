using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_Manager : MonoBehaviour
{
    public GameObject playerModel;
    public ThirdPersonMovement thirdPersonScriptReference;
    public GameObject throwButton;
    public GameObject fixedJoystick;

    public Transform Level2playerTeleportLocation;

    public Transform Level3playerTeleportLocation;

    public GameObject playerRef;

    public GameObject scoreRef;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void startLevel2()
    {

        playerModel.SetActive(false);
        thirdPersonScriptReference.lockMovementInput();

        fixedJoystick.SetActive(false);
        throwButton.SetActive(true);

        playerRef.transform.position = Level2playerTeleportLocation.position;
        playerRef.transform.rotation = Level2playerTeleportLocation.rotation;

        scoreRef.SetActive(true);

    }

    public void endLevel2()
    {
        playerModel.SetActive(true);
        thirdPersonScriptReference.unlockMovementInput();

        fixedJoystick.SetActive(true);
        throwButton.SetActive(false);

        playerRef.transform.position = Level3playerTeleportLocation.position;
        playerRef.transform.rotation = Level3playerTeleportLocation.rotation;

        scoreRef.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        startLevel2();
    }
}
