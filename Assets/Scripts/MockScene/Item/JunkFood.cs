using UnityEngine;
using System.Collections;

public class JunkFood : Item {

	public Sprite[] burger;
	public Sprite[] candy;
	public Sprite[] chocolate;
	public Sprite[] cupcake;
	public Sprite[] cake;
	public Sprite[] icecream;

	// Use this for initialization
	void Start () { 
		
		int var = Random.Range (0, 60);

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
	}
	
	// Update is called once per frame
	void Update () {

		destoryIfOffScreen ();
	
	}
}
