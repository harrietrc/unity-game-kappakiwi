using UnityEngine;
using System.Collections;

public class settings : MonoBehaviour
{

		private Vector2 scrollViewVector = Vector2.zero;
		public static string[] themeList = {"Standard", "Christmas"}; // These could be taken out but have been left here for readability / possible use later
		public static string[] endlessDifficultyList = {"Low", "Medium", "High"};
		public Texture2D[] themeImages;
		public Texture2D[] endlessDifficultyImages;
		int themeIndex;
		int endlessDifficultyIndex;
		bool showTheme = false;
		bool showEndlessDifficulty = false;

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

				GUI.backgroundColor = new Color (0, 0, 0, 0); // Hide the rectangles for buttons

				//DROPDOWN FOR THEME SELECT BEGINS HERE

				switch (LevelSelection.CURRENT_THEME) {
				case Theme.story:
						themeIndex = 0;
						break;
				case Theme.xmas:
						themeIndex = 1;
						break;
				}
				
				theme (); // Theme dropdown
				endlessDifficulty ();
		}

		private void theme ()
		{
				Rect dropDownRect = new Rect (Screen.width * 0.4f, Screen.height * 0.25f, 400, 500);
				int height = 150;
				if (GUI.Button (new Rect ((dropDownRect.x - 5), dropDownRect.y, dropDownRect.width, height), "")) {
						if (!showTheme) {
								showTheme = true;
						} else {
								showTheme = false;
						}
				}
		
				if (showTheme) {
						scrollViewVector = GUI.BeginScrollView (new Rect ((dropDownRect.x - 5), (dropDownRect.y + height), dropDownRect.width, dropDownRect.height), scrollViewVector, new Rect (0, 0, dropDownRect.width, Mathf.Max (dropDownRect.height, (themeList.Length * height))));
			
						GUI.Box (new Rect (0, 0, dropDownRect.width, Mathf.Max (dropDownRect.height, (themeList.Length * height))), "");
			
						for (int index = 0; index < themeList.Length; index++) {
				
								if (GUI.Button (new Rect (0, (index * height), dropDownRect.height, height), "")) {
										showTheme = false;
										themeIndex = index;
								}
				
								GUI.Label (new Rect (5, (index * height), dropDownRect.height, height), themeImages [index]);
				
						}
			
						GUI.EndScrollView ();   
				} else {
						GUI.Label (new Rect ((dropDownRect.x), dropDownRect.y, 300, height), themeImages [themeIndex]);
				}
		
				if (themeIndex == 0) {
						LevelSelection.CURRENT_THEME = Theme.story;
				} else if (themeIndex == 1) {
						LevelSelection.CURRENT_THEME = Theme.xmas;
				}
		}

		private void endlessDifficulty ()
		{
				Rect dropDownRect = new Rect (Screen.width * 0.4f, Screen.height * 0.45f, 400, 500);
				int height = 75;
				if (GUI.Button (new Rect ((dropDownRect.x - 5), dropDownRect.y, dropDownRect.width, height), "")) {
						if (!showEndlessDifficulty) {
								showEndlessDifficulty = true;
						} else {
								showEndlessDifficulty = false;
						}
				}
		
				if (showEndlessDifficulty) {
						scrollViewVector = GUI.BeginScrollView (new Rect ((dropDownRect.x - 5), (dropDownRect.y + height), dropDownRect.width, dropDownRect.height), scrollViewVector, new Rect (0, 0, dropDownRect.width, Mathf.Max (dropDownRect.height, (endlessDifficultyList.Length * height))));
			
						GUI.Box (new Rect (0, 0, dropDownRect.width, Mathf.Max (dropDownRect.height, (themeList.Length * height))), "");
			
						for (int index = 0; index < endlessDifficultyList.Length; index++) {
				
								if (GUI.Button (new Rect (0, (index * height), dropDownRect.height, height), "")) {
										showEndlessDifficulty = false;
										endlessDifficultyIndex = index;
								}
				
								GUI.Label (new Rect (5, (index * height), dropDownRect.height, height), endlessDifficultyImages [index]);
				
						}
			
						GUI.EndScrollView ();   
				} else {
						GUI.Label (new Rect ((dropDownRect.x), dropDownRect.y, 300, height), endlessDifficultyImages [endlessDifficultyIndex]);
				}
		
				if (endlessDifficultyIndex == 0) {
						// Easy
						Debug.Log("Easy: not implemented");
				} else if (endlessDifficultyIndex == 1) {
						// Medium
						Debug.Log("Medium: not implemented");
				} else if (endlessDifficultyIndex == 2) {
						// Hard
						Debug.Log("Hard: not implemented");
				}
		}
}
