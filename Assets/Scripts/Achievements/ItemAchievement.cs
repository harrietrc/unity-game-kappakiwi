using UnityEngine;
using System.Collections;

//Achievement subclass which is unlocked by picking up a certain number of items
public class ItemAchievement : Achievement {
	
	//Items needed to unlock an achievement
	private int countToUnlock;
	private static string totalItems = "TotalItems";

	public ItemAchievement(string key, int countToUnlock) {
		this.isUnlocked = false;
		this.key = key;
		this.countToUnlock = countToUnlock;
	}

	//Overriden abstract method
	//The achievement is unlocked if the 'count' (current no. of items) is greater than or equal to
	//'countToUnlock'
	public override bool isAchievementUnlocked() {
		int currentItems = PlayerPrefs.GetInt (totalItems);

		if (currentItems >= this.countToUnlock && !this.isUnlocked) {
			this.isUnlocked = true;
		}
		return this.isUnlocked;
	}

	//Increment static variable count
	public static void incrementItemCount() {
		int currentItems = PlayerPrefs.GetInt (totalItems);
		currentItems++;
		PlayerPrefs.SetInt (totalItems, currentItems);
	}

	public void makeTotalItemsPersistence() {
		bool hasKey = PlayerPrefs.HasKey (totalItems);
		
		if (!hasKey) {
			PlayerPrefs.SetInt (totalItems, 0);	
		}
	}

	public int getCountToUnlock() {
		return this.countToUnlock;
	}
}