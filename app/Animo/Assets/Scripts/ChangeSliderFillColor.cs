using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeSliderFillColor : MonoBehaviour {

	// to place on FillArea -> Fill

	public Color[] colors;
	Image fillImage;

	// Use this for initialization
	void Awake () {
		fillImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeColor (int fillingState) {
		if (fillingState > 0) {
			print(colors[fillingState - 1]);
			fillImage.color = colors[fillingState - 1];
			fillImage.SetAllDirty();
		}
	}
}
