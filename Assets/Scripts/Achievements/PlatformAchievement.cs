using UnityEngine;
using System.Collections;

//Achievement subclass which is unlocked by bouncing on a certain number of platforms
public class PlatformAchievement : Achievement {

	//Number of platforms bounced on in order to unlock this achievement
	private int countToUnlock;
	private static string totalPlatforms = "TotalPlatforms";

	//Constructor: All platform achievements are initially locked
	public	PlatformAchievement(string key, int countToUnlock) {
		this.isUnlocked = false;
		this.countToUnlock = countToUnlock;
		this.key = key;
	}

	//Overriden abstract method
	//The achievement is unlocked if the 'count' (current no. of platforms bounced) is greater than or equal to
	//'countToUnlock'
	public override bool isAchievementUnlocked() {
		int currentPlatforms = PlayerPrefs.GetInt (totalPlatforms);

		if (currentPlatforms >= this.countToUnlock && !this.isUnlocked) {
			this.isUnlocked = true;
		}

		return this.isUnlocked;
	}

	public static void incrementPlatformCount() {
		int currentPlatforms = PlayerPrefs.GetInt (totalPlatforms);
		currentPlatforms++;
		PlayerPrefs.SetInt (totalPlatforms, currentPlatforms);
	}

	public void displayMessage() {
		Debug.Log ("Achievement Unlocked: " + this.key);
	}

	public void makeTotalPlatformsPersistence() {
		bool hasKey = PlayerPrefs.HasKey (totalPlatforms);
		
		if (!hasKey) {
			PlayerPrefs.SetInt (totalPlatforms, 0);	
		}
	}

	public int getCountToUnlock() {
		return this.countToUnlock;
	}
	
}
