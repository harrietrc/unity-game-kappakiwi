using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class exitFailed : MonoBehaviour {

	private PlayerStatus playerStatus = new PlayerStatus();

	private GameObject highscoretext1;
	private GameObject highscoretext2;
	private GameObject highscoretext3;
	private GameObject highscoretext4;
	private GameObject highscoretext5;
	private List<GameObject> highScoreTextList = new List<GameObject>();
	private List<int> highScores = new List<int>() ;
	private List<string> highScoreNames = new List<string>();
	
	private GameObject textfield;
	private string name;
	private string currentKey;

	// GUI Texture used to fade in and out screen
	public GUITexture screenFader;
	// Fade in/out speed of scree
	public float fadeSpeed = 1f;
	// To determine fade from clear to black
	private bool sceneEnding = false;
	// String to determine which playScreen to go
	private string destination = "";
	public GameObject tryAgain, menu;
	// Use this for initialization
	void Start () {

		if (PlayerPrefs.GetString ("LoadedLevel") == "scn_endless") {
			currentKey = "EndlessHigh";
		} else {
			currentKey = "HighScore";
		}

		playerStatus.score.setScore(PlayerPrefs.GetInt ("LastScore"));
		name = PlayerPrefs.GetString ("NewName");
		playerStatus.makeHighScoreList ();
		playerStatus.displayHighScoreList ();
		playerStatus.updateHighScoreList (this.name);
		playerStatus.displayHighScoreList ();
		playerStatus.saveHighScoresToPersistence ();

		highScoreTextList.Add (highscoretext1);
		highScoreTextList.Add (highscoretext2);
		highScoreTextList.Add (highscoretext3);
		highScoreTextList.Add (highscoretext4);
		highScoreTextList.Add (highscoretext5);

		highScoreNames.Add(PlayerPrefs.GetString (currentKey + "1"));
		highScoreNames.Add(PlayerPrefs.GetString (currentKey + "2"));
		highScoreNames.Add(PlayerPrefs.GetString (currentKey + "3"));
		highScoreNames.Add(PlayerPrefs.GetString (currentKey + "4"));
		highScoreNames.Add(PlayerPrefs.GetString (currentKey + "5"));
		
		highScores.Add(PlayerPrefs.GetInt (highScoreNames[0]));
		highScores.Add(PlayerPrefs.GetInt (highScoreNames[1]));
		highScores.Add(PlayerPrefs.GetInt (highScoreNames[2]));
		highScores.Add(PlayerPrefs.GetInt (highScoreNames[3]));
		highScores.Add(PlayerPrefs.GetInt (highScoreNames[4]));

		GameObject h;
		float tempY = Screen.height * 0.25f;
		GUIStyle style = new GUIStyle ();
		GUI.color = Color.black;
		style.alignment = TextAnchor.UpperCenter;
		for (int i = 0; i < 5; i++) {
			h = highScoreTextList[i];
			h = new GameObject();
			h.AddComponent<GUIText>();
		}
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
		if (Input.GetMouseButtonDown (0)) {
			CastRay ();
		}
		if (sceneEnding) {
			EndScene ();		
		}
	}

	void OnGUI(){

		float lastscore = PlayerPrefs.GetInt ("LastScore");

		float tempY = Screen.height * 0.25f;
		GUIStyle style = new GUIStyle ();
		GUI.color = Color.black;
		style.alignment = TextAnchor.UpperCenter;
		style.fontSize = 52;

		for (int i = 0; i < 5; i++) {
			GUI.Label (new Rect (Screen.width*0.2f, tempY, Screen.width*0.6f, 50), (i+1) + ":   " + highScoreNames[i] + "   " + highScores[i], style);
			tempY += Screen.height*0.05f;
		}

		GUI.Label (new Rect(Screen.width* 0.2f, Screen.height*0.8f, Screen.width*0.6f, 50), lastscore.ToString (), style);
//		if (GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.75f, Screen.width * 0.2f, Screen.height * 0.25f), "Try again", titleStyle)) {
//			Application.LoadLevel ("levelSelection");
//		}
//
//		if (GUI.Button (new Rect (Screen.width * 0.55f, Screen.height * 0.75f, Screen.width * 0.2f, Screen.height * 0.25f), "Back to menu", titleStyle)) {
//			Application.LoadLevel("WelcomeScreen");		
//		}

	}
	void CastRay(){
		// Get the ray casted by the mouse (Current position) when the mouse is clicked
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		// Figure out what object the ray collided with
		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
		
		
		if (hit) {
			if (hit.collider.gameObject.name == "try_again") {
					Debug.Log ("Play Clicked");
					//Application.LoadLevel ("LevelSelection");
					sceneEnding = true;
					destination = "levelSelect";
			}
	
			if (hit.collider.gameObject.name == "Menu") {
					Debug.Log ("Settings Clicked");
					sceneEnding = true;
					destination = "welcome";
					//Application.LoadLevel ("scn_settings");
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
			if(destination == "welcome"){
				Application.LoadLevel ("WelComeScreen");
			}else if(destination == "levelSelect"){
				Application.LoadLevel ("levelSelection");
			}
		}
	}

}
