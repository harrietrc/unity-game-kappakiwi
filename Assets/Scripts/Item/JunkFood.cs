using UnityEngine;
using System.Collections;

public class JunkFood : Item {

	public Sprite[] burger;
	public Sprite[] candy;
	public Sprite[] chocolate;
	public Sprite[] cupcake;
	public Sprite[] cake;
	public Sprite[] icecream;

	// Christmas reskin
	public Sprite[] candyCane;
	public Sprite[] pavlova;
	public Sprite[] pudding;
	public Sprite[] snowmanBiscuit;
	public Sprite[] mincePie;
	public Sprite[] gingerbreadMan;

	private AudioSource itemSound;
	private string[] storySoundLocs = 
	   {"Resources/Audio/vegetable",
	    "Resources/Audio/candy",
		"Resources/Audio/monster-chocolate-crunching",
		"Resources/Audio/comic-bite-1",
		"Resources/Audio/comic-bite-2",
		"Resources/Audio/bite-2"};

	private string[] xmasSoundLocs = 
	{"Resources/Audio/snack-bite-1",
		"Resources/Audio/nom-bite",
		"Resources/Audio/splash-2",
		"Resources/Audio/simple-gulp",
		"Resources/Audio/potato-chip-crunch",
		"Resources/Audio/simple-gulp"};

	private int rnd=0;
	private int loc =0; 

	// Use this for initialization
	void Start () { 
		
		rnd = Random.Range (0, 60);

		// Using the standard theme
		if (LevelSelection.CURRENT_THEME == Theme.story) {
			if (rnd < 10) {
				sprites = burger;
			} else if (rnd < 20) {
				sprites = candy;
			} else if (rnd < 30) {
				sprites = chocolate;
			} else if (rnd < 40) {
				sprites = cupcake;
			} else if (rnd < 50) {
				sprites = cake;
			} else if (rnd <= 60) {
				sprites = icecream;
			}
		
		// Using the Christmas theme
		} else if (LevelSelection.CURRENT_THEME == Theme.xmas) {
			if (rnd < 10) {
				sprites = pavlova;
			} else if (rnd < 20) {
				sprites = pudding;
			} else if (rnd < 30) {
				sprites = mincePie;
			} else if (rnd < 40) {
				sprites = candyCane;
			} else if (rnd < 50) {
				sprites = cake;
			} else if (rnd <= 60) {
				sprites = gingerbreadMan;
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
		if (col2d.gameObject.name == "player" ) {
			// to find sound file location in the storySoundLocs
			loc = rnd / 10;
				
			//under if colliding with something player
			itemSound = gameObject.AddComponent<AudioSource>();
			
			if (LevelSelection.CURRENT_THEME == Theme.story) {
		       //get the item sound file under the project
	    	   // for example, "Resource/Audio/simple-gulp" below for location path
	           itemSound.clip = Resources.Load(storySoundLocs[loc]) as AudioClip;
			   Debug.Log("Junk food sound play for story location:" + loc + " --Niyazi");
		       itemSound.Play();
			   
		       Destroy(itemSound);
		    }
			if (LevelSelection.CURRENT_THEME == Theme.xmas) {
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
