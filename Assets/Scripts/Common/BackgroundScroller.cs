using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq; // For Enumerable.Repeat()

/**
 * Class with methods and data to help with making the backgrounds in a game scene load in
 * the correct order. Should be attached to background prefab. Does not deal with shifting
 * the prefabs - that's ScreenShifter's job.
 */
public class BackgroundScroller : MonoBehaviour {

	/* All of the backgrounds that could conceivably repeat are arrays (rather than single sprites) for the sake  
	   of modifiability - i.e. new backgrounds/variations can be added later if wanted. All the ones that are not
	   arrays do not make sense to repeat. These ones could have been set by using the name of the texture file, 
	   but creating fields instead means that the textures can be swapped out later without touching this code. */

	public Sprite ground; 
	public List<Sprite> day;
	public List<Sprite> clouds;
	public Sprite dayTransition; 
	public Sprite nightTransition;
	public Sprite night; // Padding around the moon
	public Sprite moon;
	public Sprite spaceTransition;
	public List<Sprite> space; // Will basically be the space between any celestial objects (constant)
	public Sprite mars;
	public Sprite asteroidBelt;
	public Sprite jupiter;
	public Sprite saturn;
	public Sprite uranus;
	public Sprite neptune;
	public Sprite kuiperBelt;
	// And then endless space - backgroundsComplete will stop here, and we can switch into a space loop.

	/* Set how many repetitions of each of the repeatable backgrounds there should be. E.g. setting
	   cloudRepetitions to 5 will mean there will be 5 cloud backgrounds total, not 5 of each of the
	   different cloud backgrounds. */
	public int dayRepetitions;
	public int cloudsRepetitions;
	public int spaceRepetitions; // Space between each celestial object (planets, asteroid belt, etc.)

	private List<Sprite> backgroundList; // Populated with all the backgrounds in the correct order
									 	 // and with the correct number of repetitions based on fields.

	private int spriteIndex; // Keeps track of which background to use from the background list
	private SpriteRenderer spriteRenderer;	

	private bool isVisible; // True if the background prefab is visible. OnBecomeInvisible doesn't seem to work.

	// Use this for initialization
	private void Start () {
		backgroundList = new List<Sprite> ();
		initialiseBackgroundList ();
		spriteRenderer = renderer as SpriteRenderer;
		spriteIndex = 0;
		isVisible = spriteRenderer.isVisible;
		spriteRenderer.sprite = backgroundList [0];
	}
	
	// Update is called once per frame
	private void Update () {

	}

	// Changes the sprite of the GameObject this script is attached to to the one two down on the list
	// Ideally this wouldn't be called from outside this script but OnBecameInvisible() isn't working for me.
	public void nextBackground () {
		spriteIndex ++;
		if (spriteIndex < backgroundList.Count) {
			spriteRenderer.sprite = backgroundList [spriteIndex];
		} else { // Endless space
			spriteRenderer.sprite = space[spriteIndex % space.Count];
		}
	}

	// Changes the sprite of the GameObject to the one two up on the list
	// Not currenty used, as ScreenShifter only shifts things downwards.
	// Incomplete anyway
	public void previousBackground () {
		spriteIndex--;
		spriteRenderer.sprite = backgroundList [spriteIndex];
	}

	// Populates the array of backgrounds for the level. Stops at the Kuiper Belt (need to infinitely generate space separately)
	private void initialiseBackgroundList () {

		// Add everything from ground to the beginning of space
		backgroundList.Add(ground); 
		backgroundList.AddRange (loopArray (day, dayRepetitions));
		backgroundList.AddRange (loopArray (clouds, cloudsRepetitions));
		backgroundList.AddRange (new List<Sprite> () {dayTransition, nightTransition, night, moon, night, spaceTransition});

		Sprite[] celestObjs = {mars, asteroidBelt, jupiter, saturn, uranus, neptune, kuiperBelt};

		// Add the planets & other space stuff with space backgrounds in between
		foreach (Sprite cObj in celestObjs) {
			backgroundList.AddRange (loopArray (space, spaceRepetitions));
			backgroundList.Add(cObj);
		}

		// Take alternate backgrounds based on which of the 2 gameobjects this is attached to
		if (gameObject.tag == Tags.TAG_BACKGROUND_ONE) {
			backgroundList = backgroundList.Where ((s, i) => i%2 ==  0).ToList();
		} else {
			backgroundList = backgroundList.Where ((s, i) => i%2 ==  1).ToList();
		}

	}

	// Takes an array of sprites and loops/repeats it until the specified length is reached.
	private List<Sprite> loopArray (List<Sprite> sprites, int length) {
		int numSprites = sprites.Count;
		List<Sprite> looped = new List<Sprite>();
		int repetitions = numSprites / length;
		int extraElements = numSprites % length;

		// Repeat sprites array. Should still work if sprites array is shorter than specified length.
		for (int i = 0; i < repetitions; i++) {
			looped.AddRange(sprites);
		}

		// Add extra elements
		looped.AddRange(new List<Sprite>(sprites.Take(extraElements)));

		return looped;               
	}
}
