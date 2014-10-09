using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class welcome : MonoBehaviour {

	// Create empty GUIStyle i.e. no characteristics
	private GUIStyle invisible = new GUIStyle();

	void OnGUI(){
		// Create an invisible button and handle activity
		if (GUI.Button (new Rect (397, 360, 100, 50), "", invisible)) {
			Application.LoadLevel("levelSelection");
		}
		// Create an invisible button and handle activity
		if (GUI.Button (new Rect (392, 580, 250, 33), "", invisible)) {
			Application.LoadLevel("scn_achievements");
		}
	}
}
