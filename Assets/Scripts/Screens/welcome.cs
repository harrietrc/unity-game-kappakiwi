using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class welcome : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){

		GUIStyle style = new GUIStyle (GUI.skin.label);

		style.font = (Font)Resources.Load ("font/Animated");
		style.fontSize = 30;
		style.normal.textColor = Color.black;

		if (GUI.Button (new Rect (Screen.width * 0.4f, Screen.height * 0.5f, Screen.width * 0.2f, Screen.height * 0.1f), "Play", style)) {
			Application.LoadLevel("LevelSelection");
		}
		
		if (GUI.Button (new Rect (Screen.width * 0.4f, Screen.height * 0.65f, Screen.width * 0.2f, Screen.height * 0.1f), "Achievement", style)) {
			Application.LoadLevel("scn_achievements");		
		}
		
		GUI.Button (new Rect(Screen.width * 0.4f, Screen.height * 0.8f, Screen.width * 0.2f, Screen.height * 0.1f), "Setting", style);
	}
}
