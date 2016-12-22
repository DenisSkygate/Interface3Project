using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour {

	string[] list_name = new string[3];
	private int skin = 0;

	void Start(){
		list_name [0] = "ok_skin_1";
		list_name [1] = "ok_skin_2";
		list_name [2] = "ok_skin_3";
	}

	public void OnSkinClick(string skinName){
		for (int index = 0; index < 3; index++) {
			GameObject newSkin = GameObject.Find (list_name [index]);

			if (skinName == list_name [index]) {
				newSkin.GetComponent<Image> ().enabled = true;
				skin = index;
				PlayerPrefs.SetInt ("skin", skin);

				print ("skin: " + PlayerPrefs.GetInt("skin"));

			} else {
				newSkin.GetComponent<Image> ().enabled = false;
			}
		}
		

	}
}
