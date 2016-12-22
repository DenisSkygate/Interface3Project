using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {
	public Animator animator;
	// Use this for initialization
	void Start () {

	}


	public void ClickOnBack(){
		animator.SetBool ("click_on_back", true);
		animator.SetBool ("click_on_credits", false);
	}
}