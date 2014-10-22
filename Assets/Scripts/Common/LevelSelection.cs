using UnityEngine;
using System.Collections;

public enum Theme {story, xmas}
public enum GameMode {endless, story, scenario}

public class LevelSelection{

	public static Theme CURRENT_THEME = Theme.story;
	public static GameMode CURRENT_GAMEMODE = GameMode.story;
	public static int LEVEL = 1;

	private LevelSelection(){

	}

}
