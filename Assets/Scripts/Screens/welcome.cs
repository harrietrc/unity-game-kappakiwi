using UnityEngine;
using System.Collections;

public class welcome : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.skin.label.fontSize = 30;
		
		GUI.skin.label.alignment = TextAnchor.LowerCenter;
		
		GUI.Label (new Rect(Screen.width * 0.1f, Screen.height * 0.05f, Screen.width * 0.8f, Screen.height * 0.4f), "Kappa Kiwi");
		
		if (GUI.Button (new Rect (Screen.width * 0.4f, Screen.height * 0.5f, Screen.width * 0.2f, Screen.height * 0.1f), "Play")) {
			Application.LoadLevel("LevelSelection");		
		}
		
		GUI.Button (new Rect(Screen.width * 0.4f, Screen.height * 0.65f, Screen.width * 0.2f, Screen.height * 0.1f), "Achievement");
		
		GUI.Button (new Rect(Screen.width * 0.4f, Screen.height * 0.8f, Screen.width * 0.2f, Screen.height * 0.1f), "Setting");
	}
}
