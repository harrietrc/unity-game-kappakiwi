using UnityEngine;
﻿using UnityEngine;
using System.Collections;

public class HealthyFood : Item {

	public Sprite[] apple;
	public Sprite[] banana;
	public Sprite[] carrot;
	public Sprite[] eggplant;
	public Sprite[] orange;
	public Sprite[] pear;
	public Sprite[] tomato;
	public Sprite[] watermelon;

	// Christmas reskin
	public Sprite[] redPresent;
	public Sprite[] bluePresent;
	public Sprite[] greenPresent;
	public Sprite[] yellowPresent;
	public Sprite[] darkGreenPresent;
	public Sprite[] purplePresent;
	public Sprite[] pinkPresent;
	public Sprite[] orangePresent;

	private AudioSource itemSound;
	private string[] storySoundLocs = 
	{"Resources/Audio/apple-crunch",
		"Resources/Audio/candy",
		"Resources/Audio/apple-crunch-02",
		"Resources/Audio/apple-munch",
		"Resources/Audio/comic-bite-2",
		"Resources/Audio/celerybite",
		"Resources/Audio/comic-bite-1",
		"Resources/Audio/peach-biting"
	};
	
	private string[] xmasSoundLocs = 
	{"Resources/Audio/nom-bite",
		"Resources/Audio/nom-bite",
		"Resources/Audio/nom-bite2",
		"Resources/Audio/nom-bite",
		"Resources/Audio/nom-bite",
		"Resources/Audio/nom-bite",		
        "Resources/Audio/nom-bite",
        "Resources/Audio/nom-bite" };
	
	private int rnd=0;
	private int loc =0; 

	// Use this for initialization
	void Start () {
		
		int rnd = Random.Range (0, 80);

		// Using the standard theme
		if (LevelSelection.CURRENT_THEME == Theme.story) {
			if (rnd < 10) {
				sprites = apple;
			} else if (rnd < 20) {
				sprites = banana;
			} else if (rnd < 30) {
				sprites = carrot;
			} else if (rnd < 40) {
				sprites = eggplant;
			} else if (rnd < 50) {
				sprites = orange;
			} else if (rnd < 60) {
				sprites = pear;
			} else if (rnd < 70) {
				sprites = tomato;
			} else if (rnd <= 80) {
				sprites = watermelon;
			} 

		// Using the christmas theme
		} else if (LevelSelection.CURRENT_THEME == Theme.xmas) { 
			if (rnd < 10) {
				sprites = redPresent;
			} else if (rnd < 20) {
				sprites = bluePresent;
			} else if (rnd < 30) {
				sprites = greenPresent;
			} else if (rnd < 40) {
				sprites = yellowPresent;
			} else if (rnd < 50) {
				sprites = orangePresent;
			} else if (rnd < 60) {
				sprites = darkGreenPresent;
			} else if (rnd < 70) {
				sprites = purplePresent;
			} else if (rnd <= 80) {
				sprites = pinkPresent;
			} 
		}
	}
	
	// Update is called once per frame
	void Update () {
		destoryIfOffScreen ();
	}

	/* This function creates sound spcefic to the item is created when collides with player
	 * Sound clip file locations are kept in xmasSoundLocs[], and storySoundLocs[] arrays
	 * location of a sound file is related also with the random numbber created
	 * to get the index rnd / 10 to get the array index
	 */
	void OnCollisionEnter2D (Collision2D col2d) {
		if (col2d.gameObject.tag == "player" ) {
			// to find sound file location in the storySoundLocs
			loc = rnd / 10;
			
			if (LevelSelection.CURRENT_THEME == Theme.story) {
				
				//under if colliding with something player
				itemSound = gameObject.AddComponent<AudioSource>();
				
				//get the item sound file under the project
				// for example, "Resource/Audio/simple-gulp" below for location path
				itemSound.clip = Resources.Load(storySoundLocs[loc]) as AudioClip;
				Debug.Log("Junk food sound play for story location:" + loc + " --Niyazi");
				itemSound.Play();
				
				Destroy(itemSound);
			}
			if (LevelSelection.CURRENT_THEME == Theme.xmas) {
				
				//under if colliding with something player
				itemSound = gameObject.AddComponent<AudioSource>();
				
				//get the item sound file under the project
				// for example, "Resource/Audio/simple-gulp" below for location path
				itemSound.clip = Resources.Load(xmasSoundLocs[loc]) as AudioClip;
				Debug.Log("Junk food sound play for xmas location:" + loc + " --Niyazi");
				itemSound.Play();
				
				Destroy(itemSound);
			}
		}
	}
}
