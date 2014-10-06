using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Vector2 jumpForceBounce = new Vector2(0, 850);
	private Vector2 jumpForce = new Vector2(0, 530);
	private int selectedId;
	private int speed = 5;
	private double jumpRate;
	private GameObject currentPlatform;

	private ArrayList visitedPlatforms = new ArrayList();

	private GameObjectFactory factory = new GameObjectFactory();
	private ScreenShifter screenShifter = new ScreenShifter();
	private AchievementManager achievementManager = new AchievementManager();

	private PlayerStatus playerStatus = new PlayerStatus();


	// Use this for initialization
	void Start () {
		rigidbody2D.fixedAngle = true;
		factory.generateLevelStart ();
		jumpRate = 1;
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

	}

	public void setFactoryDependency(GameObjectFactory dependency){
		this.factory = dependency;
	}

	public void setScreenShifterDependency(ScreenShifter dependency){
		this.screenShifter = dependency;
	}
	

	void OnCollisionEnter2D(Collision2D coll) {

		if (coll.gameObject.tag == Tags.TAG_PLATFORM && !visitedPlatforms.Contains(coll.gameObject) && this.transform.position.y > coll.gameObject.transform.position.y) {


			jumpForce = new Vector2(0, 530 * playerStatus.FitnessLevel);

			factory.generateTick();
			screenShifter.ShiftScreen();

			visitedPlatforms.Add(coll.gameObject);

			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce (jumpForce);
			achievementManager.incrementPlatformCount();
		}
		else if (coll.gameObject.tag == Tags.TAG_PLATFORM && this.transform.position.y > coll.gameObject.transform.position.y) {

			jumpForceBounce = new Vector2(0, 850 * playerStatus.FitnessLevel);
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce (jumpForceBounce);
		}

	}
	

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "pref_healthyfood") {
			other.gameObject.SetActive (false);
			if(jumpRate<1.5f){
				HealthyFood healthyFood = other.gameObject.GetComponent<HealthyFood>();
				healthyFood.modifyFitnessLevel(playerStatus,0.1f);
			}
		}
		if (other.gameObject.name == "pref_junkfood") {
			other.gameObject.SetActive (false);
			if(jumpRate>0.5f){
				JunkFood junkfood = other.gameObject.GetComponent<JunkFood>();
				junkfood.modifyFitnessLevel(playerStatus,-0.1f);
			}
		}
	}
}
