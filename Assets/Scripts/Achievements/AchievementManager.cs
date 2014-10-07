using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AchievementManager : MonoBehaviour {

	private List<PlatformAchievement> paList = new List<PlatformAchievement>();

	public AchievementManager() {
		makePlatformAchievements ();
	}

	public void checkForAchievements() {
		foreach (PlatformAchievement pa in paList) {
			pa.IsAchievementUnlocked();
		}
	}

	public void makePlatformAchievements() {
		for (int i = 10; i < 100; i = i + 10 ) {
			string tempMsg = "You have bounced on " + i + " platforms!";
			PlatformAchievement temp = new PlatformAchievement(tempMsg, i);
			paList.Add(temp);
		}
	}

	public void incrementPlatformCount() {
		PlatformAchievement.incrementCount ();
	}
}
