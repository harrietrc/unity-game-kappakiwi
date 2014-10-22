using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	int moveSpeed = 4;
	int touches = 0;
	
	float vertExtent;
	float horzExtent;
	
	float width;
	float height;

	GameObject player;
	PlayerController playerScript;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag(Tags.TAG_PLAYER);
		playerScript = (PlayerController) player.GetComponent(typeof(PlayerController));
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

	void OnBecameVisible() {
		playerScript.addPlatformToList(gameObject);
		
	}
	
	void OnBecameInvisible() {
		playerScript.removePlatformToList(gameObject);
	}
	public void destoryIfOffScreen(){
		if (transform.position.y < Constants.ITEM_DESTRY_THRESHHOLD) {
			Destroy(this.gameObject);
		}
	}
}