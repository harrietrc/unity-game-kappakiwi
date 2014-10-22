using UnityEngine;
using System.Collections;

public class PatrolEnemy : Enemy {

	int moveSpeed = 5;
	int touches = 0;

	float vertExtent;
	float horzExtent;

	float width;
	float height;

	bool isDead = false;

	private SpriteRenderer spriteRenderer;
	public Sprite sprite;

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = new Vector2(moveSpeed, 0); // assigning a speed

		// assigning the sprite Renderer 
		spriteRenderer = renderer as SpriteRenderer;
	}
	// Update is called once per frame
	void Update () {

		if(isDead) {
			rigidbody2D.transform.Rotate(new Vector3(0,0,10));
		}

		// getting the dimensions  of the screen
		// works by getting the Camera height then from there working out the screen width
		vertExtent = Camera.main.camera.orthographicSize;
		horzExtent = vertExtent * Screen.width / Screen.height; 

		width = renderer.bounds.size.x / 2 + 0.5f; 
		height = renderer.bounds.size.y / 2 + 0.5f;

		handleBirdMovement();
		handleTouchCollisions();
		destoryIfOffScreen ();

	}


	// handles user touching screen
	void handleTouchCollisions() {
		if (Input.touchCount > 0) { // if user has touched the screen

			touches = Input.touchCount; 
			var touch = Input.GetTouch (touches - 1); // getting the last touch
			var touchPos = Camera.main.ScreenToWorldPoint (touch.position); // converting to correct co-ord system

			// if user touches the gameObject
			if (touchPos.x > (transform.position.x - width) && touchPos.x < (width + transform.position.x)) {
				if (touchPos.y > (transform.position.y - height) && touchPos.y < (height + transform.position.y)) {
					handleDeath();
				}
			}
		}

	}

	// handles the bird movement
	void handleBirdMovement() {
			if (transform.position.x < (horzExtent * -1 + width)) 
			{
				rigidbody2D.velocity = new Vector2(moveSpeed,0);	
			} else if ( transform.position.x > (horzExtent - width)) 
			{
				rigidbody2D.velocity = new Vector2(- 1 * moveSpeed,0);	
				
			}
	}

	void handleDeath() {
		spriteRenderer.sprite = sprite;
		Destroy(gameObject,2);
		isDead = true;
		EnemyAchievement.incrementEnemyCount ();
		AudioSource deathSound = gameObject.AddComponent<AudioSource>();
		deathSound.clip = Resources.Load("Audio/glass_break") as AudioClip;
		deathSound.Play();
	}

	void OnCollisionEnter2D(Collision2D col) {

		if (col.gameObject.name == "KiwiBird" && isDead == false) {
		// if player is above alien, kill alien and make player jump.
			PlayerController other = (PlayerController) col.gameObject.GetComponent(typeof(PlayerController));
			if ((Mathf.Abs(col.gameObject.transform.position.y - col.gameObject.renderer.bounds.size.y/2)) > (Mathf.Abs(gameObject.transform.position.y - gameObject.transform.position.y/9))){
				handleDeath();
				other.boostPlayer(); // making the player jump
				other.playerStatus.score.increaseScoreByEnemy();
			} else {
				rigidbody2D.velocity = new Vector2(moveSpeed, 0); // assigning the speed at the start
				other.handleDeath(); // killing the player
			}
		}
	}
}

























