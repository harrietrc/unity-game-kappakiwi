using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Vector2 jumpForceBounce = new Vector2(0, 850);
	private Vector2 jumpForce = new Vector2(0, 530);
	private int speed = 5;
	private GameObject currentPlatform;

	private ArrayList visitedPlatforms = new ArrayList();

	private GameObjectFactory factory = new GameObjectFactory();
	private ScreenShifter screenShifter = new ScreenShifter();
	private AchievementManager achievementManager = new AchievementManager();

	private PlayerStatus playerStatus = new PlayerStatus();

	private float pos;

	// Use this for initialization
	void Start () {
		rigidbody2D.fixedAngle = true;
		factory.generateLevelStart ();
	}

	void Update ()
	{

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		transform.Translate(Input.acceleration.x/3, 0, 0);

		//calls the screenshifter's update method every frame because the screenshifter script isn't attached to the scene.
		screenShifter.Update ();

		achievementManager.checkForAchievements ();

		failIfBelowScreen ();

		// Keeps track of the position of the main character
		pos = transform.position.y;
		Debug.Log ("position is " + pos);

	}

	void OnDestroy(){
		Debug.Log ("saving to playerprefs");
		playerStatus.saveDataToPersistence ();
	}

	private void failIfBelowScreen(){
		if (transform.position.y < -4.5) {
			Application.LoadLevel ("ExitFailed");	

				}
		}


	private void updateMaxHeight(){
		playerStatus.MaxHeight = playerStatus.MaxHeight + 1.0f;

		Debug.Log ("updated max height to be " + playerStatus.MaxHeight);
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

	private void handlePlatformCollision(Collision2D coll){
		if (coll.gameObject.tag == Tags.TAG_PLATFORM && !visitedPlatforms.Contains(coll.gameObject) && this.transform.position.y > coll.gameObject.transform.position.y) {
			
			
			jumpForce = new Vector2(0, 530 * playerStatus.FitnessLevel);
			
			factory.generateTick();
			screenShifter.ShiftScreen();
			
			visitedPlatforms.Add(coll.gameObject);
			
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce (jumpForce);
			achievementManager.incrementPlatformCount();

			updateMaxHeight ();
		}
		else if (coll.gameObject.tag == Tags.TAG_PLATFORM && this.transform.position.y > coll.gameObject.transform.position.y) {
			
			jumpForceBounce = new Vector2(0, 850 * playerStatus.FitnessLevel);
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce (jumpForceBounce);
		}
	}

	private void handleEnemyCollision(Collision2D coll){

				if (coll.gameObject.tag == Tags.TAG_ENEMY) {
						if (coll.gameObject.name == "pref_basic_enemy") {
				Debug.Log("collided with a basic enemy");
								Application.LoadLevel ("ExitFailed");		
						} else if (coll.gameObject.name == "pref_falling_enemy") {
								Application.LoadLevel ("ExitFailed");
						} else if (coll.gameObject.name == "pref_stationary_enemy") {
								Application.LoadLevel ("ExitFailed");
						}
				}
		}

	private void handleObstacleCollision(Collision2D coll){
		//todo
		}

	private void handleItemCollision(Collider2D other){
		if (other.gameObject.name == "pref_healthyfood") {
			other.gameObject.SetActive (false);
			if(playerStatus.FitnessLevel<playerStatus.MaxFitnessLevel){
				HealthyFood healthyFood = other.gameObject.GetComponent<HealthyFood>();
				healthyFood.modifyFitnessLevel(playerStatus,0.1f);
			}
		}
		if (other.gameObject.name == "pref_junkfood") {
			other.gameObject.SetActive (false);
			if(playerStatus.FitnessLevel>playerStatus.MinFitenessLevel){
				JunkFood junkfood = other.gameObject.GetComponent<JunkFood>();
				junkfood.modifyFitnessLevel(playerStatus,-0.1f);
			}
		}
	}

	


}
