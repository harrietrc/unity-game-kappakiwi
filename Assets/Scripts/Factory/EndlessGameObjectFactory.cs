using UnityEngine;
using System.Collections;


public class EndlessGameObjectFactory : GameObjectFactory {


	public EndlessGameObjectFactory(){

	}

	public void setRNGDependency(RNGStateGenerator dependency){
		rng = dependency;
		}

	public override void generateLevelStart(){
		float y = -1.0f;
		for (int i = 0; i < 8; i ++) {
			rng.generateNextState();
			float lastX = generateOneTickPlatforms(y, (i==0));
			if(i == 0){
				GameObject player = GameObject.FindGameObjectWithTag (Tags.TAG_PLAYER);
				Vector3 temp = new Vector3(lastX + rng.currentRNGState.platformXVariance[rng.currentRNGState.platformCount-1],rng.currentRNGState.platformYVariance[rng.currentRNGState.platformCount-1],0.0f);
				player.transform.Translate(temp);
			}
			generateOneTickItems (y+.75f);
			generateOneTickEnemies (y,(i==0 || i == 1 || i == 2));
		//	generateOneTickObstacles (y);
			y += 2.75f;
		}
	}


	public override void generateTick(){
			rng.generateNextState ();
			
			float height = 17.0f;
			generateOneTickPlatforms (height, false);
			generateOneTickItems (height+.75f);
			generateOneTickEnemies (height,false);
	}





}
