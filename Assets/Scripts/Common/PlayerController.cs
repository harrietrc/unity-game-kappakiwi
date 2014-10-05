using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Input.acceleration.x, 0, 0);
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Item") {
			other.gameObject.SetActive (false);
		}
	}
}
