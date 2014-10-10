using UnityEngine;
using System.Collections;

public class settings : MonoBehaviour {
	
	void OnGUI(){
		GUIStyle style = new GUIStyle (GUI.skin.label);
		
		style.font = (Font)Resources.Load ("font/Animated");
		style.fontSize = 30;
		style.normal.textColor = Color.black;
		
		GUI.Label (new Rect(Screen.width * 0.1f, Screen.height * 0.05f, Screen.width * 0.8f, Screen.height * 0.2f), "Game settings", style);
		
		GUI.Label (new Rect (Screen.width * 0.1f, Screen.height * 0.35f, Screen.width * 0.25f, Screen.height * 0.2f), "Current theme:", style);

		if (GUI.Button (new Rect (Screen.width * 0.4f, Screen.height * 0.85f, Screen.width * 0.2f, Screen.height * 0.1f), "Back to menu", style)) {
			Application.LoadLevel("WelcomeScreen");		
		}
		
	}


}
