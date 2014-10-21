using UnityEngine;
using System.Collections;

public class EndlessRNGStateGenerator : RNGStateGenerator {

	public RNGState currentRNGState { get; set; }
	public RNGState previousRNGState { get; set; }
	public RNGState beginRNGState { get; set; }

	private float minXVariance = -1.0f;
	private float maxXVariance = 1.0f;

	private float minYVariance = -2.0f;
	private float maxYVariance = 2.0f;

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
			currentRNGState.platformCount = Random.Range (1, 6);
				}
		currentRNGState.enemyCount = Random.Range (0, 3);
		currentRNGState.itemCount = Random.Range (0, currentRNGState.platformCount + 1);
		currentRNGState.obstacleCount = Random.Range (0, currentRNGState.platformCount - currentRNGState.itemCount + 1);
		
		currentRNGState.platformXVariance = new float[currentRNGState.platformCount];
		currentRNGState.platformYVariance = new float[currentRNGState.platformCount];
		currentRNGState.enemyXVariance = new float[currentRNGState.enemyCount];
		currentRNGState.enemyYVariance = new float[currentRNGState.enemyCount];
		currentRNGState.itemXVariance = new float[currentRNGState.itemCount];
		currentRNGState.itemYVariance = new float[currentRNGState.itemCount];
		currentRNGState.obstacleXVariance = new float[currentRNGState.obstacleCount];
		currentRNGState.obstacleYVariance = new float[currentRNGState.obstacleCount];

		for(int i = 0; i < currentRNGState.platformCount; i++){

			if(currentRNGState.platformCount < 4){
				currentRNGState.platformXVariance[i] = Random.Range(minXVariance, maxXVariance) + currentRNGState.bias;
			} else {
				currentRNGState.platformXVariance[i] = Random.Range(minXVariance, maxXVariance);
			}
			try{
				if(Mathf.Max(previousRNGState.platformYVariance) > 1.5f){
					minYVariance = -1.0f;
				} else {
					minYVariance = -2.0f;
				}

				if(Mathf.Max(previousRNGState.platformYVariance) < -1.5f){
					maxYVariance = 1.0f;
				} else {
					maxYVariance = 2.0f;
				}
			} catch (System.Exception e){}

			currentRNGState.platformYVariance[i] = Random.Range(minYVariance, maxYVariance);
			if(i < currentRNGState.itemCount){
//				currentRNGState.itemXVariance[i] = currentRNGState.platformXVariance[i];
//				currentRNGState.itemYVariance[i] = currentRNGState.platformYVariance[i];
			} else if (currentRNGState.obstacleCount > 0) {
//				currentRNGState.obstacleXVariance[i - currentRNGState.itemCount + 1] = currentRNGState.platformXVariance[i];
//				currentRNGState.obstacleYVariance[i - currentRNGState.itemCount + 1] = currentRNGState.platformYVariance[i];
			}
		}
		for(int i = 0; i < currentRNGState.enemyCount; i++){ 
			currentRNGState.enemyXVariance[i] = Random.Range(-2.0f, 0.2f);
			currentRNGState.enemyYVariance[i] = Mathf.Max(currentRNGState.platformYVariance) + Random.Range(0.0f, 0.2f);
		}
	}

	public void generateBeginState(){

		beginRNGState = new RNGState ();

		beginRNGState.ticks = 20;

	}
	
}
