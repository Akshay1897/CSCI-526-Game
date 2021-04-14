using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{
    public GameObject textBox;
    public GameObject PlayButton;

    public Text theText;
    
    public TextAsset textFile;
    [Multiline(15)]
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    int index1 = 1;

    //public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        //player = FindObjectOfType<PlayerController>();

        if (textFile != null)
        {
            textLines = (textFile.text.Split('x'));

        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
    }

    void Update()
    {
        theText.text = textLines[currentLine];


        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Ended)
        {
            currentLine += 1;
        }

        //if (Input.touchCount > 0)
        //{
        //    currentLine += 1;
        //}

        if (currentLine > endAtLine)
        {
            textBox.SetActive(false);
            PlayButton.SetActive(true);
        }
    }
}
