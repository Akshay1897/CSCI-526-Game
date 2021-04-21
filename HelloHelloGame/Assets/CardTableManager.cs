using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTableManager : MonoBehaviour
{
    public static CardTableManager Instance;

    public RectTransform PlayedPlayer;
    public RectTransform PlayedEnenmy;

    public GameObject PlayerObj;
    public GameObject EnemyObj;
 
    public void placePlayerCard()
    {
        PlayerObj.GetComponent<RectTransform>().anchoredPosition = PlayedPlayer.anchoredPosition;
    }

    public void placeEnemyCard()
    {
        EnemyObj.GetComponent<RectTransform>().anchoredPosition = PlayedEnenmy.anchoredPosition;

    }

    public void ClearCard()
    {
        PlayerObj.SetActive(false);
        EnemyObj.SetActive(false);
    }
}
