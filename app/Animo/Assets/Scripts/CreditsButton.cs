using UnityEngine;
using System.Collections;

public class CreditsButton : MonoBehaviour {
	public Animator animator;
	// Use this for initialization
	void Start () {
	
	}
	

	public void ClickOnCredits(){
		animator.SetBool ("click_on_credits", true);
		animator.SetBool ("click_on_back", false);

	}
}
