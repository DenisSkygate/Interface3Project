using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
	public Animator animator;
	// Use this for initialization
	void Start () {
	
	}
	
	public void ClickOnStart(){
		animator.SetBool ("click_on_start", true);
	}
}
