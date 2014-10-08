using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void destoryIfOffScreen(){
		if (transform.position.y < Constants.ITEM_DESTRY_THRESHHOLD) {
			Destroy(this);
		}
	}
}
