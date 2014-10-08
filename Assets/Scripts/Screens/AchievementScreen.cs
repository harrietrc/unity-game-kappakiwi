using UnityEngine;
using System.Collections;

public class AchievementScreen : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI(){

		GUIStyle lockedStyle = new GUIStyle (GUI.skin.label);
		lockedStyle.normal.textColor = Color.black;
		
		GUIStyle unlockedStyle = new GUIStyle (GUI.skin.label);
		unlockedStyle.normal.textColor = Color.white;

		float highscore = PlayerPrefs.GetFloat ("HighScore");

		GUI.Label (new Rect (Screen.width * 0.1f, Screen.height * 0.05f, Screen.width * 0.8f, Screen.height * 0.1f), "High score: " + highscore, unlockedStyle);

		if (PlayerPrefs.GetInt ("Bounced on 20 platforms!") == 1) {
			GUI.Label (new Rect (Screen.width * 0.1f, Screen.height * 0.2f, Screen.width * 0.8f, Screen.height * 0.1f), "Get 20 points in a single game", unlockedStyle);
			Debug.Log ("Here at white");
		} else {
			GUI.Label (new Rect (Screen.width * 0.1f, Screen.height * 0.2f, Screen.width * 0.8f, Screen.height * 0.1f), "Get 20 points in a single game", lockedStyle);
			Debug.Log ("Here at grey");
		}

		if (PlayerPrefs.GetInt ("Bounced on 40 platforms!") == 1) {
			GUI.Label (new Rect (Screen.width * 0.1f, Screen.height * 0.3f, Screen.width * 0.8f, Screen.height * 0.1f), "Get 40 points in a single game", unlockedStyle);
			Debug.Log ("Here at white");
		} else {
			GUI.Label (new Rect (Screen.width * 0.1f, Screen.height * 0.3f, Screen.width * 0.8f, Screen.height * 0.1f), "Get 40 points in a single game", lockedStyle);
			Debug.Log ("Here at grey");
		}	

		if (PlayerPrefs.GetInt ("Bounced on 60 platforms!") == 1) {
			GUI.Label (new Rect (Screen.width * 0.1f, Screen.height * 0.4f, Screen.width * 0.8f, Screen.height * 0.1f), "Get 60 points in a single game", unlockedStyle);
			Debug.Log ("Here at white");
		} else {
			GUI.Label (new Rect (Screen.width * 0.1f, Screen.height * 0.4f, Screen.width * 0.8f, Screen.height * 0.1f), "Get 60 points in a single game", lockedStyle);
			Debug.Log ("Here at grey");
		}	

		if (PlayerPrefs.GetInt ("Bounced on 80 platforms!") == 1) {
			GUI.Label (new Rect (Screen.width * 0.1f, Screen.height * 0.5f, Screen.width * 0.8f, Screen.height * 0.1f), "Get 80 points in a single game", unlockedStyle);
			Debug.Log ("Here at white");
		} else {
			GUI.Label (new Rect (Screen.width * 0.1f, Screen.height * 0.5f, Screen.width * 0.8f, Screen.height * 0.1f), "Get 80 points in a single game", lockedStyle);
			Debug.Log ("Here at grey");
		}	

		if (PlayerPrefs.GetInt ("Bounced on 100 platforms!") == 1) {
			GUI.Label (new Rect (Screen.width * 0.1f, Screen.height * 0.6f, Screen.width * 0.8f, Screen.height * 0.1f), "Get 100 points in a single game", unlockedStyle);
			Debug.Log ("Here at white");
		} else {
			GUI.Label (new Rect (Screen.width * 0.1f, Screen.height * 0.6f, Screen.width * 0.8f, Screen.height * 0.1f), "Get 100 points in a single game", lockedStyle);
			Debug.Log ("Here at grey");
		}	
		
		if (GUI.Button (new Rect (Screen.width * 0.4f, Screen.height * 0.8f, Screen.width * 0.2f, Screen.height * 0.1f), "Back")) {
			Application.LoadLevel("WelcomeScreen");	
		}
	}
}
