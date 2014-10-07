using UnityEngine;
using System.Collections;

public class PlatformAchievement : Achievements {
	
	private int countToUnlock;
	private static int count;

	public	PlatformAchievement(string key, int countToUnlock) {
		this.isUnlocked = false;
		count = 0;
		this.countToUnlock = countToUnlock;
		this.key = key;
	}

	public override bool isAchievementUnlocked() {
		if (count >= this.countToUnlock && !this.isUnlocked) {
			this.isUnlocked = true;
		}
		return this.isUnlocked;
	}

	public void displayMessage() {
		Debug.Log ("Achievement Unlocked: " + this.key);
	}

	public static void incrementCount() {
		count++;;
	}

}
