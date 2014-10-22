using UnityEngine;
using System.Collections;

public class HighScoreScript : MonoBehaviour {

	private string name = "";
	public Texture buttonImg;

	// GUI Texture used to fade in and out screen
	public GUITexture screenFader;
	// Fade in/out speed of scree
	public float fadeSpeed = 1f;
	// To determine fade from clear to black
	private bool sceneEnding = false;
	// String to determine which playScreen to go
	private string destination = "";

	// Use this for initialization
	void Start () {
		// Get the aspect ratio of the current screen
		float screenProp = (float)Screen.width / (float)Screen.height;
		// Change the size of the background image
		SpriteRenderer backgroundImg = GetComponent<SpriteRenderer> ();
		float newSize = (16f/9f) *screenProp; 
		backgroundImg.transform.localScale = new Vector3 (newSize, 1, 1);

	}
	// Set up the gui texture
	void Awake ()
	{
		// Set the texture so that it is the the size of the screen and covers it.
		screenFader.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		screenFader.color = Color.clear;
		screenFader.enabled = false;
	}
	// Update is called once per frame
	void Update () {
		if (sceneEnding) {
			EndScene ();		
		}
		// Fade to clear if scene is starting

	}

	void OnGUI () {

		GUIStyle style = new GUIStyle (GUI.skin.label);
		style.font = (Font)Resources.Load ("font/Arial");
		style.fontSize = 36;
		style.normal.textColor = Color.black;
		style.alignment = TextAnchor.UpperCenter;

		// For displaying score figure
		GUI.Label (new Rect (0, Screen.height * 0.3f, Screen.width, Screen.height * 0.2f), PlayerPrefs.GetInt ("LastScore").ToString (), style);

		this.name = GUI.TextField (new Rect (Screen.width * 0.2f, Screen.height * 0.45f, Screen.width * 0.6f, Screen.height*0.06f), name, 10);
		
		PlayerPrefs.SetString ("NewName", this.name);

		// Create and render button to continue
		GUIStyle buttonStyle = new GUIStyle ();
		buttonStyle.fixedWidth = 0;
		buttonStyle.fixedHeight = 0;
		buttonStyle.stretchWidth = true;
		buttonStyle.stretchHeight = true;
		if (GUI.Button (new Rect (Screen.width*0.2f, Screen.height * 0.8f, Screen.width*0.6f, Screen.height*0.2f), buttonImg, buttonStyle)) {
			if (PlayerPrefs.GetInt ("Finished") == 0) {
				destination = "fail";
				sceneEnding = true;
				//Application.LoadLevel("exitFailed");
			}else if (PlayerPrefs.GetInt ("Finished") == 1){
				destination = "success";
				sceneEnding = true;
				//Application.LoadLevel("exitSuccess");
			}
		}
	}

	// Fading from clear to black
	void FadeToBlack ()
	{
		// Lerp the colour of the texture between itself and black.
		screenFader.color = Color.Lerp(screenFader.color, Color.black, fadeSpeed * Time.deltaTime);
	}
	//Method to call fading from clear to black
	public void EndScene ()
	{
		// Make sure the texture is enabled.
		screenFader.enabled = true;
		// Start fading towards black.
		FadeToBlack();
		// If the screen is almost black...
		if (screenFader.color.a >= 0.45f) {
			// ... reload the level.
			sceneEnding = false;
			if(destination == "fail"){
				Application.LoadLevel ("exitFailed");
			}else if(destination == "success"){
				Application.LoadLevel ("exitSuccess");
			}
		}
	}
}
