using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class welcome : MonoBehaviour {

	// Create empty GUIStyle i.e. no characteristics
	private GUIStyle invisible = new GUIStyle();

	void OnGUI(){
		// Create an invisible button and handle activity
		if (GUI.Button (new Rect (225, 210, 62, 25), "", invisible)) {
			Application.LoadLevel("levelSelection");
		}
		// Create an invisible button and handle activity
		if (GUI.Button (new Rect (225, 240, 85, 23), "", invisible)) {
			Application.LoadLevel("scn_achievements");
		}
	}
}
