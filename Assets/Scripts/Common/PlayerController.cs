using System.Collections;
using UnityEngine;

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
	private PlayerStatus playerStatus = new PlayerStatus();
	private GameObject scoreText;

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



	private bool death = false;

	// Use this for initialization
	void Start () {
		if (LevelSelection.CURRENT_THEME == Theme.endless) {
			Debug.Log("theme was endless");
			factory = new EndlessGameObjectFactory();
		} else {
			factory = new NullGameObjectFactory();
		}

		rigidbody2D.fixedAngle = true;
		factory.generateLevelStart ();
		initializeScore ();
	}

	void Update ()
	{
		Vector2 vel = rigidbody2D.velocity;
		if (!death) {
			Physics2D.IgnoreLayerCollision (10,9,vel.y > 0.0f);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * Constants.SPEED_MOVE * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right * Constants.SPEED_MOVE * Time.deltaTime;
		}
		transform.Translate(Input.acceleration.x/3, 0, 0);

		//calls the screenshifter's update method every frame because the screenshifter script isn't attached to the scene.
		if (transform.position.y > Constants.SCREEN_SHIFT_THRESHHOLD) {
			screenShifter.ShiftScreen (-.1f);
		}

		achievementManager.checkAchievements ();
		updateScore ();
		failIfBelowScreen ();
	}

	void OnDestroy(){
		PlayAchievement.incrementPlayCount ();

		Debug.Log (PlayerPrefs.GetInt ("TotalPlays"));
		Debug.Log (PlayerPrefs.GetInt ("TotalPlatforms"));
		Debug.Log (PlayerPrefs.GetInt ("TotalItems"));

		playerStatus.saveScoreToPersistence ();
		achievementManager.saveAchievementsToPersistence ();
	}
	private void failIfBelowScreen(){

		if (transform.position.y < Constants.FAIL_THRESHHOLD) {
			Debug.Log ("failed because y was less than " + Constants.FAIL_THRESHHOLD);
			Application.LoadLevel ("ExitFailed");
		}
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
		factory.generateTick();
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
		/*
		AudioSource deathSound = gameObject.AddComponent<AudioSource>();
		deathSound.clip = Resources.Load("Audio/Pacman-Die") as AudioClip;
		deathSound.Play();
		*/
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
			/*
			AudioSource vegetableSound = gameObject.AddComponent<AudioSource>();
			vegetableSound.clip = Resources.Load("Audio/vegetable") as AudioClip;
			vegetableSound.Play();
			*/

			ItemAchievement.incrementItemCount();
			playerStatus.handleVegetableCollision();
			gameObject.transform.localScale = new Vector3(playerStatus.weight, playerStatus.weight, 1);
		}
		if (other.gameObject.tag == Tags.TAG_CANDY) {
			Destroy (other.gameObject);
			if(playerStatus.FitnessLevel>playerStatus.MinFitenessLevel){
				//JunkFood junkfood = other.gameObject.GetComponent<JunkFood>();
				//junkfood.modifyFitnessLevel(playerStatus,Constants.CANDY_FITNESS_CHANGE);
			}
			if(playerStatus.weight < playerStatus.MaxWeight){
				playerStatus.weight += Constants.CANDY_WEIGHT_CHANGE;
			}

			PlayEatCandySound();

			/*
			AudioSource candySound = gameObject.AddComponent<AudioSource>();
			candySound.clip = Resources.Load("Audio/candy") as AudioClip;
			candySound.Play();
			*/


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
	}

	private void updateScore() {
		scoreText.guiText.text = "Score: " + playerStatus.score.getScore ().ToString();
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

	
