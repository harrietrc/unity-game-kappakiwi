using UnityEngine;
using System.Collections;

public class levelSelection : MonoBehaviour {

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

		GUI.skin.label.fontSize = 30;

		GUI.skin.label.alignment = TextAnchor.LowerCenter;

		if (GUI.Button (new Rect (Screen.width * 0.1f, Screen.height * 0.05f, Screen.width * 0.8f, Screen.height * 0.2f), "Endless", style)) {
			Application.LoadLevel("scn_mock");	
		}

		GUI.Label (new Rect(Screen.width * 0.1f, Screen.height * 0.35f, Screen.width * 0.25f, Screen.height * 0.2f), "Story", style);

		GUI.Label (new Rect(Screen.width * 0.1f, Screen.height * 0.65f, Screen.width * 0.25f, Screen.height * 0.2f), "Xmas", style);

		GUI.Button (new Rect(Screen.width * 0.35f, Screen.height * 0.35f, Screen.width * 0.1f, Screen.height * 0.2f), "1", style);

		GUI.Button (new Rect(Screen.width * 0.55f, Screen.height * 0.35f, Screen.width * 0.1f, Screen.height * 0.2f), "2", style);

		GUI.Button (new Rect(Screen.width * 0.75f, Screen.height * 0.35f, Screen.width * 0.1f, Screen.height * 0.2f), "3", style);

		GUI.Button (new Rect(Screen.width * 0.35f, Screen.height * 0.75f, Screen.width * 0.1f, Screen.height * 0.2f), "1", style);

		GUI.Button (new Rect(Screen.width * 0.55f, Screen.height * 0.75f, Screen.width * 0.1f, Screen.height * 0.2f), "2", style);

		GUI.Button (new Rect(Screen.width * 0.75f, Screen.height * 0.75f, Screen.width * 0.1f, Screen.height * 0.2f), "3", style);

	}
}
