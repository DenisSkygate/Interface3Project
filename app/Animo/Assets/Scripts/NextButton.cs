using UnityEngine;
using System.Collections;

public class NextButton : MonoBehaviour {

	public Animator animator;
	// Use this for initialization
	void Start () {

	}

	public void ClickOnNext(){
		animator.SetBool ("click_on_next", true);
	}
}
