using UnityEngine;
using System.Collections;
/**
 *	The coordinates of the buttons are hard coded at the moment.
 *	This is to be changed later.
 **/
public class levelSelection : MonoBehaviour {

	// Create empty GUIStyle i.e. no characteristics
	private GUIStyle invisible = new GUIStyle();
	
	void OnGUI(){
		// Create an invisible button and handle activity
		if (GUI.Button (new Rect (372, 74, 40, 40), "", invisible)) {
			Application.LoadLevel("level_two");
		}
		// Create an invisible button and handle activity
		if (GUI.Button (new Rect (308, 74, 40, 40), "", invisible)) {
			Application.LoadLevel("level_one");
		}
	}
}
