
using System;

public class Highscore{
	private int highscore;
	private string name;

	public Highscore (int highscore, string name){
		this.highscore = highscore;
		this.name = name;
	}

	public int getHighscore() {
		return this.highscore;
	}

	public string getName() {
		return this.name;
	}
}


