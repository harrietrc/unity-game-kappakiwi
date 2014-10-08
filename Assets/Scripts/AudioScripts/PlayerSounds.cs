using UnityEngine;
using System.Collections;

public class PlayerSounds : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp("space")) {
			if (!audio.isPlaying) {
				audio.clip = jump;
				audio.Play();
			}
		}
		
		if (Input.GetKey("Left")) {
			if (!audio.isPlaying) {
				audio.clip = bong;
				audio.Play();
			}
		}
	
	}
}
