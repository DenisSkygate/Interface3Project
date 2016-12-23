using UnityEngine;
using System.Collections;

public class CreditsButton : MonoBehaviour {
	public Animator animator;

	AudioSource audio;

	void Start(){
		audio = GetComponent<AudioSource> ();
	}

	

	public void ClickOnCredits(){
		if (!audio.isPlaying) {
			audio.Play ();
		}
		animator.SetBool ("click_on_credits", true);
		animator.SetBool ("click_on_back", false);

	}
}
