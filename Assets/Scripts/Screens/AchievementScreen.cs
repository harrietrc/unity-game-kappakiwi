using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AchievementScreen : MonoBehaviour {
	
	void OnGUI(){

		AchievementManager am = new AchievementManager ();
		List<Achievement> al = am.getAchievements ();
		GUIStyle style = new GUIStyle (GUI.skin.label);
		style.font = (Font)Resources.Load ("font/Animated");
		style.normal.textColor = Color.black;

		float highscore = PlayerPrefs.GetFloat ("HighScore");

		GUI.Label (new Rect (Screen.width * 0.1f, Screen.height * 0.05f, Screen.width * 0.8f, Screen.height * 0.1f), "High score: " + highscore, style);

		//Building GUILabel of all achievements
		for (int i = 0; i <=4; i++) {
			Rect tempRect = new Rect (Screen.width * 0.1f, Screen.height * (0.1f * (i+2)), Screen.width * 0.8f, Screen.height * 0.1f);
			
			if (PlayerPrefs.GetInt(al[i].getKey()) == 1) {
				style.normal.textColor = Color.black;
			}else{
				style.normal.textColor = Color.grey;
			}

			GUI.Label (tempRect, al[i].getKey (), style);

		}

		style.normal.textColor = Color.white;

		GUIStyle styles = new GUIStyle (GUI.skin.label);
		
		styles.font = (Font)Resources.Load ("font/Animated");
		styles.fontSize = 30;
		styles.normal.textColor = Color.black;
		
		if (GUI.Button (new Rect (Screen.width * 0.4f, Screen.height * 0.8f, Screen.width * 0.2f, Screen.height * 0.1f), "Back", styles)) {
			Application.LoadLevel("WelcomeScreen");	
		}
	}
}
