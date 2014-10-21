using UnityEngine;
using System.Collections;

public class settings : MonoBehaviour {

	private Vector2 scrollViewVector = Vector2.zero;
	public static string[] list = {"Standard", "Christmas"};
	public Texture2D backToMenu;
	public Texture2D title;
	public Texture2D themeLabel;
	public Texture2D[] dropdownImages;

	int indexNumber;
	bool show = false;
	
	void OnGUI(){
				GUI.backgroundColor = new Color(0, 0, 0, 0); // Hide the rectangles for buttons
				GUIStyle style = new GUIStyle (GUI.skin.label);
		
				style.font = (Font)Resources.Load ("font/Animated");
				style.fontSize = 30;
				style.normal.textColor = Color.black;
		
				GUI.Label (new Rect (Screen.width * 0.1f, Screen.height * 0.05f, Screen.width * 0.8f, Screen.height * 0.2f), title);
		
				GUI.Label (new Rect (Screen.width * 0.1f, Screen.height * 0.35f, Screen.width * 0.25f, Screen.height * 0.2f), themeLabel);

				if (GUI.Button (new Rect (Screen.width * 0.3f, Screen.height * 0.85f, Screen.width * 0.4f, Screen.height * 0.2f), backToMenu)) {
						Application.LoadLevel ("WelcomeScreen");		
				}

				//DROPDOWN FOR THEME SELECT BEGINS HERE

				switch (LevelSelection.CURRENT_THEME) {
		case Theme.story:
			indexNumber = 0;
			break;
		case Theme.xmas:
			indexNumber = 1;
			break;
				}
				
				Rect dropDownRect = new Rect (Screen.width * 0.45f, Screen.height * 0.35f, 125, 500);
				int height = 35;
				if (GUI.Button (new Rect ((dropDownRect.x - 100), dropDownRect.y, dropDownRect.width, height), "")) {
						if (!show) {
								show = true;
						} else {
								show = false;
						}
				}
		
				if (show) {
						scrollViewVector = GUI.BeginScrollView (new Rect ((dropDownRect.x - 100), (dropDownRect.y + height), dropDownRect.width, dropDownRect.height), scrollViewVector, new Rect (0, 0, dropDownRect.width, Mathf.Max (dropDownRect.height, (list.Length * height))));
			
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
						GUI.Label (new Rect ((dropDownRect.x - 95), dropDownRect.y, 300, height), dropdownImages [indexNumber], style);
				}

				if (indexNumber == 0) {
					LevelSelection.CURRENT_THEME = Theme.story;
				} else if (indexNumber == 1) {
					LevelSelection.CURRENT_THEME = Theme.xmas;
				}

		
	}


}
