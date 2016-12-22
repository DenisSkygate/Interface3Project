using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour {

	string[] list_name = new string[3];

	void Start(){
		list_name [0] = "ok_skin_1";
		list_name [1] = "ok_skin_2";
		list_name [2] = "ok_skin_3";
	}

	public void OnSkinClick(string skinName){
		for (int i = 0; i < 3; i++) {
			GameObject newSkin = GameObject.Find (list_name [i]);

			if (skinName == list_name [i]) {
				bool ok = newSkin.GetComponent<Image> ().enabled;
				newSkin.GetComponent<Image> ().enabled = !ok;
			} else {
				newSkin.GetComponent<Image> ().enabled = false;
			}
		}
		

	}
}
