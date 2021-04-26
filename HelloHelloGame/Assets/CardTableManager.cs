using System.Collections;
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
        ifWinPanelRef.SetActive(true);

        Invoke("Paneloff", 3);
    }

    public void Paneloff()
    {
        ifWinPanelRef.SetActive(false);

        FinalDialogueRef.SetActive(true);
    }

    
}
