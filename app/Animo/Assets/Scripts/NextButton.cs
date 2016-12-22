using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 

public class NextButton : MonoBehaviour {
	public float timeBeforeLoadScene = 1f;
	private float time = 0f;
	public Animator animator;
	public string sceneName;
	// Use this for initialization
	void Start () {

	}

	void Update(){
		if (animator.GetBool ("click_on_next")) {
			time += Time.deltaTime;
			if (time >= timeBeforeLoadScene) {
				SceneManager.LoadScene (sceneName);
			}
		}
	}

	public void ClickOnNext(){
		animator.SetBool ("click_on_next", true);
	}
}
