using UnityEngine;
using System.Collections;

public class PlayAchievement : Achievement {

	//Key for player preferences containing total number of games played
	private static string totalPlays = "TotalPlays";
	private int countToUnlock;

	public	PlayAchievement(string key, int countToUnlock) {
		this.isUnlocked = false;
		this.countToUnlock = countToUnlock;
		this.key = key;
	}

	//Increment the number of times played total
	public static void incrementPlayCount() {
		int currentPlays = PlayerPrefs.GetInt (totalPlays);
		currentPlays++;
		PlayerPrefs.SetInt (totalPlays, currentPlays);
	}

	//Overriden abstract method
	//The achievement is unlocked if the number of times played overall is more than or equal
	//to the countToUnlock
	public override bool isAchievementUnlocked() {
		int currentPlays = PlayerPrefs.GetInt (totalPlays);

		if (currentPlays >= countToUnlock && !this.isUnlocked) {
			this.isUnlocked = true;
		}

		return this.isUnlocked;
	}

	//Add the TotalPlays key to persistence	
	public void makeTotalPlaysPersistence() {
		bool hasKey = PlayerPrefs.HasKey (totalPlays);

		if (!hasKey) {
			PlayerPrefs.SetInt (totalPlays, 0);	
		}
	}

	public int getCountToUnlock() {
		return this.countToUnlock;
	}
}