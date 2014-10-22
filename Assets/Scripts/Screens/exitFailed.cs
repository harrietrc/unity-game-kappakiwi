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

		float tempX = 0.5f;
		float tempY = 0.6f;
		GameObject h;
	
		for (int i = 0; i < 5; i++) {
			h = highScoreTextList[i];
			h = new GameObject();
			h.AddComponent<GUIText>();
			h.transform.position = new Vector3(tempX,tempY,0);
			h.guiText.text = (i+1) + ": " + highScoreNames[i] + " " + highScores[i];
			h.guiText.material.color = Color.black;
			h.guiText.fontSize = 30;
			tempY -= 0.05f;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){
		GUIStyle style = new GUIStyle (GUI.skin.label);

		int styleFontSize = 50;
		int titleFontSize = 60;
		float pixWidth = Camera.main.pixelWidth;
		
		if (Camera.main.pixelWidth < 720) {
			styleFontSize = (int)((float)50 * (float)pixWidth/(float)720);
			titleFontSize = (int)((float)60 * (float)pixWidth/(float)720);
		} else if (Camera.main.pixelHeight < 1024) {
			styleFontSize = (int)((float)50 * (float)pixWidth/(float)1024);
			titleFontSize = (int)((float)60 * (float)pixWidth/(float)1024);
		}

		style.font = (Font)Resources.Load ("font/Animated");
		style.fontSize = 50;
		style.normal.textColor = Color.black;

		GUIStyle titleStyle = new GUIStyle (GUI.skin.label);

		titleStyle.font = (Font)Resources.Load ("font/Animated");
		titleStyle.fontSize = 60;
		titleStyle.normal.textColor = Color.black;

		GUI.Label (new Rect(Screen.width * 0.5f, Screen.height * 0.30f, Screen.width * 0.8f, Screen.height * 0.1f), "Highscores", style);

		GUI.Label (new Rect(Screen.width * 0.30f, Screen.height * 0.05f, Screen.width * 0.8f, Screen.height * 0.2f), "GAME OVER", titleStyle);

		float lastscore = PlayerPrefs.GetInt ("LastScore");

		GUI.Label (new Rect (Screen.width * 0.1f, Screen.height * 0.40f, Screen.width * 0.25f, Screen.height * 0.2f), "Your score: " + lastscore, style);

		if (GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.75f, Screen.width * 0.2f, Screen.height * 0.25f), "Try again", titleStyle)) {
			Application.LoadLevel ("levelSelection");
		}

		if (GUI.Button (new Rect (Screen.width * 0.55f, Screen.height * 0.75f, Screen.width * 0.2f, Screen.height * 0.25f), "Back to menu", titleStyle)) {
			Application.LoadLevel("WelcomeScreen");		
		}


	}

}
