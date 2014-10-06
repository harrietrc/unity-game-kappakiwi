using UnityEngine;
using System.Collections;

public class exitSuccess : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.skin.label.fontSize = 30;
		
		GUI.skin.label.alignment = TextAnchor.LowerCenter;
		
		GUI.Label (new Rect(Screen.width * 0.1f, Screen.height * 0.05f, Screen.width * 0.8f, Screen.height * 0.2f), "Congratulations, you have passed this level!");
		
		GUI.Label (new Rect (Screen.width * 0.1f, Screen.height * 0.35f, Screen.width * 0.25f, Screen.height * 0.2f), "Your score: ");
		
		GUI.Button (new Rect(Screen.width * 0.15f, Screen.height * 0.7f, Screen.width * 0.2f, Screen.height * 0.1f), "Try again");
		
		GUI.Button (new Rect(Screen.width * 0.65f, Screen.height * 0.7f, Screen.width * 0.2f, Screen.height * 0.1f), "Next level");

		GUI.Button (new Rect(Screen.width * 0.4f, Screen.height * 0.85f, Screen.width * 0.2f, Screen.height * 0.1f), "Back to menu");

	}
}
