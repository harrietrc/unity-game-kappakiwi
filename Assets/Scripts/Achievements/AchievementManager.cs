using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AchievementManager : MonoBehaviour {

	private List<Achievement> achievementList  = new List<Achievement> ();

	public AchievementManager() {
		makeAchievements ();
	}

	//Go through all the achievements and display them if they are unlocked for the first time.
	//Called repeatedly in Update() method 
	public void checkAchievements() {
		foreach (Achievement a in achievementList) {
			//Debug.Log (a.getKey() + " " + PlayerPrefs.GetInt (a.getKey ()));
			//Debug.Log (a.isAchievementUnlocked());
			a.isAchievementUnlocked();
			a.displayAchievement();
		}
	}

	//Build list of achievements, with the key being a string of the goal
	public void makeAchievements() {

		string tempPlatformKey = "Bounced on 100 platforms!";
		PlatformAchievement tempPlatform = new PlatformAchievement(tempPlatformKey, 100);
		achievementList.Add(tempPlatform);

		string tempItemKey = "Picked up 50 items!";
		ItemAchievement tempItem = new ItemAchievement(tempItemKey, 50);
		achievementList.Add (tempItem);
		
		string tempPlayKey = "Played 10 times!";
		PlayAchievement tempPlay = new PlayAchievement(tempPlayKey, 10);
		achievementList.Add (tempPlay);

		string tempEnemyKey = "Defeat 20 enemies!";
		EnemyAchievement tempEnemy = new EnemyAchievement (tempEnemyKey, 20);
		achievementList.Add (tempEnemy);

	}

	public List<Achievement> getAchievements() {
		return this.achievementList;
	}

	//Save all Achievement objects stored inside achievementList to PlayerPrefs
	public void saveAchievementsToPersistence() {
		for(int i = 0; i < achievementList.Count; i++) {
			string key = achievementList[i].getKey ();
			bool hasKey = PlayerPrefs.HasKey(key);

			//If achievement is already in PlayerPrefs
			if (hasKey) {
				//Check if achievement has already been unlocked >> 1 = unlocked, 0 = locked
				int isUnlocked = PlayerPrefs.GetInt (key);
				//If achievement has just been unlocked, or unlocked previously, then unlock
				if (achievementList[i].isAchievementUnlocked() || isUnlocked == 1) {
					PlayerPrefs.SetInt(key,1); 
				//Else achievement is still locked
				}else{
					PlayerPrefs.SetInt(key,0);
				}
			//Else add achievement to PlayerPrefs, locked
			}else{
				PlayerPrefs.SetInt (key, 0);
			}

			PlayerPrefs.Save ();
		}
	}

}
