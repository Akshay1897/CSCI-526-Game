﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalbattlemanager : MonoBehaviour
{
    public GameObject movementRef;
    public GameObject cardsRef;

    public GameObject healthbar1Ref;
    public GameObject healthbar2Ref;

    public GameObject text1Ref;
    public GameObject text2Ref;

    public GameObject Player1Ref;
    public GameObject EnemyRef;
    public GameObject PlayerBeforeDuelRef;

    public GameObject level4instructionsRef;

    public GameObject level4dialogueRef;

    public GameObject beforeCam;
    public GameObject afterCam;

    private void Start()
    {
        Player1Ref.SetActive(false);
        EnemyRef.SetActive(true);
        text1Ref.SetActive(false);
        text2Ref.SetActive(false);
        healthbar1Ref.SetActive(false);
        healthbar2Ref.SetActive(false);
        level4instructionsRef.SetActive(false);
        cardsRef.SetActive(false);
    }

    public void startDuelGame()
    {
        Player1Ref.SetActive(true);
        EnemyRef.SetActive(true);
        text1Ref.SetActive(true);
        text2Ref.SetActive(true);
        healthbar1Ref.SetActive(true);
        healthbar2Ref.SetActive(true);
        cardsRef.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        beforeCam.SetActive(false);
        PlayerBeforeDuelRef.SetActive(false);
        afterCam.SetActive(true);
        Player1Ref.SetActive(true);
        EnemyRef.SetActive(true);
        level4dialogueRef.SetActive(true);
        movementRef.SetActive(false);
    }

}
