using UnityEngine;
using System.Collections;

public class pauseControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		DesktopInput ();
	}

	void DesktopInput(){
		if (Input.GetMouseButton (0)) {
			Application.LoadLevel("PauseScreen");		
		}
	}
	
}
