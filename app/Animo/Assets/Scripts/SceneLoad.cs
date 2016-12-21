using UnityEngine;
using System.Collections;

public class SceneLoad : MonoBehaviour {

	public Canvas uiCanvas;
	public Transform[] canvasChild;

	// Use this for initialization
	void Start () {
		canvasChild= uiCanvas.GetComponentsInChildren<Transform>();


		foreach (Transform child in canvasChild){

		child.position-=Vector3.right * 663;
		}
	

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
