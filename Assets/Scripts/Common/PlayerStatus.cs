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

	public void loadDataFromPersistence(){
	}

	private string highScoreKey = "HighScore";

	public void saveDataToPersistence(){

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
		PlayerPrefs.Save ();
	}
	
}
