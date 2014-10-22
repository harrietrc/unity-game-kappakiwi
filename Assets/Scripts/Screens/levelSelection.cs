using UnityEngine;
using System.Collections;
/**
 *	The coordinates of the buttons are hard coded at the moment.
 *	This is to be changed later.
 **/
public class levelSelection : MonoBehaviour {

	public GameObject playBtn, settingsButn;
	public bool canMute;

	void Update(){
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
			Debug.Log (ray);
		}
	}
}
