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

	//This is a dictionary containing the top 5 high scores locally
	//The key is Highscore1 - Highscore5, which return a Highscore object (containing player name and highscore)
	private Dictionary<string,Highscore> highScoreDict;

	private string lastScoreKey = "LastScore";

	public void saveLastScore() {
		PlayerPrefs.SetInt (lastScoreKey, this.score.getScore ());
	}

	//Make temporary copy of highscore leaderboards and store in highScoreDict
	public void makeHighScoreList() {
		highScoreDict = new Dictionary<string,Highscore> ();
		for (int i = 1; i <= 5; i++) {
			string tempKey = highScoreKey + i;
			bool hasKey = PlayerPrefs.HasKey(tempKey);
			//If the key exists, get it from persistence
			if(hasKey) {
				string tempName = PlayerPrefs.GetString (tempKey);
				int tempScore = PlayerPrefs.GetInt (tempName);
				Highscore tempHighScore = new Highscore(tempScore, tempName);
				highScoreDict.Add (tempKey, tempHighScore);
			//Else assign a new value to the key
			}else{
				Highscore temp = new Highscore(0 , "N/A" + i);
				highScoreDict.Add (tempKey, temp); 
			}
		}
	}

	//Updates highScoreDict by adding the player score and see if it is in the top 5 
	public void updateHighScoreList(string name) {
		//Construct a new temporary dictionary which is an exact copy of highScoreDict
		Dictionary<string,Highscore> newDict = new Dictionary<string,Highscore>(highScoreDict);

		Highscore temp = new Highscore (this.score.getScore (), name);

		//Add a temporary key called "HighScoreNew" with the score of the last game played
		newDict.Add (highScoreKey + "New", temp);
		int x = 1;

		//Loops through newDict in descending order of the highscores
		foreach (var item in newDict.OrderByDescending(i => newDict[i.Key].getHighscore ())) {

			//This switch statement assigns the top 5 scores
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

	//Save the high scores to PlayerPrefs
	public void saveHighScoresToPersistence() {
		for (int i = 1; i <= 5; i++) {
			string tempKey = highScoreKey + i;
	
			//Save the string of the persons who owns the highscore with HighScorei as the key (1 <= i <= 5)
			PlayerPrefs.SetString (tempKey, highScoreDict[tempKey].getName ());
			//Save the highscore of the person (key = name, value = highscore)
			PlayerPrefs.SetInt (highScoreDict[tempKey].getName (), highScoreDict[tempKey].getHighscore ());
		}
	}

	//Display local copy of high scores for debugging
	public void displayHighScoreList() {
		for (int i = 1; i <= 5; i++) {
			Debug.Log (highScoreDict[highScoreKey + i].getName() + ": " + highScoreDict[highScoreKey + i].getHighscore());
 		}
	}

	//Display high scores stored in PlayerPrefs for debugging
	public void displayPersistentHighScores() {
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
