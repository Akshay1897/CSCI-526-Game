﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardTableManager : MonoBehaviour
{
    public static CardTableManager Instance;

    public Transform PlayedPlayer;
    public Transform PlayedEnenmy;

    public GameObject PlayerObj;
    public GameObject EnemyObj;

    public AudioSource Soundref;

    public GameObject FinalDialogueRef;

    public GameObject ifWinPanelRef;
    public Text PanelTextRef;

    public GameObject healthbar1Ref;
    public GameObject healthbar2Ref;

    public GameObject Text1Ref;
    public GameObject Text2Ref;

    public AudioSource PlayerAudioRef;

    public AudioClip AtkAudio;
    public AudioClip DefAudio;
    public AudioClip HealAudio;

    public GameObject GamePlayer;
    public GameObject GameEnemey;

    public GameObject StandPlayer;
    public GameObject StandEnemy;

    public Animator PlayerAnimatorRef;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void placePlayerCard()
    {
        Debug.LogWarning(PlayerObj);
        PlayerObj.transform.position = PlayedPlayer.transform.position;

        switch (PlayerObj.GetComponent<SpellCard>().currCardType)
        {
            case SpellCard.cardType.attack:
                PlayerAnimatorRef.Play("PlayerNewSimpleAtk");
                PlayerAudioRef.PlayOneShot(AtkAudio);
                break;

            case SpellCard.cardType.defence:
                PlayerAudioRef.PlayOneShot(DefAudio);
                PlayerAnimatorRef.Play("Player_Final_Def");
                break;

            case SpellCard.cardType.heal:
                PlayerAudioRef.PlayOneShot(HealAudio);
                PlayerAnimatorRef.Play("Player_Final_Heal");
                break;

            case SpellCard.cardType.buff:
                
                break;
        }
    }

    public void placeEnemyCard()
    {
        //if (PlayedEnenmy.transform.GetChild(0))
        //{
        //    PlayedEnenmy.transform.GetChild(0).gameObject.SetActive(false);
        //}
        
        EnemyObj = Instantiate(EnemyObj, PlayedEnenmy.transform);
        //EnemyObj.transform.position = PlayedEnenmy.transform.position;
    }

    public void ClearCard()
    {
        PlayerObj.SetActive(false);
        EnemyObj.SetActive(false);

        //Soundref.Play();
    }

    public void endBattle(bool ifwin)
    {
        
        if (ifwin == true)
        {
            PanelTextRef.text = "Congratulations you Won!!";
        }

        else
        {
            PanelTextRef.text = "Better luck next time!!";
        }

        Invoke("Panelon", 3);
        
    }

    public void Panelon()
    {
        healthbar1Ref.SetActive(false);
        healthbar2Ref.SetActive(false);

        Text1Ref.SetActive(false);
        Text2Ref.SetActive(false);

        GamePlayer.SetActive(false);
        GameEnemey.SetActive(false);

        StandPlayer.SetActive(true);
        StandEnemy.SetActive(true);

        ifWinPanelRef.SetActive(true);

        Invoke("Paneloff", 5);
    }

    public void Paneloff()
    {
        ifWinPanelRef.SetActive(false);

        FinalDialogueRef.SetActive(true);
    }

    
}
