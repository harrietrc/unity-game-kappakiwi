using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AchievementManager : MonoBehaviour {

	private List<PlatformAchievement> paList  = new List<PlatformAchievement> ();

	public AchievementManager() {
		makePlatformAchievements ();
	}

	public void checkAchievements() {
		foreach (PlatformAchievement pa in paList) {
			Debug.Log (pa.getKey() + " " + PlayerPrefs.GetInt (pa.getKey ()));
		}
	}

	public void makePlatformAchievements() {
		for (int i = 20; i <= 100; i = i + 20 ) {
			string tempMsg = "Bounced on " + i + " platforms!";
			PlatformAchievement temp = new PlatformAchievement(tempMsg, i);
			paList.Add(temp);
		}
	}

	public void saveAchievementsToPersistence() {
		for(int i = 0; i < paList.Count; i++) {
			string key = paList[i].getKey ();
			bool hasKey = PlayerPrefs.HasKey(key);
			if (hasKey) {
				int isUnlocked = PlayerPrefs.GetInt (key);
				if (paList[i].isAchievementUnlocked() || isUnlocked == 1) {
					PlayerPrefs.SetInt(key,1); 
				}else{
					PlayerPrefs.SetInt(key,0);
				}
			}else{
				PlayerPrefs.SetInt (key, 0);
			}

			PlayerPrefs.Save ();
		}
	}

	public void incrementPlatformCount() {
		PlatformAchievement.incrementCount ();
	}
}
