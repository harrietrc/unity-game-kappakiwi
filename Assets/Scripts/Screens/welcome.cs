using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class welcome : MonoBehaviour {
	
	// Attach the gameobject in the inspector
	public GameObject playBtn, settingsBtn;
	public bool canMute;
	void Start(){
		Screen.orientation = ScreenOrientation.Portrait;
		canMute = true;
		// Get the aspect ratio of the current screen
		float screenProp = (float)Screen.width / (float)Screen.height;

		// Change the size of the background image
		SpriteRenderer backgroundImg = GetComponent<SpriteRenderer> ();
		float newSize = (16f/9f) *screenProp; 
		backgroundImg.transform.localScale = new Vector3 (newSize, 1, 1);

		// Change the size and position of the play and settings button
		playBtn.transform.localScale = new Vector3 (newSize, 1, 1);
		settingsBtn.transform.localScale = new Vector3 (newSize, 1, 1);
	}

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
				Application.LoadLevel ("scn_settings");
			}

			if (hit.collider.gameObject.name == "soundButton"){
				if (canMute){
					AudioListener.pause = true;
					canMute = false;
				} else {
					AudioListener.pause = false;
					canMute = true;
				}
			}
		}
	}
}