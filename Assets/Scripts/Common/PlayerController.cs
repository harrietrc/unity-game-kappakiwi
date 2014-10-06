using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Vector2 jumpForce = new Vector2(0, 800);
	private int selectedId;
	private int speed = 5;

	private GameObject currentPlatform;

	private ArrayList visitedPlatforms = new ArrayList();

	private GameObjectFactory factory = new GameObjectFactory();
	private ScreenShifter screenShifter = new ScreenShifter();


	// Use this for initialization
	void Start () {
	
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
		transform.Translate(Input.acceleration.x, 0, 0);

	}

	public void setFactoryDependency(GameObjectFactory dependency){
		this.factory = dependency;
	}

	public void setScreenShifterDependency(ScreenShifter dependency){
		this.screenShifter = dependency;
	}

	private void invokeScreenShifter(){
		this.screenShifter.shiftScreen ();
		}

	private void invokeFactory(){
		this.factory.generateTick ();
		}

	void OnCollisionEnter2D(Collision2D coll) {
				if (!visitedPlatforms.Contains(coll.gameObject)) {

					this.invokeFactory();
					this.invokeScreenShifter();

					visitedPlatforms.Add(coll.gameObject);
				}
				if (coll.gameObject.tag == "platform" && this.transform.position.y > coll.gameObject.transform.position.y) {
						rigidbody2D.velocity = Vector2.zero;
						rigidbody2D.AddForce (jumpForce);

				}
		}


	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Item") {
			other.gameObject.SetActive (false);
		}
	}
}
