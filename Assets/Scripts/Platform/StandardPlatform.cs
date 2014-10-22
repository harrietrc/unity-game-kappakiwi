using UnityEngine;
using System.Collections;

public class StandardPlatform : Platform {
	GameObject player;
	PlayerController playerScript;
	// Use this for initialization
	void Start () {
		 player = GameObject.FindGameObjectWithTag(Tags.TAG_PLAYER);
		 playerScript = (PlayerController) player.GetComponent(typeof(PlayerController));

	}
	
	// Update is called once per frame
	void Update () {
		destoryIfOffScreen ();
	}

	void OnBecameVisible() {
		playerScript.addPlatformToList(gameObject);

	}
	
	void OnBecameInvisible() {
		playerScript.removePlatformToList(gameObject);
	}
}
