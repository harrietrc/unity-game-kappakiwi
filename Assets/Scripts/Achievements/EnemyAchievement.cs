using UnityEngine;
using System.Collections;

public class EnemyAchievement : Achievement {

	private int countToUnlock;
	private static string totalEnemies = "TotalEnemies";

	public EnemyAchievement (string key, int countToUnlock)
	{
		this.isUnlocked = false;
		this.countToUnlock = countToUnlock;
		this.key = key;
	}

	public override bool isAchievementUnlocked() {
		int currentItems = PlayerPrefs.GetInt (totalEnemies);
		
		if (currentItems >= this.countToUnlock && !this.isUnlocked) {
			this.isUnlocked = true;
		}
		return this.isUnlocked;
	}

	public static void incrementEnemyCount() {
		int currentEnemies = PlayerPrefs.GetInt (totalEnemies);
		currentEnemies++;
		PlayerPrefs.SetInt (totalEnemies, currentEnemies);
	}

	public void makeTotalEnemiesPersistence() {
		bool hasKey = PlayerPrefs.HasKey (totalEnemies);
		
		if (!hasKey) {
			PlayerPrefs.SetInt (totalEnemies, 0);	
		}
	}
	
	public int getCountToUnlock() {
		return this.countToUnlock;
	}

}
