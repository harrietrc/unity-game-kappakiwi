using UnityEngine;
using System.Collections;

public class FallingEnemy : Enemy {

	public AudioClip rocketExplosion;

	// Use this for initialization
	void Start () {
		gameObject.rigidbody2D.velocity	= new Vector2(0,-7);
		gameObject.rigidbody2D.gravityScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		destoryIfOffScreen ();
	}

	// Overiding the default method, called when it collides with another object
	void OnCollisionEnter2D(Collision2D col) 
	{

		if (col.gameObject.tag == Tags.TAG_PLAYER) { // the colliding object is player, destroy the rocket.
			// spawning the explosion prefab
			if (rocketExplosion) {
				AudioSource.PlayClipAtPoint(rocketExplosion, transform.position);
			}
			var particle = Instantiate(Resources.Load ("Prefabs/effects/" + "Explosion"), gameObject.transform.position,Quaternion.identity);
			Destroy(col.gameObject); // destroying the rocket
			Destroy (gameObject); // destroying the kiwibird
			Destroy(particle,2.6f); // destroying the explosion prefab after 2.6 seconds which will trigger an event in explosionScript.cs to load exit screen.
		}

	}



	private IEnumerator Wait(float seconds) 
	{

		yield return new WaitForSeconds(seconds);
	}

}
