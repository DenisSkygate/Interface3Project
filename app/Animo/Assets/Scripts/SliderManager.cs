using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;

public class SliderManager : MonoBehaviour {

	int currentState;
	Slider slider;
    
    [System.Serializable]
    public class OnColorUpdate : UnityEvent<int> {

    }
    public OnColorUpdate onColorUpdate;

	// Use this for initialization
	void Awake () {
		slider = GetComponent<Slider>();
		currentState = (int)slider.value;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentState != slider.value) {
			currentState = (int)slider.value;
			UpdateColor();
		}
	}

	public void UpdateColor () {
		onColorUpdate.Invoke(currentState);
	}

	void GetCurrentStressLevel () {
		if (PlayerPrefs.HasKey("Stress")) {
			UpdateStressLevel(PlayerPrefs.GetFloat("Stress"));
		} else {
			print("No stress level in PlayerPrefs");
		}
	}

	public void UpdateStressLevel (float stress) {
		float stressValue = stress * slider.maxValue / 100;
		slider.value = Mathf.Min(stressValue, (int) stressValue);
	}
}
