using UnityEngine;
using System.Collections;

public class Score {

	private int score;
	private int multiplier;

	public Score() {
		score = 0;
		multiplier = 1;
	}

	//Increase score by 10 after jumping on a platform
	public void increaseScoreByPlatform() {
		this.score = score + (10 * multiplier);
	}

	//Increase score by 5 when picking up healthy food
	public void increaseScoreByHealthyFood() {
		this.score = score + (5 * multiplier);
		if (multiplier < Constants.MAX_MULTIPLIER) { //Max multiplier = 5
			multiplier++;
		}
	}

	//Decrease score by 5 when picking up junk food
	public void decreaseScoreByJunkFood() {
		this.score = score - (5 * multiplier);
		multiplier = 1;
	}

	public int getScore() {
		return this.score;
	}

	public int getMultiplier() {
		return this.multiplier;
	}
}
