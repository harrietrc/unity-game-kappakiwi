using UnityEngine;
using System.Collections;

public class CameraAspectController : MonoBehaviour {
	private float height;
	private float width;

	private bool enabled = false;
	// Use this for initialization
	void Start()
	{
		if (enabled) {
			
			Screen.orientation = ScreenOrientation.Portrait;
			//width = Screen.width;
			//Resolution[] resolutions = Screen.resolutions;
			
			
			float aspectRatio = Screen.width / Screen.height;
			
			float orthoWidth = ((float)Screen.height/2) / ((float)Screen.height/100 * (float)Screen.width/100);
			print ("orthoWidth: " + orthoWidth);
			//Camera.main.orthographicSize = (float)10.65 / (float)Screen.width * (float)Screen.height;
			//Orthographic width = Orthographic size * aspect
			Camera.main.orthographicSize = orthoWidth / (float)Screen.width * (float)Screen.height;
			//Camera.main.orthographicSize = Screen.height/2;
			
			//Screen.SetResolution (Screen.width, Screen.height, true); GT-I8 becomes 0.6
			
			GUITextSpawner guiTextSpawner = new GUITextSpawner ();
			/*guiTextSpawner.SpawnNew ("Screen size: " + Screen.width + ", " + Screen.height
		                         + "\n Aspect: " + Camera.main.aspect
		                         + "\n orthowidth: " + orthoWidth
		                         + "player world: " + PlayerPrefs.); */
			
			//Resize2 ();
			//Resize ();
			
			//Resolution[] resolutions  = Screen.resolutions;
			// Switch to the lowest supported fullscreen resolution
			//Screen.SetResolution (resolutions[0].width, resolutions[0].height, true);
				}

	
	}

	void Resize()
	{
		if (enabled) {		
			SpriteRenderer sr=GetComponent<SpriteRenderer>();
			if(sr==null) return;
			
			transform.localScale=new Vector3(1,1,1);
			
			float width=sr.sprite.bounds.size.x;
			float height=sr.sprite.bounds.size.y;
			
			
			float worldScreenHeight=Camera.main.orthographicSize*2f;
			float worldScreenWidth=worldScreenHeight/Screen.height*Screen.width;
			
			Vector3 xWidth = transform.localScale;
			xWidth.x=worldScreenWidth / width;
			transform.localScale=xWidth;
			
			Vector3 yHeight = transform.localScale;
			yHeight.y=worldScreenHeight / height;
			transform.localScale=yHeight;
				}


		
	}

	void Resize2() {
		if (enabled) {
			// set the desired aspect ratio (the values in this example are
			// hard-coded for 16:9, but you could make them into public
			// variables instead so you can set them at design time)
			float targetaspect = 9.0f/ 16.0f;
			
			// determine the game window's current aspect ratio
			float windowaspect = (float)Screen.width / (float)Screen.height;
			
			// current viewport height should be scaled by this amount
			float scaleheight = windowaspect / targetaspect;
			
			// obtain camera component so we can modify its viewport
			Camera camera = GetComponent<Camera> ();
			
			// if scaled height is less than current height, add letterbox
			if (scaleheight < 1.0f) {
				Rect rect = camera.rect;
				
				rect.width = 1.0f;
				rect.height = scaleheight;
				rect.x = 0;
				rect.y = (1.0f - scaleheight) / 2.0f;
				
				camera.rect = rect;
			} else { // add pillarbox
				float scalewidth = 1.0f / scaleheight;
				
				Rect rect = camera.rect;
				
				rect.width = scalewidth;
				rect.height = 1.0f;
				rect.x = (1.0f - scalewidth) / 2.0f;
				rect.y = 0;
				
				camera.rect = rect;
			}
				}


	}

	// Update is called once per frame
	void Update () {
	
	}
}
