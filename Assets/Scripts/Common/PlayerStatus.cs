using UnityEngine;
using System.Collections;

public class PlayerStatus {

	public float FitnessLevel{ get; set; }
	public float MaxFitnessLevel = 200.0f;
	public float MinFitenessLevel = -300.0f;

	public float weight{ get; set; }
	public float MaxWeight = .3f;
	public float minWeight = .1f;

	public float MaxHeight{ get; set; }

	public PlayerStatus(){
		FitnessLevel = 0.0f;
		MaxHeight = 0.0f;
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
			if (highscore < MaxHeight) {
				PlayerPrefs.SetFloat (highScoreKey, MaxHeight);
			} else {
				PlayerPrefs.SetFloat (highScoreKey, MaxHeight);
			}
			Debug.Log ("just saved to max height: " + MaxHeight);
			PlayerPrefs.Save ();
		}
	}
}
