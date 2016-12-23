﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class QuestionManager : MonoBehaviour {
	
	int buildIndex;
	GameObject manager;
	Animator animator;
	public int receivedAnswer=0;



 
	// Use this for initialization
	 void Start () {


		// manager = GameObject.Find("AnimManager");
		// animator=manager.GetComponent<Animator>();
		animator = GetComponent<Animator>();

	
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
