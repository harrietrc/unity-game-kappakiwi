using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AchievementScreen : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI(){

		AchievementManager am = new AchievementManager ();
		List<Achievement> al = am.getAchievements ();
		GUIStyle style = new GUIStyle (GUI.skin.label);

		style.normal.textColor = Color.blue;

		float highscore = PlayerPrefs.GetFloat ("HighScore");

		GUI.Label (new Rect (Screen.width * 0.1f, Screen.height * 0.05f, Screen.width * 0.8f, Screen.height * 0.1f), "High score: " + highscore, style);

		//Building GUILabel of all achievements
		for (int i = 0; i <=4; i++) {
			Rect tempRect = new Rect (Screen.width * 0.1f, Screen.height * (0.1f * (i+2)), Screen.width * 0.8f, Screen.height * 0.1f);
			
			if (PlayerPrefs.GetInt(al[i].getKey()) == 1) {
				style.normal.textColor = Color.blue;
			}else{
				style.normal.textColor = Color.grey;
			}

			GUI.Label (tempRect, al[i].getKey (), style);

		}

		style.normal.textColor = Color.white;
		
		if (GUI.Button (new Rect (Screen.width * 0.4f, Screen.height * 0.8f, Screen.width * 0.2f, Screen.height * 0.1f), "Back")) {
			Application.LoadLevel("WelcomeScreen");	
		}
	}
}
