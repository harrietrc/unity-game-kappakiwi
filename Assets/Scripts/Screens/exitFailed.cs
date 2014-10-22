using UnityEngine;
using System.Collections;

public class exitFailed : MonoBehaviour {

	private PlayerStatus playerStatus = new PlayerStatus();

	private GameObject highscoretext1;
	private GameObject highscoretext2;
	private GameObject highscoretext3;
	private GameObject highscoretext4;
	private GameObject highscoretext5;
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
	}
	
	// Update is called once per frame
	void Update () {
		//if (this.name != null) {
		//	playerStatus.updateHighScoreList (this.name);
		//}

		//this.name = GUI.TextField (new Rect (Screen.width * 0.35f, Screen.height * 0.35f, Screen.width * 0.8f, Screen.height * 0.2f), name, 25, scoreStyle);

		string hiName1 = PlayerPrefs.GetString ("HighScore1");
		int highscore1 = PlayerPrefs.GetInt (hiName1);
		string hiName2 = PlayerPrefs.GetString ("HighScore2");
		int highscore2 = PlayerPrefs.GetInt (hiName2);
		string hiName3 = PlayerPrefs.GetString ("HighScore3");
		int highscore3 = PlayerPrefs.GetInt (hiName3);
		string hiName4 = PlayerPrefs.GetString ("HighScore4");
		int highscore4 = PlayerPrefs.GetInt (hiName4);
		string hiName5 = PlayerPrefs.GetString ("HighScore5");
		int highscore5 = PlayerPrefs.GetInt (hiName5);

		if (highscoretext1 == null) {
			highscoretext1 = new GameObject ();
			highscoretext1.AddComponent<GUIText> ();
			highscoretext1.transform.position = new Vector3 (0.5f, 0.9f, 0);
			highscoretext1.guiText.text = "1: " + hiName1 + " " + highscore1;
			highscoretext1.guiText.material.color = Color.black;
		}

		if (highscoretext2 == null) {
			highscoretext2 = new GameObject ();
			highscoretext2.AddComponent<GUIText> ();
			highscoretext2.transform.position = new Vector3 (0.5f, 0.8f, 0);
			highscoretext2.guiText.text = "2: " + hiName2 + " " + highscore2;
			highscoretext2.guiText.material.color = Color.black;
		}

		if (highscoretext3 == null) {
			highscoretext3 = new GameObject ();
			highscoretext3.AddComponent<GUIText> ();
			highscoretext3.transform.position = new Vector3 (0.5f, 0.7f, 0);
			highscoretext3.guiText.text = "3: " + hiName3 + " " + highscore3;
			highscoretext3.guiText.material.color = Color.black;
		}

		if (highscoretext4 == null) {
			highscoretext4 = new GameObject ();
			highscoretext4.AddComponent<GUIText> ();
			highscoretext4.transform.position = new Vector3 (0.5f, 0.6f, 0);
			highscoretext4.guiText.text = "4: " + hiName4 + " " + highscore4;
			highscoretext4.guiText.material.color = Color.black;
		}

		if (highscoretext5 == null) {
			highscoretext5 = new GameObject ();
			highscoretext5.AddComponent<GUIText> ();
			highscoretext5.transform.position = new Vector3 (0.5f, 0.5f, 0);
			highscoretext5.guiText.text = "5: " + hiName5 + " " + highscore5;
			highscoretext5.guiText.material.color = Color.black;
		}
	}

	void OnGUI(){
		GUIStyle style = new GUIStyle (GUI.skin.label);

		style.font = (Font)Resources.Load ("font/Animated");
		style.fontSize = 30;
		style.normal.textColor = Color.black;

		GUIStyle scoreStyle = new GUIStyle (GUI.skin.label);
		
		scoreStyle.font = (Font)Resources.Load ("font/Animated");
		scoreStyle.fontSize = 12;
		scoreStyle.normal.textColor = Color.black;

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
