using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

	private Dictionary<string,Highscore> highScoreDict;

	private string lastScoreKey = "LastScore";
	

	public void makeHighScoreList() {
		highScoreDict = new Dictionary<string,Highscore> ();
		for (int i = 1; i <= 5; i++) {
			string tempKey = highScoreKey + i;
			bool hasKey = PlayerPrefs.HasKey(tempKey);
			if(hasKey) {
				string tempName = PlayerPrefs.GetString (tempKey);
				int tempScore = PlayerPrefs.GetInt (tempName);
				Highscore tempHighScore = new Highscore(tempScore, tempName);
				highScoreDict.Add (tempKey, tempHighScore);
			}else{
				Highscore temp = new Highscore(i , "N/A" + i);
				highScoreDict.Add (tempKey, temp); 
			}
		}
	}

	public void updateHighScoreList() {
		Dictionary<string,Highscore> newDict = new Dictionary<string,Highscore>(highScoreDict);

		Highscore temp = new Highscore (this.score.getScore (), "Kester" + Random.Range(-1000.0F, 1000.0F));
		newDict.Add (highScoreKey + "New", temp);
		int x = 1;

		foreach (var item in newDict.OrderByDescending(i => newDict[i.Key].getHighscore ())) {
			switch(x)
			{
				case 1:
					highScoreDict["HighScore1"] = newDict[item.Key];
					break;
				case 2:
					highScoreDict["HighScore2"] = newDict[item.Key];
					break;
				case 3:
					highScoreDict["HighScore3"] = newDict[item.Key];
					break;
				case 4:
					highScoreDict["HighScore4"] = newDict[item.Key];
					break;
				case 5:
					highScoreDict["HighScore5"] = newDict[item.Key];
					break;
			}

			x++;
		}

	}				

	public void saveHighScoresToPersistence() {
		for (int i = 1; i <= 5; i++) {
			string tempKey = highScoreKey + i;
			PlayerPrefs.SetString (tempKey, highScoreDict[tempKey].getName ());
			PlayerPrefs.SetInt (highScoreDict[tempKey].getName (), highScoreDict[tempKey].getHighscore ());
		}
	}

	public void displayHighScoreList() {
		for (int i = 1; i <= 5; i++) {
			Debug.Log (highScoreDict[highScoreKey + i].getName() + ": " + highScoreDict[highScoreKey + i].getHighscore());
 		}
	}

	public void displayPlayerPrefs() {
		for (int i = 1; i <= 5; i++) {
			string tempKey = highScoreKey + i;
			Debug.Log ("PLAYERPREFS >> " + PlayerPrefs.GetString (tempKey) + ": " + PlayerPrefs.GetInt (PlayerPrefs.GetString (tempKey) ));
		}
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
