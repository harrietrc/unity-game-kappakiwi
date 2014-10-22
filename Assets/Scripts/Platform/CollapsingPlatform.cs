using UnityEngine;
using System.Collections;

public class CollapsingPlatform : Platform {
	int count = 1;
	GameObject player;
	PlayerController playerScript;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag(Tags.TAG_PLAYER);
		playerScript = (PlayerController) player.GetComponent(typeof(PlayerController));
	}

	void OnBecameVisible() {
		playerScript.addPlatformToList(gameObject);
		
	}
	
	void OnBecameInvisible() {
		playerScript.removePlatformToList(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		destoryIfOffScreen();
	}

	void OnCollisionExit2D(Collision2D col) {
		if (col.gameObject.tag == Tags.TAG_PLAYER) {
			rigidbody2D.velocity = new Vector2(0,-12);
			//var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
			//spriteRenderer.sprite = Resources.Load("Textures/platform/broken_purple", typeof(Sprite)) as Sprite;
		}

	}
}
