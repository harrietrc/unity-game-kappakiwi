using UnityEngine;
using System.Collections;

public class exitSuccess : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUIStyle style = new GUIStyle (GUI.skin.label);
		
		style.font = (Font)Resources.Load ("font/Animated");
		style.fontSize = 30;
		style.normal.textColor = Color.black;
		
		GUI.Label (new Rect(Screen.width * 0.1f, Screen.height * 0.05f, Screen.width * 0.8f, Screen.height * 0.2f), "Congratulations, you have passed this level!", style);
		
		GUI.Label (new Rect (Screen.width * 0.1f, Screen.height * 0.35f, Screen.width * 0.25f, Screen.height * 0.2f), "Your score: ", style);
		
		if (GUI.Button (new Rect (Screen.width * 0.15f, Screen.height * 0.7f, Screen.width * 0.2f, Screen.height * 0.1f), "Play again", style )) {
			ScreenTransitionManager.Instance.loadLevel(LevelSelection.LEVEL,LevelSelection.CURRENT_THEME );
				};
		
		GUI.Button (new Rect(Screen.width * 0.65f, Screen.height * 0.7f, Screen.width * 0.2f, Screen.height * 0.1f), "Next level", style);

		if (GUI.Button (new Rect (Screen.width * 0.4f, Screen.height * 0.85f, Screen.width * 0.2f, Screen.height * 0.1f), "Back to menu", style)) {
			Application.LoadLevel("WelcomeScreen");		
		}

	}


}
