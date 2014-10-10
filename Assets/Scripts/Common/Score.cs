using UnityEngine;
using System.Collections;

public class Score {

	private int score;

	public Score() {
		score = 0;
	}

	public void increaseScoreByPlatform() {
		this.score = score + 10;
	}
	
	public void increaseScoreByHealthyFood() {
		this.score = score + 5;
	}
	
	public void decreaseScoreByJunkFood() {
		this.score = score - 5;
	}

	public int getScore() {
		return this.score;
	}
}
