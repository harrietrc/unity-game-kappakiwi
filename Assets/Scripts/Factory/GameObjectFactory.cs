using UnityEngine;
using System.Collections;

public class GameObjectFactory : MonoBehaviour{

	protected GameObject newPlatform;
	protected GameObject newItem;
	protected GameObject newEnemy;
	protected GameObject newObstacle;
	
	protected RNGStateGenerator rng = new EndlessRNGStateGenerator();
	
	protected GameObject currentPlatform;


	public virtual void generateLevelStart() {}
	public virtual void generateTick(){}

	protected float generateOneTickPlatforms(float y, bool firstTick){
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
			if(!firstTick){
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
			} else {
				this.newPlatform = (GameObject)Instantiate (Resources.Load ("Prefabs/Platforms/" + "pref_standard_platform"));
			}
			
			this.newPlatform.transform.position = new Vector3 (currentX + rng.currentRNGState.platformXVariance[j], y + rng.currentRNGState.platformYVariance[j], 0.0f);
			
			currentX += 4.0f;
		}
		
		return currentX - 4.0f;
	}
	
	protected void generateOneTickItems(float y){
		
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
				this.newItem = (GameObject)Instantiate (Resources.Load ("Prefabs/Items/" + "pref_healthyfood"));
				break;
			case RNGState.itemType.junk:
				this.newItem = (GameObject)Instantiate (Resources.Load ("Prefabs/Items/" + "pref_junkfood"));
				break;
			case RNGState.itemType.none:
				this.newItem = null;
				var temp = 0;
				break;
			}
			try{
				this.newItem.transform.position = new Vector3 (currentX + rng.currentRNGState.itemXVariance[j], y + rng.currentRNGState.itemYVariance[j], 0.0f);
			}catch (System.Exception e) {}
			currentX += 4.0f;
		}
		
	}
	
	protected void generateOneTickEnemies(float y, bool firstTick){
		float currentX = 0.0f;
		switch (rng.currentRNGState.enemyCount) {
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
		for (int j = 0; j < rng.currentRNGState.enemyCount; j++) {
			if(!firstTick){
				switch(rng.currentRNGState.enemyTypes[j]){
				case RNGState.enemyType.patrol:
					this.newEnemy = (GameObject)Instantiate (Resources.Load ("Prefabs/Enemies/" + "pref_basic_enemy"));
					break;
				case RNGState.enemyType.falling:
					this.newEnemy = (GameObject)Instantiate (Resources.Load ("Prefabs/Enemies/" + "pref_falling_enemy"));
					break;
				case RNGState.enemyType.shooting:
					this.newEnemy = (GameObject)Instantiate (Resources.Load ("Prefabs/Enemies/" + "Shooting_enemy"));
					break;
				case RNGState.enemyType.none:
					this.newEnemy = null;
					var temp = 0;
					break;
				}
			} 
			try{
				this.newEnemy.transform.position = new Vector3 (currentX + rng.currentRNGState.enemyXVariance[j], y + rng.currentRNGState.enemyYVariance[j], 0.0f);
			}catch (System.Exception e) {}
			currentX += 4.0f;
		}
	}

		
}