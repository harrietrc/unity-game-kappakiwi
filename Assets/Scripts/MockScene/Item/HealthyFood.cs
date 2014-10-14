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

	// Use this for initialization
	void Start () {
		
		int var = Random.Range (0, 80);
		
		if (var < 10) {
			sprites = apple;
		} else if (var < 20) {
			sprites =  banana;
		} else if (var < 30) {
			sprites =  carrot;
		} else if (var < 40) {
			sprites =  eggplant;
		} else if (var < 50) {
			sprites =  orange;
		} else if (var < 60) {
			sprites =  pear;
		} else if (var < 70) {
			sprites =  tomato;
		} else if (var <= 80) {
			sprites =  watermelon;
		} 
	
	}
	
	// Update is called once per frame
	void Update () {
		destoryIfOffScreen ();
	}


}
