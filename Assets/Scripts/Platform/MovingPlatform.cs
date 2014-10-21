using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	int moveSpeed = 5;
	int touches = 0;
	
	float vertExtent;
	float horzExtent;
	
	float width;
	float height;


	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = new Vector2(moveSpeed,0);
	}
	
	// Update is called once per frame
	void Update () {

		vertExtent = Camera.main.camera.orthographicSize;
		horzExtent = vertExtent * Screen.width / Screen.height; 
		
		width = renderer.bounds.size.x / 2 + 0.5f; 
		height = renderer.bounds.size.y / 2 + 0.5f;

		handlePlatformMovement();

	}


	// handles the Platform movement
	void handlePlatformMovement() {
		
		if (transform.position.x < (horzExtent * -1 + width)) 
		{
			rigidbody2D.velocity = new Vector2(moveSpeed,0);	
		} else if ( transform.position.x > (horzExtent - width)) 
		{
			rigidbody2D.velocity = new Vector2(- 1 * moveSpeed,0);	
			
		}
	}


	public void destoryIfOffScreen(){
		if (transform.position.y < Constants.ITEM_DESTRY_THRESHHOLD) {
			Destroy(this.gameObject);
		}
	}
}
