using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AchievementScreen : MonoBehaviour {

	// GUI Texture used to fade in and out screen
	public GUITexture screenFader;
	// Fade in/out speed of scree
	public float fadeSpeed = 1f;
	// To determine fade from black to clear
	private bool sceneStarting = true;
	// To determine fade from clear to black
	private bool sceneEnding = false;
	// String to determine which playScreen to go
	private string destination = "";
	
	void Start(){
		Screen.orientation = ScreenOrientation.Portrait;
		// Get the aspect ratio of the current screen
		float screenProp = (float)Screen.width / (float)Screen.height;
		
		// Change the size of the background image
		SpriteRenderer backgroundImg = GetComponent<SpriteRenderer> ();
		float newSize = (16f/9f) *screenProp; 
		backgroundImg.transform.localScale = new Vector3 (newSize, 1, 1);
		
	}

	void Update(){
		// Handle mouseclick
		if (Input.GetMouseButtonDown (0)) {
				CastRay ();
		}
		// Fade to clear if scene is starting
		if (sceneStarting) {
			StartScene();		
		}
		// Fade to black if scene ending
		if (sceneEnding) {
			EndScene ();		
		}
	}
	// Set up the gui texture
	void Awake ()
	{
		// Set the texture so that it is the the size of the screen and covers it.
		screenFader.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
	}
	
	void CastRay() {
		// Get the ray casted by the mouse (Current position) when the mouse is clicked
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		// Figure out what object the ray collided with
		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
		
		
		if (hit) {
			if (hit.collider.gameObject.name == "Menu"){
				//Application.LoadLevel ("LevelSelection");
				sceneEnding = true;
				destination = "Welcome";
			}
		}
	}
	// Fading from black to clear
	void FadeToClear ()
	{
		// Lerp the colour of the texture between itself and transparent.
		screenFader.color = Color.Lerp(screenFader.color, Color.clear, fadeSpeed * Time.deltaTime);
	}
	
	// Fading from clear to black
	void FadeToBlack ()
	{
		// Lerp the colour of the texture between itself and black.
		screenFader.color = Color.Lerp(screenFader.color, Color.black, fadeSpeed * Time.deltaTime);
	}
	
	// Method to call fading from black to clear
	void StartScene ()
	{
		// Fade the texture to clear.
		FadeToClear();
		// If the texture is almost clear...
		if(screenFader.color.a <= 0.01f)
		{
			// ... set the colour to clear and disable the GUITexture.
			screenFader.color = Color.clear;
			screenFader.enabled = false;
			
			// The scene is no longer starting.
			sceneStarting = false;
		}
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
			if(destination == "Welcome"){
				Application.LoadLevel ("WelcomeScreen");
			}
		}
	}

	void OnGUI(){

		AchievementManager am = new AchievementManager ();
		List<Achievement> al = am.getAchievements ();
		GUIStyle style = new GUIStyle (GUI.skin.label);
		style.font = (Font)Resources.Load ("font/Animated");
		style.normal.textColor = Color.black;
		style.fontSize = 32;
		float highscore = PlayerPrefs.GetFloat ("HighScore");

		GUI.Label (new Rect (Screen.width * 0.1f, Screen.height * 0.05f, Screen.width * 0.8f, Screen.height * 0.1f), "High score: " + highscore, style);

		//Building GUILabel of all achievements
		for (int i = 0; i <=4; i++) {
			Rect tempRect = new Rect (Screen.width * 0.1f, Screen.height * (0.1f * (i+2)), Screen.width * 0.8f, Screen.height * 0.1f);
			
			if (PlayerPrefs.GetInt(al[i].getKey()) == 1) {
				style.normal.textColor = Color.black;
				GUI.Label (tempRect, al[i].getKey () + " ✔", style);
			}else{
				style.normal.textColor = Color.grey;
				GUI.Label (tempRect, al[i].getKey (), style);
			}	

		}

		style.normal.textColor = Color.white;

		GUIStyle styles = new GUIStyle (GUI.skin.label);
		
		styles.font = (Font)Resources.Load ("font/Animated");
		styles.fontSize = 32;
		styles.normal.textColor = Color.black;
		
		if (GUI.Button (new Rect (Screen.width * 0.4f, Screen.height * 0.8f, Screen.width * 0.2f, Screen.height * 0.1f), "Back", styles)) {
			Application.LoadLevel("WelcomeScreen");	
		}
	}
}
