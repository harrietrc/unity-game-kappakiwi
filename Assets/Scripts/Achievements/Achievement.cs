using UnityEngine;
using System.Collections;

public abstract class Achievements {

	protected bool isUnlocked;
	protected string key;

	public string getKey() {
		return this.key;
	}

	abstract public bool isAchievementUnlocked ();
}
