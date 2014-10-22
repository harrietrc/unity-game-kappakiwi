using UnityEngine;
using System.Collections;

public class PauseScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){

		if (GUI.Button (new Rect (Screen.width * 0.4f, Screen.height * 0.3f, Screen.width * 0.2f, Screen.height * 0.1f), "Resume")) {
			Application.LoadLevel("scn_mock");
		}
		
		if (GUI.Button (new Rect (Screen.width * 0.4f, Screen.height * 0.7f, Screen.width * 0.2f, Screen.height * 0.1f), "Back to menu")) {
			Application.LoadLevel("WelcomeScreen");		
		}
	}
}
