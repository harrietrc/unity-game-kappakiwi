using UnityEngine;
using System.Collections;

public class settings : MonoBehaviour
{

		private Vector2 scrollViewVector = Vector2.zero;
		public static string[] list = {"Standard", "Christmas"};
		public Texture2D[] dropdownImages;
		int indexNumber;
		bool show = false;

		private void Update ()
		{
				// Handle mouseclick
				if (Input.GetMouseButtonDown (0)) {
						CastRay ();
				}
		}

		private void CastRay ()
		{
				// Get the ray casted by the mouse (Current position) when the mouse is clicked
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
				// Figure out what object the ray collided with
				RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);

				if (hit) {
						if (hit.collider.gameObject.name == "back-to-menu") {
								Application.LoadLevel ("WelcomeScreen");
						}
				}
		}

		private void OnGUI ()
		{

				//ResizeBackground (); // Fit the background to the screen

				GUI.backgroundColor = new Color (0, 0, 0, 0); // Hide the rectangles for buttons
				GUIStyle style = new GUIStyle (GUI.skin.label);
		
				style.font = (Font)Resources.Load ("font/Animated");
				style.fontSize = 30;
				style.normal.textColor = Color.black;

				//DROPDOWN FOR THEME SELECT BEGINS HERE

				switch (LevelSelection.CURRENT_THEME) {
				case Theme.story:
						indexNumber = 0;
						break;
				case Theme.xmas:
						indexNumber = 1;
						break;
				}
				
				Rect dropDownRect = new Rect (Screen.width * 0.4f, Screen.height * 0.25f, 400, 500);
				int height = 150;
				if (GUI.Button (new Rect ((dropDownRect.x - 5), dropDownRect.y, dropDownRect.width, height), "")) {
						if (!show) {
								show = true;
						} else {
								show = false;
						}
				}
		
				if (show) {
						scrollViewVector = GUI.BeginScrollView (new Rect ((dropDownRect.x - 5), (dropDownRect.y + height), dropDownRect.width, dropDownRect.height), scrollViewVector, new Rect (0, 0, dropDownRect.width, Mathf.Max (dropDownRect.height, (list.Length * height))));
			
						GUI.Box (new Rect (0, 0, dropDownRect.width, Mathf.Max (dropDownRect.height, (list.Length * height))), "");
			
						for (int index = 0; index < list.Length; index++) {
				
								if (GUI.Button (new Rect (0, (index * height), dropDownRect.height, height), "")) {
										show = false;
										indexNumber = index;
								}
				
								GUI.Label (new Rect (5, (index * height), dropDownRect.height, height), dropdownImages [index], style);
				
						}
			
						GUI.EndScrollView ();   
				} else {
						GUI.Label (new Rect ((dropDownRect.x), dropDownRect.y, 300, height), dropdownImages [indexNumber], style);
				}

				if (indexNumber == 0) {
						LevelSelection.CURRENT_THEME = Theme.story;
				} else if (indexNumber == 1) {
						LevelSelection.CURRENT_THEME = Theme.xmas;
				}
		
		}
}
