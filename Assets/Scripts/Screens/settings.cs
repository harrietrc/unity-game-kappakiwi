using UnityEngine;
using System.Collections;

public class settings : MonoBehaviour
{

		private Vector2 scrollViewVector = Vector2.zero;
		public static string[] list = {"Standard", "Christmas"};
		public Texture2D[] dropdownImages;
		int indexNumber;
		bool show = false;
		
		// GUI Texture used to fade in and out screen
		public GUITexture screenFader;
		// Fade in/out speed of scree
		public float fadeSpeed = 0.8f;
		// To determine fade from black to clear
		private bool sceneStarting = true;
		// To determine fade from clear to black
		private bool sceneEnding = false;
		// String to determine which playScreen to go
		private string destination = "";

		private void Update ()
		{
				// Handle mouseclick
				if (Input.GetMouseButtonDown (0)) {
						CastRay ();
				}
			// Fade to clear if scene is starting
			if (sceneStarting) {
				StartScene();		
			}
			// Fade to black if scene ending
			if (sceneEnding) {
				EndScene ();		
			}
		}

		// Set up the gui texture
		void Awake ()
		{
			// Set the texture so that it is the the size of the screen and covers it.
			screenFader.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		}

		private void CastRay ()
		{
				// Get the ray casted by the mouse (Current position) when the mouse is clicked
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
				// Figure out what object the ray collided with
				RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);

				if (hit) {
					if (hit.collider.gameObject.name == "back-to-menu") {
						sceneEnding=true;
						destination = "Welcome";
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

	// Fading from black to clear
	void FadeToClear ()
	{
		// Lerp the colour of the texture between itself and transparent.
		screenFader.color = Color.Lerp(screenFader.color, Color.clear, fadeSpeed * Time.deltaTime);
	}
	
	// Fading from clear to black
	void FadeToBlack ()
	{
		// Lerp the colour of the texture between itself and black.
		screenFader.color = Color.Lerp(screenFader.color, Color.black, fadeSpeed * Time.deltaTime);
	}
	
	// Method to call fading from black to clear
	void StartScene ()
	{
		// Fade the texture to clear.
		FadeToClear();
		// If the texture is almost clear...
		if(screenFader.color.a <= 0.01f)
		{
			// ... set the colour to clear and disable the GUITexture.
			screenFader.color = Color.clear;
			screenFader.enabled = false;
			
			// The scene is no longer starting.
			sceneStarting = false;
		}
	}
	
	//Method to call fading from clear to black
	public void EndScene ()
	{
		// Make sure the texture is enabled.
		screenFader.enabled = true;
		
		// Start fading towards black.
		FadeToBlack();
		// If the screen is almost black...
		if (screenFader.color.a >= 0.45f) {
			// ... reload the level.
			sceneEnding = false;
			if(destination == "Welcome"){
				Application.LoadLevel ("WelcomeScreen");
			}
		}
	}
		
}
