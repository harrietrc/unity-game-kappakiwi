using UnityEngine;
using System.Collections;

public class HealthyFood : Item {

	public Sprite apple;
	public Sprite banana;
	public Sprite carrot;
	public Sprite eggplant;
	public Sprite orange;
	public Sprite pear;
	public Sprite tomato;
	public Sprite watermelon;

	// Use this for initialization
	void Start () {

		SpriteRenderer renderer = GetComponent<SpriteRenderer>();
		int var = Random.Range (0, 80);
		
		if (var < 10) {
			renderer.sprite = apple;
		} else if (var < 20) {
			renderer.sprite =  banana;
		} else if (var < 30) {
			renderer.sprite =  carrot;
		} else if (var < 40) {
			renderer.sprite =  eggplant;
		} else if (var < 50) {
			renderer.sprite =  orange;
		} else if (var < 60) {
			renderer.sprite =  pear;
		} else if (var < 70) {
			renderer.sprite =  tomato;
		} else if (var <= 80) {
			renderer.sprite =  watermelon;
		} 
	
	}
	
	// Update is called once per frame
	void Update () {
		destoryIfOffScreen ();
	}


}
