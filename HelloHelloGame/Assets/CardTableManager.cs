using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTableManager : MonoBehaviour
{
    public static CardTableManager Instance;

    public Transform PlayedPlayer;
    public Transform PlayedEnenmy;

    public GameObject PlayerObj;
    public GameObject EnemyObj;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void placePlayerCard()
    {

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
    }
}
