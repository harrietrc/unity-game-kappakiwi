using UnityEngine;
using System.Collections;
using System;

public class ScreenShifter : MonoBehaviour {

	private GameObject[] platforms;
	private GameObject[] items;
	private GameObject[] obstacles;
	private GameObject[] enemies;
	private GameObject[] vegetables;
	private GameObject[] candy;
	private GameObject player;
	private GameObject flag;	
	private GameObject backgroundOne; // At most two backgrounds will be shown on screen at once, as 
	private GameObject backgroundTwo; // the height of each background is the same as the screen height.
	private BackgroundScroller backgroundOneScroller;
	private BackgroundScroller backgroundTwoScroller;
	private float speed;

	public ScreenShifter() {

	}

	public void ShiftScreen(float shiftAmount){

		speed = shiftAmount;
		platforms = GameObject.FindGameObjectsWithTag(Tags.TAG_PLATFORM);
		items = GameObject.FindGameObjectsWithTag(Tags.TAG_ITEM);
		enemies = GameObject.FindGameObjectsWithTag(Tags.TAG_ENEMY);
		obstacles = GameObject.FindGameObjectsWithTag(Tags.TAG_OBSTACLE);
		candy = GameObject.FindGameObjectsWithTag(Tags.TAG_CANDY);
		vegetables = GameObject.FindGameObjectsWithTag(Tags.TAG_VEGETABLE);
		flag = GameObject.FindGameObjectWithTag(Tags.TAG_FLAG);
		player = GameObject.FindGameObjectWithTag (Tags.TAG_PLAYER);
		backgroundOne = GameObject.FindGameObjectWithTag (Tags.TAG_BACKGROUND_ONE);
		backgroundTwo = GameObject.FindGameObjectWithTag (Tags.TAG_BACKGROUND_TWO);
		
		initBackground ();
		
		for (int i = 0; i < platforms.Length; i++) {
			if(platforms[i] != null){
				platforms[i].transform.Translate(new Vector3(0,speed,0));
			}
		}
		for (int i = 0; i < items.Length; i++) {
			if(items[i] != null){
				items[i].transform.Translate(new Vector3(0,speed,0));
			}
		}
		for (int i = 0; i < enemies.Length; i++) {
			if(enemies[i] != null){
				enemies[i].transform.Translate(new Vector3(0,speed,0));
			}
		}
		for (int i = 0; i < obstacles.Length; i++) {
			if(obstacles[i] != null){
				obstacles[i].transform.Translate(new Vector3(0,speed,0));
			}
		}
		for (int i =0; i< candy.Length; i++ ) {
			if(candy[i] != null){
				candy[i].transform.Translate(new Vector3(0,speed,0));
			}
		}
		for (int i =0; i< vegetables.Length; i++ ) {
			if(vegetables[i] != null){
				vegetables[i].transform.Translate(new Vector3(0,speed,0));
			}
		}
		player.transform.Translate(new Vector3(0,speed,0));
		if (flag != null) {
						flag.transform.Translate (new Vector3 (0, speed, 0));
				}

		/* Code for background scrolling. See BackgroundScroller class. */
		if (backgroundOne != null && backgroundTwo != null) { // They work as a pair so they both gotta be there
			backgroundOne.transform.Translate (new Vector3 (0, speed, 0));
			backgroundTwo.transform.Translate (new Vector3 (0, speed, 0));

			double yOne = backgroundOne.transform.position.y;
			double yTwo = backgroundTwo.transform.position.y;
			
			// It would be better to do this using OnBecameInvisible() in the BackgroundScroller script but the
			// isVisible property isn't working as expected. This implementation is not ideal because it is
			// dependent on a background height of 42 and means having a public method in a script.
			if ((Math.Round (yOne) != 0) && yOne < 0 && Math.Round (yOne - speed, 1) % 42 == 0) { // Messy; can probably be simplified
				shiftBackground(backgroundOne, backgroundOneScroller);
			} else if ((Math.Round (yTwo) != 0) && yTwo < 0 && Math.Round (yTwo - speed, 1) % 42 == 0) {
				shiftBackground(backgroundTwo, backgroundTwoScroller);
			}
		}
	}

	/* Shifts the background up and changes its sprite. */
	private void shiftBackground (GameObject background, BackgroundScroller scroller) {
		scroller.nextBackground ();
		Vector3 pos = background.transform.position; // Need temp variable because you can't change position.y directly
		pos.y = (int)pos.y; // Drop any decimals it's picked up
		pos.y += 84; // Push it 2 screen heights up
		background.transform.position = pos;
	}

	private void initBackground () {
		backgroundOne = GameObject.FindGameObjectWithTag (Tags.TAG_BACKGROUND_ONE);
		backgroundTwo = GameObject.FindGameObjectWithTag (Tags.TAG_BACKGROUND_TWO);
		backgroundOneScroller = (BackgroundScroller)backgroundOne.GetComponent (typeof(BackgroundScroller));
		backgroundTwoScroller = (BackgroundScroller)backgroundTwo.GetComponent (typeof(BackgroundScroller));
	}
}