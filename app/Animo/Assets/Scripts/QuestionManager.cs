using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class QuestionManager : MonoBehaviour {
	
	int buildIndex;
	GameObject manager;
	Animator animator;
	public int receivedAnswer=0;
	public int sceneNumber;
	public string[]  textLines;
	public TextAsset textFile;
	public Text theTextA;
	public Text theTextB;
	public Text theTextC;
	GameObject repA;
	GameObject repB;
	GameObject repC;
	public int endAtLine;


 
	// Use this for initialization
	 void Start () {

		/*manager=GameObject.Find("AnimManager");*/
		animator=GetComponent<Animator>();
		
	
	 }
	public void ContinueDialog(int answer){
		animator.SetBool("needCanvas",false);
		receivedAnswer=answer;
	}

	public void LoadSceneWithRandom(int buildIndex){

		buildIndex=RandomBetweenScene(0,1);

		SceneManager.LoadScene(buildIndex);
	}
	public void LoadScene(int buildIndex){

		SceneManager.LoadScene(buildIndex);
	}

	void DisplayQuestion(){

		

		int startLine=0;
		int currentLine=0;
		textLines = textFile.text.Split('\n');
		theTextA.text = textLines[currentLine];
		theTextB.text = textLines[currentLine];
		theTextC.text = textLines[currentLine];

	}

	int RandomBetweenScene(int succes, int fail){
		int randomMinNumber=0;
	 	int randomMaxNumber=100;
		int random=Random.Range(randomMinNumber,randomMaxNumber);

		if (random<=50){
			return fail;
		}

		else {
			return succes;
			
		}
	}


}
