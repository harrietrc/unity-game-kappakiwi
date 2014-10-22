using UnityEngine;
using System.Collections;

public class HighScoreScript : MonoBehaviour {

	private string name = "Enter name";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {

		GUIStyle style = new GUIStyle (GUI.skin.label);
		style.font = (Font)Resources.Load ("font/Animated");
		style.fontSize = 24;
		style.normal.textColor = Color.black;



		GUI.Label (new Rect(Screen.width * 0.35f, Screen.height * 0.05f, Screen.width * 0.8f, Screen.height * 0.2f), "New Highscore!", style);
		GUI.Label (new Rect(Screen.width * 0.35f, Screen.height * 0.20f, Screen.width * 0.8f, Screen.height * 0.2f), PlayerPrefs.GetInt ("LastScore").ToString (), style);

		this.name = GUI.TextField (new Rect (Screen.width * 0.35f, Screen.height * 0.35f, Screen.width * 0.3f, Screen.height * 0.1f), name, 10);

		PlayerPrefs.SetString ("NewName", this.name);

		Debug.Log (PlayerPrefs.GetString ("NewName"));

		if (GUI.Button (new Rect (300, 150, 300, 50), "Continue")) {


			if (PlayerPrefs.GetInt ("Finished") == 0) {
				Application.LoadLevel("exitFailed");
			}else if (PlayerPrefs.GetInt ("Finished") == 1){
				Application.LoadLevel("exitSuccess");
			}
		}
	}
}
