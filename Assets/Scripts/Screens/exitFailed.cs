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
	
	// Use this for initialization
	void Start () {
		Debug.Log (PlayerPrefs.GetInt ("LastScore"));
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

		highScoreNames.Add(PlayerPrefs.GetString ("HighScore1"));
		highScoreNames.Add(PlayerPrefs.GetString ("HighScore2"));
		highScoreNames.Add(PlayerPrefs.GetString ("HighScore3"));
		highScoreNames.Add(PlayerPrefs.GetString ("HighScore4"));
		highScoreNames.Add(PlayerPrefs.GetString ("HighScore5"));
		
		highScores.Add(PlayerPrefs.GetInt (highScoreNames[0]));
		highScores.Add(PlayerPrefs.GetInt (highScoreNames[1]));
		highScores.Add(PlayerPrefs.GetInt (highScoreNames[2]));
		highScores.Add(PlayerPrefs.GetInt (highScoreNames[3]));
		highScores.Add(PlayerPrefs.GetInt (highScoreNames[4]));

		float tempX = 0.7f;
		float tempY = 0.8f;
		GameObject h;
	
		for (int i = 0; i < 5; i++) {
			h = highScoreTextList[i];
			h = new GameObject();
			h.AddComponent<GUIText>();
			h.transform.position = new Vector3(tempX,tempY,0);
			h.guiText.text = (i+1) + ": " + highScoreNames[i] + " " + highScores[i];
			h.guiText.material.color = Color.black;
			tempY -= 0.1f;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){
		GUIStyle style = new GUIStyle (GUI.skin.label);

		style.font = (Font)Resources.Load ("font/Animated");
		style.fontSize = 30;
		style.normal.textColor = Color.black;

		GUI.Label (new Rect(Screen.width * 0.7f, Screen.height * 0.05f, Screen.width * 0.8f, Screen.height * 0.1f), "Highscores", style);

		GUI.Label (new Rect(Screen.width * 0.1f, Screen.height * 0.05f, Screen.width * 0.8f, Screen.height * 0.2f), "Game Over", style);

		float lastscore = PlayerPrefs.GetInt ("LastScore");

		GUI.Label (new Rect (Screen.width * 0.1f, Screen.height * 0.35f, Screen.width * 0.25f, Screen.height * 0.2f), "Last score: " + lastscore, style);

		if (GUI.Button (new Rect (Screen.width * 0.35f, Screen.height * 0.75f, Screen.width * 0.2f, Screen.height * 0.1f), "Try again", style)) {
			Application.LoadLevel ("levelSelection");
		}

		if (GUI.Button (new Rect (Screen.width * 0.65f, Screen.height * 0.75f, Screen.width * 0.2f, Screen.height * 0.1f), "Back to menu", style)) {
			Application.LoadLevel("WelcomeScreen");		
		}


	}

}
