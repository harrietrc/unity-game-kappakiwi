using UnityEngine;
using System.Collections;

//Achievement subclass which is unlocked by bouncing on a certain number of platforms
public class PlatformAchievement : Achievement {

	//Number of platforms bounced on in order to unlock this achievement
	private int countToUnlock;
	//Static variable shared by all PlatformAchievements representing current number of platforms bounced on
	private static int count;

	//Constructor: All platform achievements are initially locked
	public	PlatformAchievement(string key, int countToUnlock) {
		this.isUnlocked = false;
		count = 0;
		this.countToUnlock = countToUnlock;
		this.key = key;
	}

	//Overriden abstract method
	//The achievement is unlocked if the 'count' (current no. of platforms bounced) is greater than or equal to
	//'countToUnlock'
	public override bool isAchievementUnlocked() {
		if (count >= this.countToUnlock && !this.isUnlocked) {
			this.isUnlocked = true;
		}
		return this.isUnlocked;
	}
	
	//Increment the static variable 'count'
	public static void incrementPlatformCount() {
		PlatformAchievement.count++;
	}

	public void displayMessage() {
		Debug.Log ("Achievement Unlocked: " + this.key);
	}

	public int getCountToUnlock() {
		return this.countToUnlock;
	}

}
