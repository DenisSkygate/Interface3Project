using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SkinChoice : MonoBehaviour {

	public int nextScene;

	private int currentSkin;

	public GameObject skinsParent;

	private SpriteRenderer[] skins;

	void Start() {
		skins = skinsParent.GetComponentsInChildren<SpriteRenderer>();

		skins[0].enabled = false;

		Randomize();
	}

	public void PreviousSkin() {
		skins[currentSkin].enabled = false;
		if (currentSkin > 0) {
			currentSkin--;
		} else {
			currentSkin = skins.Length - 1;
		}
		skins[currentSkin].enabled = true;
	}

	public void NextSkin() {
		skins[currentSkin].enabled = false;
		if (currentSkin < skins.Length - 1) {
			currentSkin++;
		} else {
			currentSkin = 0;
		}
		skins[currentSkin].enabled = true;
	}

	public void Validate() {
		PlayerPrefs.SetInt("skin", currentSkin);

		PlayerPrefs.Save();

		SceneManager.LoadScene(nextScene);
	}

	public void Randomize() {
		currentSkin = Random.Range(0, 3);
	}
}
