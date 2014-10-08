using UnityEngine;
using System.Collections;


public abstract class Achievement {

	//Boolean which determines if this Achievement is unlocked by the player
	//true = unlocked, false = locked
	protected bool isUnlocked;

	//Unique key which determines an Achievement's identity
	protected string key;
	
	public string getKey() {
		return this.key;
	}

	//Abstract method to be implemented by classes which subclass Achievement
	//Different subclasses will have different ways to unlock the Achievement
	//Returns true if unlocked, false if locked
	abstract public bool isAchievementUnlocked ();
}
