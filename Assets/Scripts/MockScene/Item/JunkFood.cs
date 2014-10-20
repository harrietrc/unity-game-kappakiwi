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

	// Use this for initialization
	void Start () { 
		
		int var = Random.Range (0, 60);

		// Using the standard theme
		if (LevelSelection.CURRENT_THEME == Theme.story) {
			if (var < 10) {
				sprites = burger;
			} else if (var < 20) {
				sprites = candy;
			} else if (var < 30) {
				sprites = chocolate;
			} else if (var < 40) {
				sprites = cupcake;
			} else if (var < 50) {
				sprites = cake;
			} else if (var <= 60) {
				sprites = icecream;
			}
		
		// Using the Christmas theme
		} else if (LevelSelection.CURRENT_THEME == Theme.xmas) {
			if (var < 10) {
				sprites = pavlova;
			} else if (var < 20) {
				sprites = pudding;
			} else if (var < 30) {
				sprites = mincePie;
			} else if (var < 40) {
				sprites = candyCane;
			} else if (var < 50) {
				sprites = cake;
			} else if (var <= 60) {
				sprites = gingerbreadMan;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		destoryIfOffScreen ();
	
	}
}
