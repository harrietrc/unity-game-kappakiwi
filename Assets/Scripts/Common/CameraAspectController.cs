﻿using UnityEngine;
using System.Collections;

public class CameraAspectController : MonoBehaviour {
	private float height;
	private float width;
	// Use this for initialization
	void Start()
	{
		Screen.orientation = ScreenOrientation.Portrait;
		width = Screen.width;
		Resolution[] resolutions = Screen.resolutions;

		Camera.main.orthographicSize = (float)10.65 / (float)Screen.width * (float)Screen.height;

		//Screen.SetResolution(resolutions[0].width, resolutions[0].height, true);
		// Switch to the lowest supported fullscreen resolution
		//Screen.SetResolution (resolutions[0].width, resolutions[0].height, true);
	
	}

	// Update is called once per frame
	void Update () {
	
	}
}