using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void destoryIfOffScreen(){
		if (transform.position.y < -5.0f) {
			Destroy(this);
		}
	}
}
