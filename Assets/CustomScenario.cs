using UnityEngine;
using System.Collections;

public class CustomScenario : MonoBehaviour
{
		private Vector2 scrollViewVector = Vector2.zero;
		public static string[] levelLengthList = {"Short", "Medium", "Long"};
		public Texture2D[] levelLengthImages;
		public static string[] enemyCountList = {"Low", "Medium", "High"};
		public Texture2D[] enemyCountImages;
		public static string[] itemCountList = {"Low", "Medium", "High"};
		public Texture2D[] itemCountImages;
		public static string[] difficultyList = {"Easy", "Medium", "Hard"};
		public Texture2D[] difficultyImages;
		GUIStyle style;
		private bool showLevelLength = false;
		private bool showItemCount = false;
		private bool showEnemyCount = false;
		private bool showDifficulty = false;
		private int levelLengthIndex;
		private int itemCountIndex;
		private int enemyCountIndex;
		private int difficultyIndex;

		// Use this for initialization
		private void Start ()
		{

		}
	
		// Update is called once per frame
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
						if (hit.collider.gameObject.name == "start-label") {
								Application.LoadLevel ("");
								Debug.Log ("Not implemented");
						}
				}
		}

		private void OnGUI ()
		{
				style = new GUIStyle (GUI.skin.label);
				GUI.backgroundColor = new Color (0, 0, 0, 0); // Hide the rectangles for buttons

				levelLength (); // Dropdown for level length
				enemyCount (); // Dropdown for enemy count 
				itemCount (); // Dropdown for item count 
				difficulty (); // Dropdown for level difficulty
		}

		// Dividing the dropdowns among functions for the sake of sanity and tidier code
		private void levelLength ()
		{
				Rect dropDownRect = new Rect (Screen.width * 0.4f, Screen.height * 0.25f, 200, 250);
				int height = 75;
				if (GUI.Button (new Rect ((dropDownRect.x - 5), dropDownRect.y, dropDownRect.width, height), "")) {
						if (!showLevelLength) {
								showLevelLength = true;
						} else {
								showLevelLength = false;
						}
				}
		
				if (showLevelLength) {
						scrollViewVector = GUI.BeginScrollView (new Rect ((dropDownRect.x - 5), (dropDownRect.y + height), dropDownRect.width, dropDownRect.height), scrollViewVector, new Rect (0, 0, dropDownRect.width, Mathf.Max (dropDownRect.height, (levelLengthList.Length * height))));
			
						GUI.Box (new Rect (0, 0, dropDownRect.width, Mathf.Max (dropDownRect.height, (levelLengthList.Length * height))), "");
			
						for (int index = 0; index < levelLengthList.Length; index++) {
				
								if (GUI.Button (new Rect (0, (index * height), dropDownRect.height, height), "")) {
										showLevelLength = false;
										levelLengthIndex = index;
								}
				
								GUI.Label (new Rect (5, (index * height), dropDownRect.height, height), levelLengthImages [index], style);
				
						}
			
						GUI.EndScrollView ();   
				} else {
						GUI.Label (new Rect ((dropDownRect.x), dropDownRect.y, 300, height), levelLengthImages [levelLengthIndex], style);
				}

				if (levelLengthIndex == 0) {
						// Short
						Debug.Log ("Short: Not yet implemented");
				} else if (levelLengthIndex == 1) {
						// Medium
						Debug.Log ("Medium: Not yet implemented");
				} else if (levelLengthIndex == 2) {
						// Long
						Debug.Log ("Long: Not yet implemented");
				}
		}

		private void enemyCount ()
		{
				Rect dropDownRect = new Rect (Screen.width * 0.4f, Screen.height * 0.35f, 200, 250);
				int height = 75;
				if (GUI.Button (new Rect ((dropDownRect.x - 5), dropDownRect.y, dropDownRect.width, height), "")) {
						if (!showEnemyCount) {
								showEnemyCount = true;
						} else {
								showEnemyCount = false;
						}
				}
				
				if (showEnemyCount) {
						scrollViewVector = GUI.BeginScrollView (new Rect ((dropDownRect.x - 5), (dropDownRect.y + height), dropDownRect.width, dropDownRect.height), scrollViewVector, new Rect (0, 0, dropDownRect.width, Mathf.Max (dropDownRect.height, (enemyCountList.Length * height))));
					
						GUI.Box (new Rect (0, 0, dropDownRect.width, Mathf.Max (dropDownRect.height, (enemyCountList.Length * height))), "");
					
						for (int index = 0; index < enemyCountList.Length; index++) {
						
								if (GUI.Button (new Rect (0, (index * height), dropDownRect.height, height), "")) {
										showEnemyCount = false;
										enemyCountIndex = index;
								}
						
								GUI.Label (new Rect (5, (index * height), dropDownRect.height, height), enemyCountImages [index], style);
						
						}
					
						GUI.EndScrollView ();   
				} else {
						GUI.Label (new Rect ((dropDownRect.x), dropDownRect.y, 300, height), enemyCountImages [enemyCountIndex], style);
				}

				if (enemyCountIndex == 0) {
						// Low
						Debug.Log ("Low: Not yet implemented");
				} else if (enemyCountIndex == 1) {
						// Medium
						Debug.Log ("Medium: Not yet implemented");
				} else if (enemyCountIndex == 2) {
						// High
						Debug.Log ("High: Not yet implemented");
				}
		}

		private void itemCount ()
		{
				Rect dropDownRect = new Rect (Screen.width * 0.4f, Screen.height * 0.45f, 200, 250);
				int height = 75;
				if (GUI.Button (new Rect ((dropDownRect.x - 5), dropDownRect.y, dropDownRect.width, height), "")) {
						if (!showItemCount) {
								showItemCount = true;
						} else {
								showItemCount = false;
						}
				}
			
				if (showItemCount) {
						scrollViewVector = GUI.BeginScrollView (new Rect ((dropDownRect.x - 5), (dropDownRect.y + height), dropDownRect.width, dropDownRect.height), scrollViewVector, new Rect (0, 0, dropDownRect.width, Mathf.Max (dropDownRect.height, (itemCountList.Length * height))));
				
						GUI.Box (new Rect (0, 0, dropDownRect.width, Mathf.Max (dropDownRect.height, (itemCountList.Length * height))), "");
				
						for (int index = 0; index < itemCountList.Length; index++) {
					
								if (GUI.Button (new Rect (0, (index * height), dropDownRect.height, height), "")) {
										showItemCount = false;
										itemCountIndex = index;
								}
					
								GUI.Label (new Rect (5, (index * height), dropDownRect.height, height), itemCountImages [index], style);
					
						}
				
						GUI.EndScrollView ();   
				} else {
						GUI.Label (new Rect ((dropDownRect.x), dropDownRect.y, 300, height), itemCountImages [itemCountIndex], style);
				}

				if (itemCountIndex == 0) {
						// Low
						Debug.Log ("Low: Not yet implemented");
				} else if (itemCountIndex == 1) {
						// Medium
						Debug.Log ("Medium: Not yet implemented");
				} else if (itemCountIndex == 2) {
						// High
						Debug.Log ("High: Not yet implemented");
				}
		}

		private void difficulty ()
		{
				Rect dropDownRect = new Rect (Screen.width * 0.4f, Screen.height * 0.55f, 200, 250);
				int height = 75;
				if (GUI.Button (new Rect ((dropDownRect.x - 5), dropDownRect.y, dropDownRect.width, height), "")) {
						if (!showDifficulty) {
								showDifficulty = true;
						} else {
								showDifficulty = false;
						}
				}
			
				if (showDifficulty) {
						scrollViewVector = GUI.BeginScrollView (new Rect ((dropDownRect.x - 5), (dropDownRect.y + height), dropDownRect.width, dropDownRect.height), scrollViewVector, new Rect (0, 0, dropDownRect.width, Mathf.Max (dropDownRect.height, (difficultyList.Length * height))));
				
						GUI.Box (new Rect (0, 0, dropDownRect.width, Mathf.Max (dropDownRect.height, (difficultyList.Length * height))), "");
				
						for (int index = 0; index < difficultyList.Length; index++) {
					
								if (GUI.Button (new Rect (0, (index * height), dropDownRect.height, height), "")) {
										showDifficulty = false;
										difficultyIndex = index;
								}
					
								GUI.Label (new Rect (5, (index * height), dropDownRect.height, height), difficultyImages [index], style);
					
						}
				
						GUI.EndScrollView ();   
				} else {
						GUI.Label (new Rect ((dropDownRect.x), dropDownRect.y, 300, height), difficultyImages [difficultyIndex], style);
				}

				if (difficultyIndex == 0) {
						// Easy
						Debug.Log ("Easy: Not yet implemented");
				} else if (difficultyIndex == 1) {
						// Medium
						Debug.Log ("Medium: Not yet implemented");
				} else if (difficultyIndex == 2) {
						// Hard
						Debug.Log ("Hard: Not yet implemented");
				}
		}
}
