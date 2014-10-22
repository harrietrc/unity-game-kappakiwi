using UnityEngine;
using System.Collections;


public class CameraAspectController : MonoBehaviour
{
		private float height;
		private float width;

	private bool enabled = true;
		// Use this for initialization
		void Start ()
		{
				if (enabled) {
					
						Screen.orientation = ScreenOrientation.Portrait;
								
								
						float aspectRatio = Screen.width / Screen.height;
						
						float orthoWidth = ((float)Screen.height / 2) / ((float)Screen.height / 100 * (float)Screen.width / 100);
						print ("orthoWidth: " + orthoWidth);
						Camera.main.orthographicSize = orthoWidth / (float)Screen.width * (float)Screen.height;
				}
		}
}