using UnityEngine;
using System.Collections;

public class PlatformAchievement : MonoBehaviour {

	private bool isUnlocked;
	private int countToUnlock;
	private string message;
	private static int count;

	public	PlatformAchievement(string message, int countToUnlock) {
		this.isUnlocked = false;
		count = 0;
		this.countToUnlock = countToUnlock;
		this.message = message;
	}

	public bool IsAchievementUnlocked() {
		if (count >= this.countToUnlock && !this.isUnlocked) {
			this.isUnlocked = true;
			displayMessage();
		}

		return this.isUnlocked;
	}

	public void displayMessage() {
		Debug.Log ("Achievement Unlocked: " + this.message);
	}

	public static void incrementCount() {
		count++;;
	}
}
