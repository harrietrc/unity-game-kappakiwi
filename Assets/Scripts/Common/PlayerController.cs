using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Vector2 jumpForceBounce = new Vector2(0, 850);
	private Vector2 jumpForce = new Vector2(0, 530);
	private int selectedId;
	private int speed = 5;

	private GameObject currentPlatform;

	private ArrayList visitedPlatforms = new ArrayList();

	private GameObjectFactory factory = new GameObjectFactory();
	private ScreenShifter screenShifter = new ScreenShifter();


	// Use this for initialization
	void Start () {
		rigidbody2D.fixedAngle = true;
		factory.generateLevelStart ();
	}

	void Update ()
	{
//		transform.LookAt (new Vector3(3, 9 ,0));
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

	}

	public void setFactoryDependency(GameObjectFactory dependency){
		this.factory = dependency;
	}

	public void setScreenShifterDependency(ScreenShifter dependency){
		this.screenShifter = dependency;
	}
	

	void OnCollisionEnter2D(Collision2D coll) {
		if (!visitedPlatforms.Contains(coll.gameObject) && this.transform.position.y > coll.gameObject.transform.position.y) {

					factory.generateTick();
					screenShifter.ShiftScreen();

					visitedPlatforms.Add(coll.gameObject);

					rigidbody2D.velocity = Vector2.zero;
					rigidbody2D.AddForce (jumpForce);
				}
				else if (coll.gameObject.tag == "platform" && this.transform.position.y > coll.gameObject.transform.position.y) {
						rigidbody2D.velocity = Vector2.zero;
						rigidbody2D.AddForce (jumpForceBounce);

				}
		}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Item") {
			other.gameObject.SetActive (false);
		}
	}
}
