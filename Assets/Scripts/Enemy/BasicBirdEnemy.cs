﻿using UnityEngine;
using System.Collections;

public class BasicBirdEnemy : Enemy {

	int moveSpeed = 5;
	int touches = 0;

	float vertExtent;
	float horzExtent;

	float width;
	float height;

	bool isDead = false;

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = new Vector2(moveSpeed, 0); // assigning the speed at the start
	}
	 
	// Update is called once per frame
	void Update () {

		vertExtent = Camera.main.camera.orthographicSize;
		horzExtent = vertExtent * Screen.width / Screen.height; 

		width = renderer.bounds.size.x / 2 + 0.5f; 
		height = renderer.bounds.size.y / 2 + 0.5f;

		if( !isDead ) {
			handleBirdMovement();
			handleTouchCollisions();
		}

		destoryIfOffScreen ();

	}


	// handles user touching screen
	void handleTouchCollisions() {
		if (Input.touchCount > 0) { // if user has touched the screen

			touches = Input.touchCount; 
			var touch = Input.GetTouch (touches - 1); // getting the last touch
			var touchPos = Camera.main.ScreenToWorldPoint (touch.position); // converting to correct co-ord system

			// if user touches the gameObject
			if (touchPos.x > (transform.position.x - width) && touchPos.x < (width + transform.position.x)) {
				if (touchPos.y > (transform.position.y - height) && touchPos.y < (height + transform.position.y)) {
					handleDeath();
				}
			}
		}

	}

	// handles the bird movement
	void handleBirdMovement() {

		if (transform.position.x < (horzExtent * -1 + width)) 
		{
			rigidbody2D.velocity = new Vector2(moveSpeed,0);	
		} else if ( transform.position.x > (horzExtent - width)) 
		{
			rigidbody2D.velocity = new Vector2(- 1 * moveSpeed,0);	
			
		}
	}

	void handleDeath() {
		Destroy(gameObject);
	}

	void OnCollisionEnter2D(Collision2D col) {

		if (col.gameObject.name == "KiwiBird") {
		// if player is above alien, kill alien and make player jump.
			if (col.gameObject.transform.position.y > gameObject.transform.position.y) {
				Destroy(gameObject)	;
		
				PlayerController other = (PlayerController) col.gameObject.GetComponent(typeof(PlayerController));
				other.boostPlayer(); // making the player jump
			} else {
				rigidbody2D.velocity = new Vector2(moveSpeed, 0); // assigning the speed at the start
			}
		}
	}
}

























