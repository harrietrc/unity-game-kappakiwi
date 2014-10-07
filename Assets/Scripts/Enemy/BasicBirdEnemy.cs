﻿using UnityEngine;
using System.Collections;

public class BasicBirdEnemy : Enemy {

	int moveSpeed = 5;
	int touches = 0;

	// Use this for initialization
	void Start () {
		//rigidbody2D.velocity = new Vector2(moveSpeed, 0); // assigning the speed at the start
	}
	 
	// Update is called once per frame
	void Update () {

		var vertExtent = Camera.main.camera.orthographicSize;
		// horzExtent will be the horizontal screen size devided by 2  
		var horzExtent = vertExtent * Screen.width / Screen.height; // converting the world values to camera values

		float width = renderer.bounds.size.x / 2; // half width of the gameObject
		float height = renderer.bounds.size.y / 2 + 1;
		if (transform.position.x < (horzExtent * -1 + width)) 
		{
			rigidbody2D.velocity = new Vector2(moveSpeed,0);	
		} else if ( transform.position.x > (horzExtent - width)) 
		{
			rigidbody2D.velocity = new Vector2(- 1 * moveSpeed,0);	

		}


		if (Input.touchCount > 0) {
			touches = Input.touchCount;
			var touch = Input.GetTouch (touches - 1);
			var touchPos = Camera.main.ScreenToWorldPoint (touch.position);
			if (touchPos.x > (transform.position.x - width) && touchPos.x < (width + transform.position.x)) {
				if (touchPos.y > (transform.position.y - height) && touchPos.y < (height + transform.position.y)) {
					Destroy (gameObject);
				}
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col) {

	}
}
