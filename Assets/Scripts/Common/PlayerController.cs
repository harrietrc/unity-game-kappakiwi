using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Vector2 jumpForce = new Vector2(0, 800);
	private int selectedId;
	private int speed = 5;

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

	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.name == "pref_standard_platform" && this.transform.position.y > coll.gameObject.transform.position.y) {
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce(jumpForce);
		}

		
	}
}
