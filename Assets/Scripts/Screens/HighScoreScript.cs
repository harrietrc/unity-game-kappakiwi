using UnityEngine;
using System.Collections;

public class HighScoreScript : MonoBehaviour {

	private string name = "enter";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		GUIStyle scoreStyle = new GUIStyle (GUI.skin.label);
		
		scoreStyle.font = (Font)Resources.Load ("font/Animated");
		scoreStyle.fontSize = 12;
		scoreStyle.normal.textColor = Color.black;

		this.name = GUI.TextField (new Rect (Screen.width * 0.35f, Screen.height * 0.35f, Screen.width * 0.8f, Screen.height * 0.2f), name, 25, scoreStyle);

		PlayerPrefs.SetString ("NewName", this.name);

		Debug.Log (PlayerPrefs.GetString ("NewName"));

		if (GUI.Button (new Rect (450, 5, 300, 50), "")) {
			Application.LoadLevel("exitFailed");
		}
	}
}
