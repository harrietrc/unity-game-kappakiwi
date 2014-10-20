using UnityEngine;
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

	// Use this for initialization
	void Start () {
		
		int var = Random.Range (0, 80);

		// Using the standard theme
		if (LevelSelection.CURRENT_THEME == Theme.story) {
			if (var < 10) {
				sprites = apple;
			} else if (var < 20) {
				sprites = banana;
			} else if (var < 30) {
				sprites = carrot;
			} else if (var < 40) {
				sprites = eggplant;
			} else if (var < 50) {
				sprites = orange;
			} else if (var < 60) {
				sprites = pear;
			} else if (var < 70) {
				sprites = tomato;
			} else if (var <= 80) {
				sprites = watermelon;
			} 

		// Using the christmas theme
		} else if (LevelSelection.CURRENT_THEME == Theme.xmas) { 
			if (var < 10) {
				sprites = redPresent;
			} else if (var < 20) {
				sprites = bluePresent;
			} else if (var < 30) {
				sprites = greenPresent;
			} else if (var < 40) {
				sprites = yellowPresent;
			} else if (var < 50) {
				sprites = orangePresent;
			} else if (var < 60) {
				sprites = darkGreenPresent;
			} else if (var < 70) {
				sprites = purplePresent;
			} else if (var <= 80) {
				sprites = pinkPresent;
			} 
		}
	}
	
	// Update is called once per frame
	void Update () {
		destoryIfOffScreen ();
	}


}
