using UnityEngine;
using System.Collections;

public class exitFailed : MonoBehaviour {

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

		GUI.Label (new Rect(Screen.width * 0.1f, Screen.height * 0.05f, Screen.width * 0.8f, Screen.height * 0.2f), "Game Over", style);

		float highscore = PlayerPrefs.GetFloat ("HighScore");
		//Debug.Log ("highscore from playerprefs was " + highscore);

		GUI.Label (new Rect (Screen.width * 0.1f, Screen.height * 0.35f, Screen.width * 0.25f, Screen.height * 0.2f), "High score: " + highscore, style);

		if (GUI.Button (new Rect (Screen.width * 0.35f, Screen.height * 0.75f, Screen.width * 0.2f, Screen.height * 0.1f), "Try again", style)) {
			Application.LoadLevel ("levelSelection");
		}

		if (GUI.Button (new Rect (Screen.width * 0.65f, Screen.height * 0.75f, Screen.width * 0.2f, Screen.height * 0.1f), "Back to menu", style)) {
			Application.LoadLevel("WelcomeScreen");		
		}


	}

}
