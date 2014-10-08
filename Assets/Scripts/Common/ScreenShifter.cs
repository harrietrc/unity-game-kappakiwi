using UnityEngine;
using System.Collections;

public class ScreenShifter : MonoBehaviour {

	private GameObject[] platforms;
	private GameObject[] items;
	private GameObject[] obstacles;
	private GameObject[] enemies;
	private GameObject[] vegetables;
	private GameObject[] candy;
	private GameObject player;
		
	private float speed = -.4f;

	private bool shifting = false;
	private int startY;
	private int endY;

	private int frames = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void Update () {

		shiftElements ();
	
	}

	public ScreenShifter() {
		}

	private void shiftElements(){
			if (shifting) {
			for (int i = 0; i < platforms.Length; i++) {
				if(platforms[i] != null){
					platforms[i].transform.Translate(new Vector3(0,speed,0));
				}
			}
			for (int i = 0; i < items.Length; i++) {
				if(items[i] != null){
					items[i].transform.Translate(new Vector3(0,speed,0));
				}
			}
			for (int i = 0; i < enemies.Length; i++) {
				if(enemies[i] != null){
					enemies[i].transform.Translate(new Vector3(0,speed,0));
				}
			}
			for (int i = 0; i < obstacles.Length; i++) {
				if(obstacles[i] != null){
					obstacles[i].transform.Translate(new Vector3(0,speed,0));
				}
			}
			for (int i =0; i< candy.Length; i++ ) {
				if(candy[i] != null){
					candy[i].transform.Translate(new Vector3(0,speed,0));
				}
			}
			for (int i =0; i< vegetables.Length; i++ ) {
				if(vegetables[i] != null){
					vegetables[i].transform.Translate(new Vector3(0,speed,0));
				}
			}
			player.transform.Translate(new Vector3(0,speed,0));
//			if(frames == 5){
//				shifting = false;
//			}
			frames++;
		}
	}
	

	public void ShiftScreen(float shiftAmount){

		speed = shiftAmount;
		platforms = GameObject.FindGameObjectsWithTag(Tags.TAG_PLATFORM);
		items = GameObject.FindGameObjectsWithTag(Tags.TAG_ITEM);
		enemies = GameObject.FindGameObjectsWithTag(Tags.TAG_ENEMY);
		obstacles = GameObject.FindGameObjectsWithTag(Tags.TAG_OBSTACLE);
		candy = GameObject.FindGameObjectsWithTag(Tags.TAG_CANDY);
		vegetables = GameObject.FindGameObjectsWithTag(Tags.TAG_VEGETABLE);

		player = GameObject.FindGameObjectWithTag (Tags.TAG_PLAYER);
		shifting = true;
		frames = 0;

		shiftElements ();
	}
	
}
