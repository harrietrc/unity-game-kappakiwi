using UnityEngine;
using System.Collections;

public class WallSpike : Obstacle {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		destoryIfOffScreen ();
	}
}
