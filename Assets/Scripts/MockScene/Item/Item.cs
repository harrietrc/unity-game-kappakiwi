﻿using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		destoryIfOffScreen ();

	}

	public void destoryIfOffScreen(){
		if (transform.position.y < Constants.ITEM_DESTRY_THRESHHOLD) {
			Destroy(this);
		}
	}

	public void modifyFitnessLevel(PlayerStatus playerStatus, float modification){

		playerStatus.FitnessLevel += modification;
			 
		}


}