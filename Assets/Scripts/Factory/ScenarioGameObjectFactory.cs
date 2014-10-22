using UnityEngine;
using System.Collections;


public class ScenarioGameObjectFactory : GameObjectFactory {

	private GameObject newPlatform;
	private GameObject newItem;
	private GameObject newEnemy;
	private GameObject newObstacle;

	private int ypos = -2;
	private int xpos = 2;

	private RNGStateGenerator rng = new EndlessRNGStateGenerator();

	private int length;

	
	GameObject currentPlatform;

	public ScenarioGameObjectFactory(){
		rng.generateNextState ();

		switch (DifficultyManager.Instance.CURRENT_DIFFICULTY) {
		case DifficultyManager.Difficulty.easy:
			length = 20;
			break;
		case DifficultyManager.Difficulty.medium:
			length = 50;
			break;
		case DifficultyManager.Difficulty.hard:
			length = 100;
			break;
				}
	}

	public void setRNGDependency(RNGStateGenerator dependency){
		this.rng = dependency;
		}

	public override void generateLevelStart(){
		float y = -1.0f;
		for (int i = 0; i < 9; i ++) {
			rng.generateNextState();
			float lastX = generateOneTickPlatforms(y, (i==0));
			if(i == 0){
				GameObject player = GameObject.FindGameObjectWithTag (Tags.TAG_PLAYER);
				Vector3 temp = new Vector3(lastX + rng.currentRNGState.platformXVariance[rng.currentRNGState.platformCount-1],rng.currentRNGState.platformYVariance[rng.currentRNGState.platformCount-1],0.0f);
				player.transform.Translate(temp);
			}
			generateOneTickItems (y+.75f);
			generateOneTickEnemies (y,(i==0));
		//	generateOneTickObstacles (y);
			y += 2.75f;
		}
	}


	public override void generateTick(){
		for (int i = 0; i < this.length; i++) {
			rng.generateNextState ();
			
			float height = 17.0f;
			generateOneTickPlatforms (height, false);
			generateOneTickItems (height+.75f);
			generateOneTickEnemies (height,false);
				}
	}
}
