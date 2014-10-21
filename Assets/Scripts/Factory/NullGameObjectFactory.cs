using UnityEngine;
using System.Collections;


public class NullGameObjectFactory : GameObjectFactory {

	private GameObject newPlatform;
	private int ypos = -2;
	private int xpos = 2;

	private RNGStateGenerator rng;	
	GameObject currentPlatform;


	public NullGameObjectFactory(){
	}

	public void setRNGDependency(RNGStateGenerator dependency){
		this.rng = dependency;
		}

	public override void generateLevelStart(){

		}

	public override void generateTick(){

		}

	private bool temp = true;
	private void hardCodedGenerateTickHook(){
	}
}


