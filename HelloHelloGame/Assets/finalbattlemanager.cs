using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalbattlemanager : MonoBehaviour
{
    public GameObject movementRef;
    public GameObject cardsRef;

    public GameObject healthbar1Ref;
    public GameObject healthbar2Ref;

    public Text text1Ref;
    public Text text2Ref;

    public GameObject level4instructionsRef;


    public void normalPlayGame()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        level4instructionsRef.SetActive(true);
        movementRef.SetActive(false);
    }

}
