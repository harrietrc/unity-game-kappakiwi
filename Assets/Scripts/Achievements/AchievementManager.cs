using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AchievementManager : MonoBehaviour {

	private List<Achievement> achievementList  = new List<Achievement> ();

	public AchievementManager() {
		makeAchievements ();
	}

	//Go through achievements and output the key and its corresponding value (int type which determines if achievement
	//is locked or unlocked.
	public void checkAchievements() {
		foreach (Achievement a in achievementList) {
			Debug.Log (a.getKey() + " " + PlayerPrefs.GetInt (a.getKey ()));
		}
	}

	//Build list of achievements, with the key being a string of the goal
	public void makeAchievements() {
		for (int i = 20; i <= 100; i = i + 20 ) {
			string tempPlatformKey = "Bounced on " + i + " platforms!";
			PlatformAchievement tempPlatform = new PlatformAchievement(tempPlatformKey, i);
			achievementList.Add(tempPlatform);
		}

		for (int j = 5; j <= 20; j = j + 5) { 
			string tempItemKey = "Picked up " + j + " items in 1 level!";
			ItemAchievement tempItem = new ItemAchievement(tempItemKey, j);
			achievementList.Add (tempItem);
		}

		for (int k = 10; k <= 50; k = k + 10) { 
			string tempPlayKey = "Played " + k + " times!";
			PlayAchievement tempPlay = new PlayAchievement(tempPlayKey, k);
			achievementList.Add (tempPlay);
		}
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
