using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

    public string[] sfx;

    // Use this for initialization
    void Start()
    {
        sfx = new string[3];
        sfx[0] = "SOUND1";
        sfx[1] = "SOUND2";
        sfx[2] = "SOUND3";

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
        GetAnswerAndLoadNextScene();         
        if (sceneLoaded && sceneText.Count > 0)
        {
            PlayLoadedScene(sceneText);
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
            if (AtGoToString(sceneText[sceneLine].Replace("\r", ""))) {
                SceneManager.LoadScene(GetSceneIndex(sceneText[sceneLine].Replace("\r", "")));
            }
            if (AtSoundString(sceneText[sceneLine].Replace("\r", ""))) {
                print(sfx[GetAudioIndex(sceneText[sceneLine].Replace("\r", ""))]);
            }
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
                    if (!AtSoundString(sceneText[sceneLine].Replace("\r", ""))) {
                        textLine += sceneText[i].Replace("\r", "") + " ";
                    }
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

    void GetAnswerAndLoadNextScene() {
        if (anim)
        {
            print("playing animation");
            if (!animator.GetBool("needCanvas")) {
                if (questionManager.receivedAnswer != 0) {      
                    sceneNumber +=   questionManager.receivedAnswer;             
                    print("sceneNumber : " + sceneNumber);
                    sceneLine = 0;
                    sceneText = LoadNextScene(sceneNumber);
                    questionManager.receivedAnswer = 0;
                }                
                anim = false;            
            }
        }
    }

    bool AtSoundString(string stingAtActualLine) {
        if (stingAtActualLine.Substring(1, 5) == "SOUND") {
            return true;
        }
        return false;
    }

    bool AtGoToString(string stingAtActualLine) {
        if (stingAtActualLine.Substring(1, 9) == "GOTOSCENE") {
            return true;
        }
        return false;
    }

    int GetAudioIndex(string stingAtActualLine) {
        int audioIndex =  int.Parse(stingAtActualLine.Substring(6, 1));
        return audioIndex-1;
    }

    int GetSceneIndex(string stingAtActualLine) {
        int sceneIndex =  int.Parse(stingAtActualLine.Substring(10, 1));
        return sceneIndex-1;
    }
}
