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
 
    public void placePlayerCard()
    {
        Instantiate(PlayerObj, PlayedPlayer);
    }

    public void placeEnemyCard()
    {
        Instantiate(EnemyObj, PlayedEnenmy);
    }

    public void ClearCard()
    {
        PlayerObj.SetActive(false);
        EnemyObj.SetActive(false);
    }
}
