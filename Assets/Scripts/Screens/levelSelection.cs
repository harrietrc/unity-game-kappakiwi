using UnityEngine;
using System.Collections;
/**
 *	The coordinates of the buttons are hard coded at the moment.
 *	This is to be changed later.
 **/
public class levelSelection : MonoBehaviour {

	// Create empty GUIStyle i.e. no characteristics
	private GUIStyle invisible = new GUIStyle();
	public GameObject playButton;
	// Attach objects on start of script
	void Start(){
	
	}
	void OnGUI(){
		// Create an invisible button and handle activity
		if (GUI.Button (new Rect (400, 30, 100, 50), "ENDLESS")) {
			LevelSelection.CURRENT_GAMEMODE = GameMode.endless;
			Application.LoadLevel("scn_endless");
		}
		if (GUI.Button (new Rect (548, 140, 50, 50), "1", invisible)) {
			LevelSelection.LEVEL = 1;
			Application.LoadLevel("level_one");
		}
		// Create an invisible button and handle activity
		if (GUI.Button (new Rect (655, 140, 50, 50), "2", invisible)) {
			LevelSelection.LEVEL = 2;
			Application.LoadLevel("level_two");
		}
		if (GUI.Button (new Rect (380, 600, 100, 50), "Back")) {
			Application.LoadLevel("WelcomeScreen");		
		}
	}
}
