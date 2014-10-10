using UnityEngine;
using System.Collections;

//Achievement subclass which is unlocked by picking up a certain number of items
public class ItemAchievement : Achievement {

	//Static variable representing items picked up in one level
	private static int count;
	//Items needed to unlock an achievement
	private int countToUnlock;

	public ItemAchievement(string key, int countToUnlock) {
		this.isUnlocked = false;
		count = 0;
		this.key = key;
		this.countToUnlock = countToUnlock;
	}

	//Overriden abstract method
	//The achievement is unlocked if the 'count' (current no. of items) is greater than or equal to
	//'countToUnlock'
	public override bool isAchievementUnlocked() {
		if (count >= this.countToUnlock && !this.isUnlocked) {
			this.isUnlocked = true;
		}
		return this.isUnlocked;
	}

	//Increment static variable count
	public static void incrementItemCount() {
		ItemAchievement.count++;
	}

	public int getCountToUnlock() {
		return this.countToUnlock;
	}
}