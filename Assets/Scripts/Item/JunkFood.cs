using UnityEngine;
using System.Collections;

public class JunkFood : Item {

	public Sprite burger;
	public Sprite candy;
	public Sprite chocolate;
	public Sprite cupcake;

	// Use this for initialization
	void Start () {

		SpriteRenderer renderer = GetComponent<SpriteRenderer>();
		int var = 25; // Random.Range (0, 40);

		if (var < 10) {
			renderer.sprite = burger;
				} else if (var < 20) {
			renderer.sprite =  candy;
				} else if (var < 30) {
			renderer.sprite =  chocolate;
				} else if (var <= 40) {
			renderer.sprite =  cupcake;
				}
	}
	
	// Update is called once per frame
	void Update () {

		destoryIfOffScreen ();
	
	}
}
