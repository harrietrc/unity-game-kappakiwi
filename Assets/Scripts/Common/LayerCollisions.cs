using UnityEngine;
using System.Collections;


/*
 * Due to problem with commiting, I need to programmically define
 * the layers that collide with each other.
 */

public class LayerCollisions : MonoBehaviour {

	// layer 0 = Default
	// layer 1 = TransparentFX
	// layer 2 = IgnoreRaycast
	// layer 3 = 
	// layer 4 = Water
	// layer 5 = UI
	// layer 8 = enemies
	// layer 9 = player
	// layer 10 = platformBelow
	// layer 11 = background
	// layer 12 = flag
	// layer 13 = platformAbove
	// layer 14 = items

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision (8,8); // enemies with enemies
		Physics2D.IgnoreLayerCollision (8,10); // enemies with platform below
		Physics2D.IgnoreLayerCollision (8,11); // enemies with background
		Physics2D.IgnoreLayerCollision (8,12); // enemies with flag
		Physics2D.IgnoreLayerCollision (8,13); // enemies with platformabove
		Physics2D.IgnoreLayerCollision (8,14); // enemies with the default layer

		Physics2D.IgnoreLayerCollision (0,8); // enemies with enemies
		Physics2D.IgnoreLayerCollision (0,10); // enemies with platform below
		Physics2D.IgnoreLayerCollision (0,11); // enemies with background
		Physics2D.IgnoreLayerCollision (0,12); // enemies with flag
		Physics2D.IgnoreLayerCollision (0,13); // enemies with platformabove
		Physics2D.IgnoreLayerCollision (0,14); // enemies with the default layer


		Physics2D.IgnoreLayerCollision (9,10); // player with platformAbove
		Physics2D.IgnoreLayerCollision (14,14); // items with items

		Physics2D.IgnoreLayerCollision (10,10); // platformsBelow with platformsBelow
		Physics2D.IgnoreLayerCollision (10,13); // platformsBelow with platformsAbove
		Physics2D.IgnoreLayerCollision (13,13); // platformsAbove with platformsAbove
		Physics2D.IgnoreLayerCollision (10,12); // platformBelow with Flag
		Physics2D.IgnoreLayerCollision (13,12); // platformAbove with Flag





	}
	
	// Update is called once per frame
	void Update () {
		
	}
	

}
