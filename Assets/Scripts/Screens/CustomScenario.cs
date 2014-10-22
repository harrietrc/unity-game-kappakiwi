using UnityEngine;
using System.Collections;

public class CustomScenario : MonoBehaviour
{
		private Vector2 scrollViewVector = Vector2.zero;
		public static string[] levelLengthList = {"Short", "Medium", "Long"}; // These could be taken out but have been left here for readability / possible use later
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
								LevelSelection.CURRENT_GAMEMODE = GameMode.scenario;
								Application.LoadLevel ("scn_scenario");
						}

						if (hit.collider.gameObject.name == "back") {
							Application.LoadLevel ("LevelSelection");
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
				Rect dropDownRect = new Rect (Screen.width * 0.6f, Screen.height * 0.26f, 200, 250);
				int height = 40;
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
					DifficultyManager.Instance.CURRENT_LEVELLENGTH = DifficultyManager.LevelLength.low;
				} else if (levelLengthIndex == 1) {
					DifficultyManager.Instance.CURRENT_LEVELLENGTH = DifficultyManager.LevelLength.medium;
				} else if (levelLengthIndex == 2) {
					DifficultyManager.Instance.CURRENT_LEVELLENGTH = DifficultyManager.LevelLength.high;
				}
		}

		private void enemyCount ()
		{
				Rect dropDownRect = new Rect (Screen.width * 0.6f, Screen.height * 0.39f, 200, 250);
				int height = 40;
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
					DifficultyManager.Instance.CURRENT_ENEMYCOUNT = DifficultyManager.EnemyCount.low;
				} else if (enemyCountIndex == 1) {
					DifficultyManager.Instance.CURRENT_ENEMYCOUNT = DifficultyManager.EnemyCount.medium;
				} else if (enemyCountIndex == 2) {
					DifficultyManager.Instance.CURRENT_ENEMYCOUNT = DifficultyManager.EnemyCount.high;
				}
		}

		private void itemCount ()
		{
				Rect dropDownRect = new Rect (Screen.width * 0.6f, Screen.height * 0.52f, 200, 250);
				int height = 40;
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
					DifficultyManager.Instance.CURRENT_ITEMCOUNT = DifficultyManager.ItemCount.low;
				} else if (itemCountIndex == 1) {
					DifficultyManager.Instance.CURRENT_ITEMCOUNT = DifficultyManager.ItemCount.medium;
				} else if (itemCountIndex == 2) {
					DifficultyManager.Instance.CURRENT_ITEMCOUNT = DifficultyManager.ItemCount.high;
				}
		}

		private void difficulty ()
		{

				Rect dropDownRect = new Rect (Screen.width * 0.6f, Screen.height * 0.65f, 200, 250);
				int height = 40;
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
					DifficultyManager.Instance.CURRENT_DIFFICULTY = DifficultyManager.Difficulty.easy;
				} else if (difficultyIndex == 1) {
					DifficultyManager.Instance.CURRENT_DIFFICULTY = DifficultyManager.Difficulty.medium;
				} else if (difficultyIndex == 2) {
					DifficultyManager.Instance.CURRENT_DIFFICULTY = DifficultyManager.Difficulty.hard;
				}
		}
}
