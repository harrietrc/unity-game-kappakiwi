using UnityEngine;
using System.Collections;

public class Achievement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){

		GUI.contentColor = Color.grey;

		GUI.Label (new Rect(Screen.width * 0.1f, Screen.height * 0.2f, Screen.width * 0.8f, Screen.height * 0.1f), "Get 20 points in a single game");

		GUI.Label (new Rect(Screen.width * 0.1f, Screen.height * 0.3f, Screen.width * 0.8f, Screen.height * 0.1f), "Get 40 points in a single game");

		GUI.Label (new Rect(Screen.width * 0.1f, Screen.height * 0.4f, Screen.width * 0.8f, Screen.height * 0.1f), "Get 60 points in a single game");

		GUI.Label (new Rect(Screen.width * 0.1f, Screen.height * 0.5f, Screen.width * 0.8f, Screen.height * 0.1f), "Get 80 points in a single game");

		GUI.Label (new Rect(Screen.width * 0.1f, Screen.height * 0.6f, Screen.width * 0.8f, Screen.height * 0.1f), "Get 100 points in a single game");
		
		if (GUI.Button (new Rect (Screen.width * 0.4f, Screen.height * 0.8f, Screen.width * 0.2f, Screen.height * 0.1f), "Back")) {
			Application.LoadLevel("WelcomeScreen");	
		}
	}
}
