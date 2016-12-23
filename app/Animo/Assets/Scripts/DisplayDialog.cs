using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class DisplayDialog : MonoBehaviour
{

    public Text displayedText;
    public string path;
    public string[] textLines;
    public string textLine;
    public string textFileName;
    public int actualLine;
    public int sceneLine;

    public GameObject narrationFrame;
    public GameObject dialogueFrame;
    public GameObject monologueFrame;

    public bool anim;

    public TextAsset theText;

    public int sceneNumber;
    public bool sceneLoaded;
    public List<string> sceneText;

    public GameObject animatorObject;
    Animator animator;

    QuestionManager questionManager;

    // Use this for initialization
    void Start()
    {
        animator = animatorObject.GetComponent<Animator>();
        questionManager = animatorObject.GetComponent<QuestionManager>();

        textLine = "";
        displayedText.text = "";

        narrationFrame.SetActive(false);
        dialogueFrame.SetActive(false);
        monologueFrame.SetActive(false);

        actualLine = 0;
        sceneNumber = 1;

        anim = false;
        textLines = theText.text.Split('\n');

        sceneText = LoadNextScene(sceneNumber);

        if (sceneText.Count > 0)
        {
            PlayLoadedScene(sceneText);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (anim)
        {
            print("playing animation");
            if (!animator.GetBool("needCanvas")) {
                if (questionManager.receivedAnswer != 0) {                    
                    if (questionManager.receivedAnswer == 1) {                    
                        sceneNumber++;
                    }
                    else if (questionManager.receivedAnswer == 2) {                    
                        sceneNumber += 2;
                    }
                    else if (questionManager.receivedAnswer == 2) {                    
                        sceneNumber += 3;
                    }                
                    print("sceneNumber : " + sceneNumber);
                    sceneLine = 0;
                    sceneText = LoadNextScene(sceneNumber);
                    questionManager.receivedAnswer = 0;
                }                
                anim = false;
            }
        }
    }    

    void OnMouseDown()
    {
        if (sceneText.Count > 0)
        {
            PlayLoadedScene(sceneText);
        }
    }
    
    List<string> LoadNextScene(int sceneNumber)
    {
        sceneLoaded = true;
        List<string> sceneText = new List<string>();
        while (textLines[actualLine].Replace("\r", "") != "[SCENE" + sceneNumber + "]") {
            actualLine++;
        }
        if (textLines[actualLine].Replace("\r", "") == "[SCENE" + sceneNumber + "]")
        {
            actualLine++;
            for (int i = actualLine; i < textLines.Length; i++)
            {
                actualLine++;
                if (textLines[i].Replace("\r", "") == "[/SCENE" + sceneNumber + "]")
                {
                    break;
                }
                else
                {
                    sceneText.Add(textLines[i]);

                }
            }
        }
        return sceneText;
    }

    void PlayLoadedScene(List<string> sceneText)
    {
        sceneLoaded = false;
        textLine = "";
        for (int i = sceneLine; i < sceneText.Count; i++)
        {
            if (sceneText[sceneLine].Replace("\r", "") == "[QUESTION]")
            {
                sceneLine++;
                animator.SetBool("needCanvas", true);
                anim = true;
                break;
            }
            else if (sceneText[i].Replace("\r", "") == "[/NARRATION]" || sceneText[i].Replace("\r", "") == "[/DIALOGUE]" || sceneText[i].Replace("\r", "") == "[/MONOLOGUE]")
            {
                sceneLine++;
                break;
            }
            switch (sceneText[i].Replace("\r", ""))
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
                    textLine += sceneText[i].Replace("\r", "") + " ";
                    break;
            }

            sceneLine++;
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
