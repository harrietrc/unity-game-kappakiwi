using UnityEngine;
using System.Collections;

public class JunkFoodTurret : Obstacle {
	int count = 0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		count = count + 1;	
		if (count % 100 == 0) {
			float distance = GameObject.FindGameObjectWithTag("player").transform.position.x - gameObject.transform.position.x;
			int temp = -1;
			if (distance > 0) {
				temp = 1;
			}
			count = 0;
			var	currentPos = (GameObject) Instantiate(Resources.Load ("Prefabs/Items/" + "pref_junkfood"), gameObject.transform.position,Quaternion.identity);
			currentPos.rigidbody2D.velocity = new Vector2(temp * 1,0);
		}
		destoryIfOffScreen ();
	}
}
