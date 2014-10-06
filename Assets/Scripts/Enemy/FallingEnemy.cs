using UnityEngine;
using System.Collections;

public class FallingEnemy : Enemy {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	// Overiding the default method, called when it collides with another object
	void OnCollisionEnter2D(Collision2D col) 
	{
		if (col.gameObject.tag == "player") { // the colliding object is player, destroy the rocket.
			Destroy(this.gameObject); 
		}
	}
}
