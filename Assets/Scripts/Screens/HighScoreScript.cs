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
		style.fontSize = 18;
		style.normal.textColor = Color.black;

		GUI.Label (new Rect(Screen.width*0.1f, Screen.height * 0.2f, Screen.width*0.9f, Screen.height * 0.2f), "Your new high score is : ", style);

		this.name = GUI.TextField (new Rect (Screen.width * 0.2f, Screen.height * 0.65f, Screen.width * 0.6f, 20), name, 10);
	
		PlayerPrefs.SetString ("NewName", this.name);

		Debug.Log (PlayerPrefs.GetString ("NewName"));

		if (GUI.Button (new Rect (Screen.width * 0.2f, Screen.height * 0.8f, Screen.width*0.6f, 50), "Continue")) {


			if (PlayerPrefs.GetInt ("Finished") == 0) {
				Application.LoadLevel("exitFailed");
			}else if (PlayerPrefs.GetInt ("Finished") == 1){
				Application.LoadLevel("exitSuccess");
			}
		}
	}
}
