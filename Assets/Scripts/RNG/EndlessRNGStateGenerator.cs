using UnityEngine;
using System.Collections;

public class EndlessRNGStateGenerator : RNGStateGenerator {

	public RNGState currentRNGState { get; set; }
	public RNGState previousRNGState { get; set; }
	public RNGState beginRNGState { get; set; }

	public EndlessRNGStateGenerator(){
		currentRNGState = new RNGState ();
	}

	public void generateNextState(){
		previousRNGState = currentRNGState;
		currentRNGState = new RNGState ();

		int temp = Random.Range (1, 4);

		switch (temp) {
		case 1:
			currentRNGState.bias = RNGState.Bias.left;
			break;
		case 2:
			currentRNGState.bias = RNGState.Bias.center;
			break;
		case 3:
			currentRNGState.bias = RNGState.Bias.right;
			break;
				}
		
		currentRNGState.platformCount = Random.Range (1, 6);
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

			currentRNGState.platformXVariance[i] = Random.Range(-2.0f, 0.2f);
			currentRNGState.platformYVariance[i] = Random.Range(-2.0f, 0.2f);
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
