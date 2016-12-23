using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DressUpManager : MonoBehaviour {

	public int nextScene;

	private int currentSkin;
	private int currentHair;
	private int currentTop;
	private int currentBottom;
	private int currentShoes;

	public GameObject skinsParent;
	public GameObject hairsParent;
	public GameObject topsParent;
	public GameObject bottomsParent;
	public GameObject shoesParent;

	private SpriteRenderer[] skins;
	private SpriteRenderer[] hairs;
	private SpriteRenderer[] tops;
	private SpriteRenderer[] bottoms;
	private SpriteRenderer[] shoes;

	void Start() {
		skins = skinsParent.GetComponentsInChildren<SpriteRenderer>();
		hairs = hairsParent.GetComponentsInChildren<SpriteRenderer>();
		tops = topsParent.GetComponentsInChildren<SpriteRenderer>();
		bottoms = bottomsParent.GetComponentsInChildren<SpriteRenderer>();
		shoes = shoesParent.GetComponentsInChildren<SpriteRenderer>();

		skins[0].enabled = false;

		Randomize();
		LoadPlayerPrefs();
		SetVisibility(true);
	}

	public void PreviousHair() {
		hairs[currentHair].enabled = false;
		if (currentHair > 0) {
			currentHair--;
		} else {
			currentHair = hairs.Length - 1;
		}
		hairs[currentHair].enabled = true;
	}

	public void PreviousTop() {
		tops[currentTop].enabled = false;
		if (currentTop > 0) {
			currentTop--;
		} else {
			currentTop = tops.Length - 1;
		}
		tops[currentTop].enabled = true;
	}

	public void PreviousBottom() {
		bottoms[currentBottom].enabled = false;
		if (currentBottom > 0) {
			currentBottom--;
		} else {
			currentBottom = bottoms.Length - 1;
		}
		bottoms[currentBottom].enabled = true;
	}

	public void PreviousShoes() {
		shoes[currentShoes].enabled = false;
		if (currentShoes > 0) {
			currentShoes--;
		} else {
			currentShoes = shoes.Length - 1;
		}
		shoes[currentShoes].enabled = true;
	}

	public void NextHair() {
		hairs[currentHair].enabled = false;
		if (currentHair < hairs.Length - 1) {
			currentHair++;
		} else {
			currentHair = 0;
		}
		hairs[currentHair].enabled = true;
	}

	public void NextTop() {
		tops[currentTop].enabled = false;
		if (currentTop < tops.Length - 1) {
			currentTop++;
		} else {
			currentTop = 0;
		}
		tops[currentTop].enabled = true;
	}

	public void NextBottom() {
		bottoms[currentBottom].enabled = false;
		if (currentBottom < bottoms.Length - 1) {
			currentBottom++;
		} else {
			currentBottom = 0;
		}
		bottoms[currentBottom].enabled = true;
	}

	public void NextShoes() {
		shoes[currentShoes].enabled = false;
		if (currentShoes < shoes.Length - 1) {
			currentShoes++;
		} else {
			currentShoes = 0;
		}
		shoes[currentShoes].enabled = true;
	}

	public void Validate() {
		PlayerPrefs.SetInt("hair", currentHair);
		PlayerPrefs.SetInt("top", currentTop);
		PlayerPrefs.SetInt("bottom", currentBottom);
		PlayerPrefs.SetInt("shoes", currentShoes);

		PlayerPrefs.Save();

		SceneManager.LoadScene(nextScene);
	}

	public void LoadPlayerPrefs() {
		if (PlayerPrefs.HasKey("skin")) {
			currentSkin = PlayerPrefs.GetInt("skin");
		} else {
			currentSkin = 0;
		}

		if (PlayerPrefs.HasKey("hair")) {
			currentHair = PlayerPrefs.GetInt("hair");
		}

		if (PlayerPrefs.HasKey("top")) {
			currentTop = PlayerPrefs.GetInt("top");
		}

		if (PlayerPrefs.HasKey("bottom")) {
			currentBottom = PlayerPrefs.GetInt("bottom");
		}

		if (PlayerPrefs.HasKey("shoes")) {
			currentShoes = PlayerPrefs.GetInt("shoes");
		}
	}

	public void Randomize() {
		currentHair = Random.Range(0, 3);
		currentTop = Random.Range(0, 3);
		currentBottom = Random.Range(0, 3);
		currentShoes = Random.Range(0, 3);
	}

	public void SetVisibility(bool visible) {
		skins[currentSkin].enabled = visible;
		hairs[currentHair].enabled = visible;
		tops[currentTop].enabled = visible;
		bottoms[currentBottom].enabled = visible;
		shoes[currentShoes].enabled = visible;
	}
}
