using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScreenTransitionManager {

	private static ScreenTransitionManager instance;
	
	private ScreenTransitionManager() {}
	
	public static ScreenTransitionManager Instance
	{
		get 
		{
			if (instance == null)
			{
				instance = new ScreenTransitionManager();
			}
			return instance;
		}
	}

	public void loadLevel(int level, Theme theme){

		if (LevelSelection.CURRENT_GAMEMODE == GameMode.endless) {
						Application.LoadLevel ("scn_endless");
						return;
				} else if (LevelSelection.CURRENT_GAMEMODE == GameMode.scenario) {
						Application.LoadLevel("scn_scenario");
						return;
				}
		switch (LevelSelection.LEVEL) {
		case 1:
			Application.LoadLevel("level_one");
			break;
		case 2:
			Application.LoadLevel("level_two");
			break;
		case 3:
			Application.LoadLevel("level_two");
			break;
		}

		//DONT DELETE THIS
//		switch(LevelSelection.CURRENT_THEME){
//			
//		case Theme.endless:
//			loadLevel(LevelSelection.LEVEL);
//			break;
//		case Theme.story:
//			loadLevel(LevelSelection.LEVEL);
//			break;
//		case Theme.xmas:
//			loadLevel(LevelSelection.LEVEL);
//			break;
//			
//		}
	}


}
