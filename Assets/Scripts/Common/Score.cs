using UnityEngine;
using System.Collections;

public class Score {

	private int score;
	private int multiplier;

	public Score() {
		score = 0;
		multiplier = 1;
	}

	//Increase score by 100 after jumping on a platform
	public void increaseScoreByPlatform() {
		this.score = score + (100 * multiplier);
	}

	//Increase score by 50 when picking up healthy food
	public void increaseScoreByHealthyFood() {
		this.score = score + (50 * multiplier);
		if (multiplier < Constants.MAX_MULTIPLIER) { //Max multiplier = 5
			multiplier++;
		}
	}

	//Reset multiplier when junk food is picked up
	public void decreaseScoreByJunkFood() {
		multiplier = 1;
	}

	public int getScore() {
		return this.score;
	}

	public int getMultiplier() {
		return this.multiplier;
	}
}
