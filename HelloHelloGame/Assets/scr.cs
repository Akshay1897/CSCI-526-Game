using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 60f;

    public GameObject Panel;
    public Button nextButton;
    public Text countdownText;
    int goals = 0;

    bool startTimer = false;

    void Start()
    {
        Panel.SetActive(false);
        //nextButton.SetActive(false);
        currentTime = startingTime;
    }

    void closePanel()
    {
        Panel.SetActive(false);
    }

    void Update()
    {
        timer();
    }

    public void BeginTimer()
    {
        currentTime = startingTime;
        startTimer = true;
    }

    public void timer()
    {

        if (startTimer == true)
        {
            currentTime -= 1 * Time.deltaTime;

            if (currentTime <= 10)
            {
                countdownText.color = Color.red;
            }

            countdownText.text = currentTime.ToString("0");

            Debug.Log(countdownText.text);
            if (currentTime <= 0)
            {
                currentTime = 0;
            }

            if (currentTime == 0)
            {
                //nextButton.SetActive(true);
                Panel.SetActive(true);
                startTimer = false;

                nextButton.onClick.AddListener(closePanel);
            }
        }

    }

}
