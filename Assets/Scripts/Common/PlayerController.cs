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

	private GameObjectFactory factory = new GameObjectFactory();
	private ScreenShifter screenShifter = new ScreenShifter();
	private AchievementManager achievementManager = new AchievementManager();

	private PlayerStatus playerStatus = new PlayerStatus();

	public GUIText scoreText;
	private int score = 0;
	private bool death = false;

	// Use this for initialization
	void Start () {
		rigidbody2D.fixedAngle = true;
		//factory.generateLevelStart ();
		updateScore ();
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
		//	screenShifter.ShiftScreen (-.1f);
				}

		failIfBelowScreen ();

		updateScore ();
	}

	void OnDestroy(){
		playerStatus.saveDataToPersistence ();
		achievementManager.saveAchievementsToPersistence ();
		achievementManager.checkAchievements ();
	}
	private void failIfBelowScreen(){

		if (transform.position.y < Constants.FAIL_THRESHHOLD) {
			Debug.Log ("failed because y was less than " + Constants.FAIL_THRESHHOLD);
			Application.LoadLevel ("ExitFailed");
		}
	}

	private void updateMaxHeight(){
		// Platform count
		playerStatus.MaxHeight = playerStatus.MaxHeight + 1.0f;
		// Position count
	//	Debug.Log ("updated max height to be " + playerStatus.MaxHeight);
	}

	void updateScore(){
		score = (int)playerStatus.MaxHeight;
		//scoreText.text = "Score : " + score;
	//	Debug.Log ("Score is : " + score);
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
		if (( coll.gameObject.tag == Tags.TAG_PLATFORM || coll.gameObject.tag == "pref_collapsing_platform" ) && !visitedPlatforms.Contains(coll.gameObject) && this.transform.position.y > coll.gameObject.transform.position.y) {

			print ("here");
			boostPlayer();

			PlatformAchievement.incrementPlatformCount();

			updateMaxHeight ();
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
							Debug.Log("collided with a basic enemy");
							//	Application.LoadLevel ("ExitFailed");
						//	handleDeath();
						} else if (coll.gameObject.name == "pref_falling_enemy") {
							handleDeath();

						} else if (coll.gameObject.name == "pref_stationary_enemy") {
							//	Application.LoadLevel ("ExitFailed");
							handleDeath();
						} else if (coll.gameObject.name == "Shooting_enemy") {
								handleDeath();
						}
				}
		}

	private void handleDeath() {
		death = true;
		Physics2D.IgnoreLayerCollision (10,9);

		AudioSource deathSound = gameObject.AddComponent<AudioSource>();
		deathSound.clip = Resources.Load("Audio/Pacman-Die") as AudioClip;
		deathSound.Play();
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
			
			AudioSource vegetableSound = gameObject.AddComponent<AudioSource>();
			vegetableSound.clip = Resources.Load("Audio/vegetable") as AudioClip;
			vegetableSound.Play();

			playerStatus.weight += Constants.VEGETABLE_WEIGHT_CHANGE;
			gameObject.transform.localScale = new Vector3(playerStatus.weight, playerStatus.weight, 1);
		}
		if (other.gameObject.tag == Tags.TAG_CANDY) {
			Destroy (other.gameObject);
			if(playerStatus.FitnessLevel>playerStatus.MinFitenessLevel){
				JunkFood junkfood = other.gameObject.GetComponent<JunkFood>();
				junkfood.modifyFitnessLevel(playerStatus,Constants.CANDY_FITNESS_CHANGE);
			}
			AudioSource candySound = gameObject.AddComponent<AudioSource>();
			candySound.clip = Resources.Load("Audio/candy") as AudioClip;
			candySound.Play();

			playerStatus.weight += Constants.CANDY_WEIGHT_CHANGE;
			gameObject.transform.localScale = new Vector3(playerStatus.weight, playerStatus.weight, 1);
		}
		if (other.gameObject.tag == Tags.TAG_FLAG) {
			Application.LoadLevel ("ExitSuccess");
			}
		}
	}

	
