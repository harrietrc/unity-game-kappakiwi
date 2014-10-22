using UnityEngine;
using System.Collections;

public class HighScoreScript : MonoBehaviour {

	private string name = "Enter name";
	public Texture buttonImg;
	// Use this for initialization
	void Start () {
		// Get the aspect ratio of the current screen
		float screenProp = (float)Screen.width / (float)Screen.height;
		// Change the size of the background image
		SpriteRenderer backgroundImg = GetComponent<SpriteRenderer> ();
		float newSize = (16f/9f) *screenProp; 
		backgroundImg.transform.localScale = new Vector3 (newSize, 1, 1);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {

		GUIStyle style = new GUIStyle (GUI.skin.label);
		style.font = (Font)Resources.Load ("font/Arial");
		style.fontSize = 36;
		style.normal.textColor = Color.black;
		style.alignment = TextAnchor.UpperCenter;

		// For displaying score figure
		GUI.Label (new Rect (0, Screen.height * 0.3f, Screen.width, Screen.height * 0.2f), PlayerPrefs.GetInt ("LastScore").ToString (), style);
		this.name = GUI.TextField (new Rect (Screen.width * 0.2f, Screen.height * 0.45f, Screen.width * 0.6f, 20), name, 10);
		
		PlayerPrefs.SetString ("NewName", this.name);

		Debug.Log (PlayerPrefs.GetString ("NewName"));

		// Create and render button to continue
		GUIStyle buttonStyle = new GUIStyle ();
		buttonStyle.fixedWidth = 0;
		buttonStyle.fixedHeight = 0;
		buttonStyle.stretchWidth = true;
		buttonStyle.stretchHeight = true;
		if (GUI.Button (new Rect (Screen.width * 0.2f, Screen.height * 0.8f, Screen.width*0.6f, 50f), buttonImg, buttonStyle)) {
			if (PlayerPrefs.GetInt ("Finished") == 0) {
				Application.LoadLevel("exitFailed");
			}else if (PlayerPrefs.GetInt ("Finished") == 1){
				Application.LoadLevel("exitSuccess");
			}
		}
	}
}
