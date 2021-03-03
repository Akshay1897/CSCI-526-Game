using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketBallScore : MonoBehaviour
{
    int Score = 0;

    public Text scoreRef;

    void Start()
    {
        scoreRef.text = Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Score = Score + 100;
        scoreRef.text = Score.ToString();
    }
}
