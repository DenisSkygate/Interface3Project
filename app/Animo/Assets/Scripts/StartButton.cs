using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
	public Animator animator;
	AudioSource audio;

	void Start(){
		audio = GetComponent<AudioSource> ();
	}

	
	public void ClickOnStart(){
		if (!audio.isPlaying) {
			audio.Play ();
		}
		animator.SetBool ("click_on_start", true);
	}
}
