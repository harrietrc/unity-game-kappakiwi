using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	public AudioClip hitByEnemy;
	public AudioClip eatSomething;

	private Vector2 vel;
	private Vector2 jumpForceBounce = new Vector2(0, 850);
	private Vector2 jumpForce = new Vector2(0, 530);
	private int speed = 5;
	private GameObject currentPlatform;

	private ArrayList visitedPlatforms = new ArrayList();

	private GameObjectFactory factory = new NullGameObjectFactory();
	private ScreenShifter screenShifter = new ScreenShifter();
	private AchievementManager achievementManager = new AchievementManager();
	public PlayerStatus playerStatus = new PlayerStatus();
	private GameObject scoreText;
	private GameObject multiplierText;

	// list of platforms
	private List<GameObject> listOfPlatforms = new List<GameObject>();

	// Audio variables
	public AudioClip deathSound; 
	public AudioClip eatChocolateSound;
	public AudioClip eatAppleSound;
	public AudioClip eatCandySound;
	public AudioClip thudSound; //if necessary it'll be added.
	public AudioClip eatChipsSound;

	// Enemy collision sounds
	public AudioClip enemyRocketSound;
	public AudioClip enemyAlienSound;


	// sprite changes
	public Sprite spriteFlipped;
	public Sprite spriteNormal;
	private SpriteRenderer spriteRenderer; 
	
	// Xmas reskin
	public Sprite xmasSpriteFlipped;
	public Sprite xmasSpriteNormal;


	private bool death = false;

	// Use this for initialization
	void Start () {

		if (LevelSelection.CURRENT_GAMEMODE == GameMode.endless) {
			factory = new EndlessGameObjectFactory();
		} else {
			Debug.Log("factory is nullobjectfactory");
			factory = new NullGameObjectFactory();
		}

		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		// Apply Xmas theme if relevant
		if (LevelSelection.CURRENT_THEME == Theme.xmas) {
			spriteFlipped = xmasSpriteFlipped;
			spriteNormal = xmasSpriteNormal;
			spriteRenderer.sprite = spriteFlipped; // Else the kiwi magically gets a Santa hat...
		}

		playerStatus.makeHighScoreList ();
		rigidbody2D.fixedAngle = true;
		factory.generateLevelStart ();
		initializeScore ();
	}

	void Update ()
	{

		updatePlatformLayer();


		Vector2 vel = rigidbody2D.velocity;
		if (!death) {
			//Physics2D.IgnoreLayerCollision (10,9,vel.y > 0.0f);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * Constants.SPEED_MOVE * Time.deltaTime;
			spriteRenderer.sprite = spriteNormal;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right * Constants.SPEED_MOVE * Time.deltaTime;
			spriteRenderer.sprite = spriteFlipped;
		}
		transform.Translate(Input.acceleration.x/3, 0, 0);

		if (Input.acceleration.x >0) {
			spriteRenderer.sprite = spriteFlipped;
		} else if (Input.acceleration.y < 0) {
			spriteRenderer.sprite = spriteNormal;
		}

		//calls the screenshifter's update method every frame because the screenshifter script isn't attached to the scene.
		if (transform.position.y > Constants.SCREEN_SHIFT_THRESHHOLD) {
			screenShifter.ShiftScreen (-.1f);
			if(screenShifter.shiftDistance  %40 == 0){
				Debug.Log("generating");
				factory.generateTick();
			}
		}

		achievementManager.checkAchievements ();
		updateScore ();
		handleTeleport();
	}


	private void updatePlatformLayer() {
		float playerPos = transform.position.y - renderer.bounds.size.y / 2;

		for (int i = 0; i < listOfPlatforms.Count; i++) {
			if(listOfPlatforms[i] != null){
				if(listOfPlatforms[i].transform.position.y > playerPos) {
				// layer 10 is platform below
				// layer 13 is platform above
					listOfPlatforms[i].layer = 13;
				} else {
					listOfPlatforms[i].layer = 10;
				}

			}
		}
	}
	public void addPlatformToList(GameObject newPlatform) {
		listOfPlatforms.Add(newPlatform);
	}

	public void removePlatformToList(GameObject oldPlatform) {
		listOfPlatforms.Remove(oldPlatform);
	}

	void OnBecameInvisible() {

		if (transform.position.y <= -Camera.main.camera.orthographicSize) {
			if (playerStatus.score.getScore () > PlayerPrefs.GetInt (PlayerPrefs.GetString ("HighScore5"))) {
				Application.LoadLevel ("highscore");
			} else {
				Application.LoadLevel ("Exitfailed");
			}
		}

	}

	void handleTeleport() {
		
		var vertExtent = Camera.main.camera.orthographicSize;
		var horzExtent = vertExtent * Screen.width / Screen.height; 
		var width = renderer.bounds.size.x / 2 + 0.5f; 
		var height = renderer.bounds.size.y / 2 + 0.5f;
		
		if (transform.position.x <= (horzExtent * -1)) 
		{
			transform.position = new Vector3(-transform.position.x,transform.position.y,transform.position.z);      
			//transform.position.x,transform.position.y;
		} else if ( transform.position.x >= (horzExtent)) 
		{
			transform.position = new Vector3(-transform.position.x,transform.position.y,transform.position.z);  
		}
	}

	void OnDestroy(){
		PlayAchievement.incrementPlayCount ();
		playerStatus.saveLastScore ();
		//playerStatus.updateHighScoreList ();
		//playerStatus.saveHighScoresToPersistence();
		//playerStatus.displayPersistentHighScores ();
		achievementManager.saveAchievementsToPersistence ();
	}


	public void setFactoryDependency(GameObjectFactory dependency){
		this.factory = dependency;
	}

	public void setScreenShifterDependency(ScreenShifter dependency){
		this.screenShifter = dependency;
	}
	

	void OnCollisionEnter2D(Collision2D coll) {
		handlePlatformCollision (coll);
		handleEnemyCollision (coll);
		handleObstacleCollision (coll);
	}

	void OnTriggerEnter2D(Collider2D other){
		handleItemCollision (other);
	}

	// method to make player jump
	public void boostPlayer() {
		Vector2 jumpForce = new Vector2(0, Constants.DISTANCE_JUMP + playerStatus.FitnessLevel);
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.AddForce (jumpForce);
	}

	private void handlePlatformCollision(Collision2D coll){
		if (( coll.gameObject.tag == Tags.TAG_PLATFORM || coll.gameObject.tag == "pref_collapsing_platform" ) 
		    && !visitedPlatforms.Contains(coll.gameObject) && 
		    this.transform.position.y > coll.gameObject.transform.position.y) {

			boostPlayer();
			PlatformAchievement.incrementPlatformCount();
			playerStatus.score.increaseScoreByPlatform ();
			visitedPlatforms.Add(coll.gameObject);
		}
		else if (coll.gameObject.tag == Tags.TAG_PLATFORM && this.transform.position.y > coll.gameObject.transform.position.y) {
			
			Vector2 jumpForce = new Vector2(0, Constants.DISTANCE_JUMP + playerStatus.FitnessLevel);
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce (jumpForce);
		}
	}

	private void handleEnemyCollision(Collision2D coll){

		if (coll.gameObject.tag == Tags.TAG_ENEMY) {
			if (coll.gameObject.name == "pref_basic_enemy") {
					Debug.Log ("collided with a basic enemy");
					//	Application.LoadLevel ("ExitFailed");
					//handleDeath();
			} else if (coll.gameObject.name == "pref_falling_enemy") {
					handleDeath ();

			} else if (coll.gameObject.name == "pref_stationary_enemy") {
					//	Application.LoadLevel ("ExitFailed");
					handleDeath ();
			} else if (coll.gameObject.name == "Shooting_enemy") {
					handleDeath ();
			}
		}
	}

	public void handleDeath() {
		death = true;
		Physics2D.IgnoreLayerCollision (10,9);
		PlayDeathSound();
	}

	private void handleObstacleCollision(Collision2D coll){
	//todo
	}

	private void handleItemCollision(Collider2D other){
		if (other.gameObject.tag == Tags.TAG_VEGETABLE) {
			other.gameObject.SetActive (false);
			if(playerStatus.FitnessLevel<playerStatus.MaxFitnessLevel){
				HealthyFood healthyFood = other.gameObject.GetComponent<HealthyFood>();
				healthyFood.modifyFitnessLevel(playerStatus,Constants.VEGETABLE_FITNESS_CHANGE);
			}
			if(playerStatus.weight > playerStatus.minWeight){
				playerStatus.weight += Constants.VEGETABLE_WEIGHT_CHANGE;
			}

			PlayEatAppleSound();

			ItemAchievement.incrementItemCount();
			playerStatus.handleVegetableCollision();
			gameObject.transform.localScale = new Vector3(playerStatus.weight, playerStatus.weight, 1);
		}
		if (other.gameObject.tag == Tags.TAG_CANDY) {
			Destroy (other.gameObject);
			if(playerStatus.FitnessLevel>playerStatus.MinFitenessLevel){
				JunkFood junkfood = other.gameObject.GetComponent<JunkFood>();
				junkfood.modifyFitnessLevel(playerStatus,Constants.CANDY_FITNESS_CHANGE);
			}
			if(playerStatus.weight < playerStatus.MaxWeight){
				playerStatus.weight += Constants.CANDY_WEIGHT_CHANGE;
			}

			PlayEatCandySound();

			ItemAchievement.incrementItemCount();
			playerStatus.handleJunkFoodCollision();
			gameObject.transform.localScale = new Vector3(playerStatus.weight, playerStatus.weight, 1);
		}
		if (other.gameObject.tag == Tags.TAG_FLAG) {
			Application.LoadLevel ("ExitSuccess");
		}
	}
	private void initializeScore() {
		scoreText = new GameObject ();
		scoreText.AddComponent<GUIText> ();
		scoreText.transform.position = new Vector3 (0.1f, 0.9f, 0);
		scoreText.guiText.text = "Score: " + playerStatus.score.getScore ().ToString();
		scoreText.guiText.material.color = Color.white;

		multiplierText = new GameObject ();
		multiplierText.AddComponent<GUIText> ();
		multiplierText.transform.position = new Vector3 (0.1f, 0.85f, 0);
		multiplierText.guiText.text = "Multiplier: " + playerStatus.score.getMultiplier ().ToString() + "x";
		multiplierText.guiText.material.color = Color.white;
	}

	private void updateScore() {
		try{

		scoreText.guiText.text = "Score: " + playerStatus.score.getScore ().ToString();
		multiplierText.guiText.text = "Mutiplier: " + playerStatus.score.getMultiplier ().ToString() + "x";

		} catch (UnityException e) {
				} 
			catch (Exception e) {
				}
	}



	// Sound functions are here
	private void PlayDeathSound() {
		if (deathSound){
			AudioSource.PlayClipAtPoint(deathSound, transform.position);
		}
	}

	private void PlayEatChocolateSound () {
		if (eatChocolateSound){
			AudioSource.PlayClipAtPoint(eatChocolateSound, transform.position);
		}
	}

	private void PlayEatCandySound () {
		if (eatCandySound){
			AudioSource.PlayClipAtPoint(eatCandySound, transform.position);
		}
	}

	private void PlayEatAppleSound () {
		if (eatAppleSound){
			AudioSource.PlayClipAtPoint(eatAppleSound, transform.position);
		}
	}

	private void PlayThudSound(){
		if (thudSound) {
			AudioSource.PlayClipAtPoint(thudSound, transform.position);
		}
	}

	//if necessary it'll be added.
	private void PlayEatChipsSound(){
		if (eatChipsSound) {
			AudioSource.PlayClipAtPoint(eatChipsSound, transform.position);
		}
	}
	
	// Enemy collision sounds
	private void PlayEnemyRocketSound(){
		if (enemyRocketSound) {
			AudioSource.PlayClipAtPoint(enemyRocketSound, transform.position);
		}
	}

	private void PlayEnemyAlienSound(){
		if (enemyAlienSound) {
			AudioSource.PlayClipAtPoint(enemyAlienSound, transform.position);
		}
	}

}

