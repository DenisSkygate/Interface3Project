using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class StressManager : MonoBehaviour {

	public bool newGame = false;
    
    [System.Serializable]
    public class OnStressLevelUpdate : UnityEvent<float> {

    }
    public OnStressLevelUpdate onStressLevelUpdate;

	// Use this for initialization
	void Start () {
		if (newGame) {
			InitializeStress();
		} else {
			GetCurrentStressLevel();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void InitializeStress () {
		PlayerPrefs.SetFloat("Stress", 0);
		onStressLevelUpdate.Invoke(PlayerPrefs.GetFloat("Stress"));
	}

	void GetCurrentStressLevel () {
		if (!PlayerPrefs.HasKey("Stress")) {
			PlayerPrefs.SetFloat("Stress", 0);
		}
		onStressLevelUpdate.Invoke(PlayerPrefs.GetFloat("Stress"));
	}

	public void DecreaseStress (float amount) {
		if (amount > 0) {
			float stress = PlayerPrefs.GetFloat("Stress");
			stress -= amount;
			stress = Mathf.Max(stress, 0);
			PlayerPrefs.SetFloat("Stress", stress);
			onStressLevelUpdate.Invoke(stress);
		} else {
			print("Amount to decrease can't be negative");
		}
	}

	public void IncreaseStress (float amount) {
		if (amount > 0) {
			float stress = PlayerPrefs.GetFloat("Stress");
			stress += amount;
			stress = Mathf.Min(stress, 100);
			PlayerPrefs.SetFloat("Stress", stress);
			onStressLevelUpdate.Invoke(stress);
		} else {
			print("Amount to increase can't be negative");
		}
	}
}
