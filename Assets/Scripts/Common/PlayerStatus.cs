using UnityEngine;
using System.Collections;

public class PlayerStatus {

	public float FitnessLevel{ get; set; }
	public float MaxFitnessLevel = 200.0f;
	public float MinFitenessLevel = -300.0f;

	public float weight{ get; set; }
	public float MaxWeight = .3f;
	public float minWeight = .1f;

	public Score score;

	public PlayerStatus(){
		FitnessLevel = 0.0f;
		score = new Score ();
		weight = .15f;
		}

	private string highScoreKey = "HighScore";
	private string lastScoreKey = "LastScore";

	//Save highscore to PlayerPrefs
	public void saveScoreToPersistence(){

		bool haskey = PlayerPrefs.HasKey (highScoreKey);
		float highscore;
		if (haskey) {
			highscore = PlayerPrefs.GetFloat (highScoreKey);
			if (highscore < score.getScore ()) {
				PlayerPrefs.SetFloat (highScoreKey, score.getScore ());
			} else {
				PlayerPrefs.SetFloat (highScoreKey, highscore);
			}
		
		} else {
			PlayerPrefs.SetFloat (highScoreKey, score.getScore ());
		}

		PlayerPrefs.SetFloat (lastScoreKey, score.getScore ());
		PlayerPrefs.Save ();
	}

	//Handle the player's status when kiwi picks up a vegetable
	public void handleVegetableCollision() {
		this.score.increaseScoreByHealthyFood();
	}

	//Handle the player's status when kiwi picks up a junk food
	public void handleJunkFoodCollision() {
		this.score.decreaseScoreByJunkFood();
	}
	
}
