using UnityEngine;
using System.Collections;

public class ScreenShifter : MonoBehaviour {

	private GameObject[] platforms;
	private GameObject[] items;
	private GameObject[] obstacles;
	private GameObject[] enemies;
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

		shiftElemtents ();
	
	}

	public ScreenShifter() {
		}

	private void shiftElemtents(){
			if (shifting) {
			for (int i = 0; i < platforms.Length; i++) {
				platforms[i].transform.Translate(new Vector3(0,speed,0));
			}
			for (int i = 0; i < items.Length; i++) {
				items[i].transform.Translate(new Vector3(0,speed,0));
			}
			for (int i = 0; i < enemies.Length; i++) {
				enemies[i].transform.Translate(new Vector3(0,speed,0));
			}
			for (int i = 0; i < obstacles.Length; i++) {
				obstacles[i].transform.Translate(new Vector3(0,speed,0));
			}
//			player.transform.Translate(new Vector3(0,speed,0));
			if(frames == 5){
				shifting = false;
			}
			frames++;
		}
	}
	

	public void ShiftScreen(){
		platforms = GameObject.FindGameObjectsWithTag(Tags.TAG_PLATFORM);
		items = GameObject.FindGameObjectsWithTag(Tags.TAG_ITEM);
		enemies = GameObject.FindGameObjectsWithTag(Tags.TAG_ENEMY);
		obstacles = GameObject.FindGameObjectsWithTag(Tags.TAG_OBSTACLE);

		player = GameObject.FindGameObjectWithTag (Tags.TAG_PLAYER);
		shifting = true;
		frames = 0;
		
	}
	
}
