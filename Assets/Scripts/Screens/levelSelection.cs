using UnityEngine;
using System.Collections;
﻿using UnityEngine;
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

	private void Update(){
		// Handle mouseclick
		if (Input.GetMouseButtonDown (0)) {
			CastRay ();
		}
	}

	private void CastRay () {
		// Get the ray casted by the mouse (Current position) when the mouse is clicked
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		// Figure out what object the ray collided with
		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
		
		if (hit) {
			if (hit.collider.gameObject.name == "1"){
				LevelSelection.LEVEL = 1;
				LevelSelection.CURRENT_GAMEMODE = GameMode.story;
				Application.LoadLevel ("level_one");
				Debug.Log("yes");
			}
			
			if (hit.collider.gameObject.name == "2"){
				LevelSelection.LEVEL = 2;
				LevelSelection.CURRENT_GAMEMODE = GameMode.story;
				Application.LoadLevel ("level_two");
			}
			
			if (hit.collider.gameObject.name == "3"){
				LevelSelection.LEVEL = 3;
				LevelSelection.CURRENT_GAMEMODE = GameMode.story;
				Application.LoadLevel ("level_three");
			}

			if (hit.collider.gameObject.name == "endless-label"){
				LevelSelection.CURRENT_GAMEMODE = GameMode.endless;
				Application.LoadLevel ("scn_endless");
			}

			if (hit.collider.gameObject.name == "back-to-menu"){
				Application.LoadLevel ("WelcomeScreen");
			}
		}
	}
}
