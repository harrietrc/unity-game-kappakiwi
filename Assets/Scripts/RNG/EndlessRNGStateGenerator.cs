using UnityEngine;
using System.Collections;

public class EndlessRNGStateGenerator : RNGStateGenerator {

	public RNGState currentRNGState { get; set; }
	public RNGState previousRNGState { get; set; }
	public RNGState beginRNGState { get; set; }

	private float minXVariance = -.75f;
	private float maxXVariance = .75f;

	private float minYVariance = -1.0f;
	private float maxYVariance = 1.0f;

	public EndlessRNGStateGenerator(){
		currentRNGState = new RNGState ();
	}

	public void generateNextState(){
		previousRNGState = currentRNGState;
		currentRNGState = new RNGState ();

		int temp = Random.Range (1, 4);

		switch (temp) {
		case 1:
			currentRNGState.bias = currentRNGState.leftBias;
			break;
		case 2:
			currentRNGState.bias = currentRNGState.centerBias;
			break;
		case 3:
			currentRNGState.bias = currentRNGState.rightBias;
			break;
				}

		currentRNGState.platformCount = Random.Range (2, 6);
		while (currentRNGState.platformCount == previousRNGState.platformCount) {
			currentRNGState.platformCount = Random.Range (2, 6);
				}
		currentRNGState.enemyCount = Random.Range (0, 3);
		currentRNGState.itemCount = currentRNGState.platformCount;
		currentRNGState.obstacleCount = Random.Range (0, 2);
		
		currentRNGState.platformXVariance = new float[currentRNGState.platformCount];
		currentRNGState.platformYVariance = new float[currentRNGState.platformCount];
		currentRNGState.enemyXVariance = new float[currentRNGState.enemyCount];
		currentRNGState.enemyYVariance = new float[currentRNGState.enemyCount];
		currentRNGState.itemXVariance = new float[currentRNGState.itemCount];
		currentRNGState.itemYVariance = new float[currentRNGState.itemCount];
		currentRNGState.obstacleXVariance = new float[currentRNGState.obstacleCount];
		currentRNGState.obstacleYVariance = new float[currentRNGState.obstacleCount];

		currentRNGState.platformTypes = new RNGState.platformType[currentRNGState.platformCount];
		currentRNGState.enemyTypes = new RNGState.enemyType[currentRNGState.enemyCount];
		currentRNGState.itemTypes = new RNGState.itemType[currentRNGState.itemCount];
		currentRNGState.obstacleTypes = new RNGState.obstacleType[currentRNGState.obstacleCount];
		
		try{
			if(Mathf.Max(previousRNGState.platformYVariance) > .75){
				minYVariance = -.25f;
			} else {
				minYVariance = -1.0f;
			}
			
			if(Mathf.Max(previousRNGState.platformYVariance) < -.75f){
				maxYVariance = .25f;
			} else {
				maxYVariance = 1.0f;
			}
		} catch (System.Exception e){}

		for(int i = 0; i < currentRNGState.platformCount; i++){

			if(currentRNGState.platformCount < 4){
				currentRNGState.platformXVariance[i] = Random.Range(minXVariance, maxXVariance) + currentRNGState.bias;
			} else {
				currentRNGState.platformXVariance[i] = Random.Range(minXVariance, maxXVariance);
			}


			currentRNGState.platformYVariance[i] = Random.Range(minYVariance, maxYVariance);
			
			currentRNGState.platformTypes[i] = DifficultyManager.Instance.createPlatformType();
		}
		for(int i = 0; i < currentRNGState.itemCount; i++){ 
			currentRNGState.itemXVariance[i] = currentRNGState.platformXVariance[i];
			currentRNGState.itemYVariance[i] = currentRNGState.platformYVariance[i];
			
			currentRNGState.itemTypes[i] = DifficultyManager.Instance.createItemType();
		}
		for(int i = 0; i < currentRNGState.obstacleCount; i++){ 
			currentRNGState.obstacleXVariance[i] = Random.Range(minXVariance, maxXVariance);
			currentRNGState.obstacleYVariance[i] = Mathf.Max(currentRNGState.platformYVariance) + Random.Range(minYVariance, maxYVariance);

			int index = 0;
			index = Random.Range(0,8);
			switch(index){
			case 0:
				currentRNGState.obstacleTypes[i] = RNGState.obstacleType.turret;
				break;
			case 1:
				currentRNGState.obstacleTypes[i] = RNGState.obstacleType.none;
				break;
			case 2:
				currentRNGState.obstacleTypes[i] = RNGState.obstacleType.none;
				break;
			case 3:
				currentRNGState.obstacleTypes[i] = RNGState.obstacleType.none;
				break;
			case 4:
				currentRNGState.obstacleTypes[i] = RNGState.obstacleType.none;
				break;
			case 5:
				currentRNGState.obstacleTypes[i] = RNGState.obstacleType.none;
				break;
			case 6:
				currentRNGState.obstacleTypes[i] = RNGState.obstacleType.none;
				break;
			case 7:
				currentRNGState.obstacleTypes[i] = RNGState.obstacleType.none;
				break;
			}
		}

		for(int i = 0; i < currentRNGState.enemyCount; i++){ 
			currentRNGState.enemyXVariance[i] = Random.Range(minXVariance, maxXVariance);
			currentRNGState.enemyYVariance[i] = Mathf.Max(currentRNGState.platformYVariance) + Random.Range(minYVariance, maxYVariance);
			
			currentRNGState.enemyTypes[i] = DifficultyManager.Instance.createEnemyType();
		}
	}

	public void generateBeginState(){

		beginRNGState = new RNGState ();

		beginRNGState.ticks = 20;

	}
	
}
