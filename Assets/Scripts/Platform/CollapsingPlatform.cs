using UnityEngine;
using System.Collections;

public class CollapsingPlatform : Platform {
	int count = 1;
	// Use this for initialization
	void Start () {
	
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
