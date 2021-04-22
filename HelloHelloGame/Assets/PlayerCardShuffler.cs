using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCardShuffler : MonoBehaviour
{

    int counter = 0;
    public GameObject turn1Player;
    public GameObject turn2Player;

    public void setGameObjectFalse(GameObject objRef)
    {
        counter = counter + 1;

        //objRef.SetActive(false);

        turnChecker();

    }

    void turnChecker()
    {
        if (counter > 4)
        {
            nextturn();
        }
    }

    void nextturn()
    {
        turn1Player.SetActive(false);
        turn2Player.SetActive(true);
    }

}
