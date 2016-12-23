using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {
	public Animator animator;
	AudioSource audio;

	void Start(){
		audio = GetComponent<AudioSource> ();
	}



	public void ClickOnBack(){
		if (!audio.isPlaying) {
			audio.Play ();
		}
		animator.SetBool ("click_on_back", true);
		animator.SetBool ("click_on_credits", false);
	}
}