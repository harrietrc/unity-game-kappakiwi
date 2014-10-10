using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class welcome : MonoBehaviour {
	
	// Attach the gameobject in the inspector
	public GameObject playBtn, settingsButn;

	void Update(){
		// Handle mouseclick
		if (Input.GetMouseButtonDown (0)) {
			CastRay ();
		}
	}

	void CastRay() {
		// Get the ray casted by the mouse (Current position) when the mouse is clicked
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		// Figure out what object the ray collided with
		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);


		if (hit) {
			if (hit.collider.gameObject.name == "playButton"){
				Debug.Log ("Play Clicked");
				Application.LoadLevel ("LevelSelection");
			}
			if (hit.collider.gameObject.name == "settingsButton"){
				Debug.Log ("Settings Clicked");
				//Application.LoadLevel ("scn_settings");
			}
		}
	}
}
