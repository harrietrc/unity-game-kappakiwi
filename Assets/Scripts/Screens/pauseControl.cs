using UnityEngine;
using System.Collections;

public class pauseControl : MonoBehaviour {
	
	bool pause;
	bool flag;

	void Start() {
		pause = false;
		flag = true;
		Time.timeScale = 1;

	}

	void Awake() {
		pause = false;
		flag = true;
		Time.timeScale = 1;
		
	}
	void Update(){
		// Handle mouseclick
		if (Input.GetMouseButtonDown (0)) {
			CastRay ();
		}
	}
	
	void OnGUI(){
		if (flag == false){
			if (pause == true) {

				GUIStyle style = new GUIStyle (GUI.skin.label);
				
				style.font = (Font)Resources.Load ("font/Animated");
				style.fontSize = 30;
				style.normal.textColor = Color.black;

				GUI.Label (new Rect (Screen.width * 0.2f, Screen.height * 0.1f, Screen.width * 0.6f, Screen.height * 0.4f), "Game Paused", style);
				
				if (GUI.Button (new Rect (Screen.width * 0.3f, Screen.height * 0.6f, Screen.width * 0.4f, Screen.height * 0.1f), "Resume",style)) {
					Time.timeScale = 1;
					flag = true;
				}
				if (GUI.Button (new Rect (Screen.width * 0.3f, Screen.height * 0.8f, Screen.width * 0.4f, Screen.height * 0.1f), "Back to menu", style)) {
					Application.LoadLevel("WelcomeScreen");
				}		
			}
		}
	}
	
	
	void CastRay() {
		// Get the ray casted by the mouse (Current position) when the mouse is clicked
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		// Figure out what object the ray collided with
		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
		
		
		if (hit) {
			if (hit.collider.gameObject.name == "pauseButton"){
				Debug.Log ("Pause Clicked");
				Time.timeScale = 0;
				pause = true;
				flag = false;
			}
		}
	}
	
}
