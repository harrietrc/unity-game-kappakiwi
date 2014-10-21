using UnityEngine;
using System.Collections;


public class EndlessGameObjectFactory : GameObjectFactory {

	private GameObject newPlatform;
	private int ypos = -2;
	private int xpos = 2;

	private RNGStateGenerator rng = new EndlessRNGStateGenerator();

	
	GameObject currentPlatform;

	public EndlessGameObjectFactory(){

	}

	public void setRNGDependency(RNGStateGenerator dependency){
		this.rng = dependency;
		}

	public override void generateLevelStart(){
		float y = -1.0f;
		for (int i = 0; i < 7; i ++) {
			rng.generateNextState();
			float lastX = generateOneTickPlatforms(y);
			if(i == 0){
				GameObject player = GameObject.FindGameObjectWithTag (Tags.TAG_PLAYER);
				Vector3 temp = new Vector3(lastX + rng.currentRNGState.platformXVariance[rng.currentRNGState.platformCount-1],rng.currentRNGState.platformYVariance[rng.currentRNGState.platformCount-1],0.0f);
				player.transform.Translate(temp);
			}
			generateOneTickItems (y+.75f);
			generateOneTickEnemies (y);
			generateOneTickObstacles (y);
			y += 3.5f;
		}
	}


	public override void generateTick(){
		rng.generateNextState ();

		float height = 17.0f;
		generateOneTickPlatforms (height);
		generateOneTickItems (height+.75f);
		generateOneTickEnemies (height);
		generateOneTickObstacles (height);

	}


	private float generateOneTickPlatforms(float y){
		float currentX = 0.0f;
		switch (rng.currentRNGState.platformCount) {
		case(1):
			currentX = 0.0f;
			break;
		case(2):
			currentX = -2.0f;
			break;
		case(3):
			currentX = -4.0f;
			break;
		case(4):
			currentX = -6.0f;
			break;
		case(5):
			currentX = -8.0f;
			break;
		}
		
		for (int j = 0; j < rng.currentRNGState.platformCount; j++) {
			switch(rng.currentRNGState.platformTypes[j]){
			case RNGState.platformType.standard:
				this.newPlatform = (GameObject)Instantiate (Resources.Load ("Prefabs/Platforms/" + "pref_standard_platform"));
				break;
			case RNGState.platformType.collapsing:
				this.newPlatform = (GameObject)Instantiate (Resources.Load ("Prefabs/Platforms/" + "pref_collapsing_platform"));
				break;
			case RNGState.platformType.moving:
				this.newPlatform = (GameObject)Instantiate (Resources.Load ("Prefabs/Platforms/" + "pref_moving_platform"));
				break;
			}
			try{
				this.newPlatform.transform.position = new Vector3 (currentX + rng.currentRNGState.platformXVariance[j], y + rng.currentRNGState.platformYVariance[j], 0.0f);
			}catch (System.Exception e) {}
			currentX += 4.0f;
		}

		return currentX - 4.0f;
	}

	private void generateOneTickItems(float y){

		float currentX = 0.0f;
		switch (rng.currentRNGState.itemCount) {
		case(1):
			currentX = 0.0f;
			break;
		case(2):
			currentX = -2.0f;
			break;
		case(3):
			currentX = -4.0f;
			break;
		case(4):
			currentX = -6.0f;
			break;
		case(5):
			currentX = -8.0f;
			break;
		}
		for (int j = 0; j < rng.currentRNGState.itemCount; j++) {
			switch(rng.currentRNGState.itemTypes[j]){
			case RNGState.itemType.healthy:
				this.newPlatform = (GameObject)Instantiate (Resources.Load ("Prefabs/Items/" + "pref_healthyfood"));
				break;
			case RNGState.itemType.junk:
				this.newPlatform = (GameObject)Instantiate (Resources.Load ("Prefabs/Items/" + "pref_junkfood"));
				break;
			case RNGState.itemType.none:
				var temp = 0;
				break;
			}
			try{
				this.newPlatform.transform.position = new Vector3 (currentX + rng.currentRNGState.itemXVariance[j], y + rng.currentRNGState.itemYVariance[j], 0.0f);
			}catch (System.Exception e) {}
			currentX += 4.0f;
		}

	}

	private void generateOneTickEnemies(float y){
	}

	private void generateOneTickObstacles(float y){
	}


}
