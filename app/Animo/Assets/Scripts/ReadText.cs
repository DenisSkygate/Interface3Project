using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class ReadText : MonoBehaviour {

    public Text displayedText;
    public string path;
    public string[] textLines;
    public string textLine;
    public string textFileName;
    public int actualLine;

    public GameObject narrationFrame;
    public GameObject dialogueFrame;
    public GameObject monologueFrame;

    public bool anim;

    public int sceneNumber;
    public bool playScene;

    // Use this for initialization
    void Start () {
        string textFileName = "text.txt";
        path = Application.dataPath + "/Resources/" + textFileName;
        textLine = "";
        displayedText.text = "";

        narrationFrame.SetActive(false);
        dialogueFrame.SetActive(false);
        monologueFrame.SetActive(false);

        sceneNumber = 1;        

        anim = false;
        playScene = false;
        textLines = File.ReadAllLines(path);

        //DisplayTextTest();
        PlayNextScene();

    }
	
	// Update is called once per frame
	void Update () {
        if (anim)
        {
            print("playing animation");
            if (Input.GetKeyUp(KeyCode.A))
            {
                sceneNumber = 2;
                actualLine++;
                print("sceneNumber : " + sceneNumber);
                anim = false;
            }
            else if (Input.GetKeyUp(KeyCode.B))
            {
                sceneNumber = 3;
                actualLine++;
                print("sceneNumber : " + sceneNumber);
                anim = false;
            }
        }
        PlayNextScene();
    }

    void PlayNextScene ()
    {
        if (!playScene && textLines[actualLine] != "[SCENE" + sceneNumber + "]" && !anim)
        {
            actualLine++;
        }
        else if (!playScene && textLines[actualLine] == "[SCENE" + sceneNumber + "]" && !anim)
        {
            actualLine++;
            playScene = true;
        }
    }

    void OnMouseDown()
    {
        if (actualLine < textLines.Length)
        {
            DisplayText();
        }
        print("Mouse");
    }

    void DisplayTextTest()
    {
        textLine = "";
        textLines = File.ReadAllLines(path);
        for (int i = actualLine; i < textLines.Length; i++)
        {
            //if (playScene)
            //{
                if (textLines[i] == "[/NARRATION]" || textLines[i] == "[/DIALOGUE]" || textLines[i] == "[/MONOLOGUE]" || textLines[i] == "[/SCENE" + sceneNumber + "]")
                {
                    actualLine++;
                    if (textLines[i] == "[/SCENE" + sceneNumber + "]")
                    {
                        if (textLines[actualLine] == "[QUESTION]")
                        {
                            print("Animation!");
                            anim = true;
                        }
                        playScene = false;
                    }
                    break;
                }
                switch (textLines[i])
                {
                    case "[NARRATION]":
                        narrationFrame.SetActive(true);
                        dialogueFrame.SetActive(false);
                        monologueFrame.SetActive(false);
                        break;
                    case "[DIALOGUE]":
                        narrationFrame.SetActive(false);
                        dialogueFrame.SetActive(true);
                        monologueFrame.SetActive(false);
                        break;
                    case "[MONOLOGUE]":
                        narrationFrame.SetActive(false);
                        dialogueFrame.SetActive(false);
                        monologueFrame.SetActive(true);
                        break;
                    default:
                        if (actualLine > 0)
                        {
                            textLine += " ";
                        }
                        textLine += textLines[i];
                        break;

                }
                actualLine++;
            //}
        }


        displayedText.text = textLine;
        if (textLine == "")
        {
            narrationFrame.SetActive(false);
            dialogueFrame.SetActive(false);
            monologueFrame.SetActive(false);
        }
    }

    void DisplayText()
    {
        textLine = "";
        textLines = File.ReadAllLines(path);
        for (int i = actualLine; i < textLines.Length; i++)
        {            
            if (!playScene && textLines[i] != "[SCENE" + sceneNumber + "]")
            {
                actualLine++;
            }
            else if (!playScene && textLines[i] == "[SCENE" + sceneNumber + "]") {
                actualLine++;
                playScene = true;
            }
            else if (playScene)
            {
                if (textLines[i] == "[/NARRATION]" || textLines[i] == "[/DIALOGUE]" || textLines[i] == "[/MONOLOGUE]" || textLines[i] == "[/SCENE" + sceneNumber + "]")
                {
                    actualLine++;
                    if (textLines[i] == "[/SCENE" + sceneNumber + "]")
                    {
                        if (textLines[actualLine] == "[QUESTION]")
                        {
                            print("Animation!");
                            anim = true;
                        }
                        playScene = false;
                    }
                    break;
                }
                switch (textLines[i])
                {
                    case "[NARRATION]":
                        narrationFrame.SetActive(true);
                        dialogueFrame.SetActive(false);
                        monologueFrame.SetActive(false);
                        break;
                    case "[DIALOGUE]":
                        narrationFrame.SetActive(false);
                        dialogueFrame.SetActive(true);
                        monologueFrame.SetActive(false);
                        break;
                    case "[MONOLOGUE]":
                        narrationFrame.SetActive(false);
                        dialogueFrame.SetActive(false);
                        monologueFrame.SetActive(true);
                        break;
                    default:
                        if (actualLine > 0)
                        {
                            textLine += " ";
                        }
                        textLine += textLines[i];
                        break;

                }
                actualLine++;
            }
        }
            

        displayedText.text = textLine;
        if (textLine == "")
        {
            narrationFrame.SetActive(false);
            dialogueFrame.SetActive(false);
            monologueFrame.SetActive(false);
        }            
    }
}
