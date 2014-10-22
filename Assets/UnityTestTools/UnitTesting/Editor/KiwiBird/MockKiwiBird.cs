using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace UnityTest {
	public class MockKiwiBird : ScriptableObject{

		private Vector2 vel;
		public Vector2 position;
		private Vector2 jumpForceBounce = new Vector2(0, 850);
		private Vector2 jumpForce = new Vector2(0, 530);
		private int speed = 5;
		private GameObject currentPlatform;
		
		private ArrayList visitedPlatforms = new ArrayList();
		
		//private GameObjectFactory factory = new NullGameObjectFactory();
		//private ScreenShifter screenShifter = new ScreenShifter();
		//private AchievementManager achievementManager = new AchievementManager();
		//public PlayerStatus playerStatus = new PlayerStatus();
		private GameObject scoreText;
		private GameObject multiplierText;
		
		// list of platforms
		private List<GameObject> listOfPlatforms = new List<GameObject>();
		
		// frame counter
		private int frameCountWithoutVelChange = 0;
		
		
		// sprite changes
		public Sprite spriteFlipped;
		public Sprite spriteNormal;
		private SpriteRenderer spriteRenderer; 
		
		// Xmas reskin
		public Sprite xmasSpriteFlipped;
		public Sprite xmasSpriteNormal;
		
		
		private bool death = false;

		public bool getDeathStatus() {
			return death;
		}
		
		// Use this for initialization
		void Start () {
			
			switch (LevelSelection.CURRENT_GAMEMODE) {
			case GameMode.endless:
				//factory = new EndlessGameObjectFactory();
				break;
			case GameMode.scenario:
				//factory = new ScenarioGameObjectFactory();
				break;
			case GameMode.story:
				//factory = new NullGameObjectFactory();
				break;
			}
			

			//PlayerPrefs.DeleteAll ();
			//PlayerPrefs.SetString ("LoadedLevel", Application.loadedLevelName);
			//playerStatus.makeHighScoreList ();
			//factory.generateLevelStart ();
			//initializeScore ();
		}
		

		/*
		void OnBecameInvisible() {
			PlayAchievement.incrementPlayCount ();
			if (this.position.y <= -Camera.main.camera.orthographicSize) {
				//PlayerPrefs.SetInt ("Finished",0);
				if (playerStatus.score.getScore () > PlayerPrefs.GetInt (PlayerPrefs.GetString ("HighScore5"))) {
					Application.LoadLevel ("highscore");
				} else {
					Application.LoadLevel ("Exitfailed");
				}
			}
		}*/
		
		public void handleTeleport() {
			
			var vertExtent = Camera.main.camera.orthographicSize;
			var horzExtent = vertExtent * Screen.width / Screen.height; //21.09375
			if (this.position.x <= (horzExtent * -1)) 
			{
				this.position = new Vector2(-this.position.x, this.position.y);      
				//transform.position.x,transform.position.y;
			} else if ( this.position.x >= (horzExtent)) 
			{
				this.position = new Vector2(-this.position.x,this.position.y);  
			}
		}

		/*
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
			if (!(gameObject.rigidbody2D.velocity.y > 0.5f)) {
				
				Vector2 jumpForce = new Vector2(0, Constants.DISTANCE_JUMP + playerStatus.FitnessLevel);
				rigidbody2D.velocity = Vector2.zero;
				rigidbody2D.AddForce (jumpForce);
			}
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
		}*/
		
		public void handleEnemyCollision(Collision2D coll){
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
			//Physics2D.IgnoreLayerCollision (10,9);
			//PlayDeathSound();
		}
		
		/*
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
				PlayAchievement.incrementPlayCount ();
				PlayerPrefs.SetInt ("Finished",1);
				if (playerStatus.score.getScore () > PlayerPrefs.GetInt (PlayerPrefs.GetString ("HighScore5"))) {
					Application.LoadLevel ("highscore");
				} else {
					Application.LoadLevel ("ExitSuccess");
				}
			}
		}	*/

	}
}
