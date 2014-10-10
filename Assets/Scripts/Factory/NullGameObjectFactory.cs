using UnityEngine;
using System.Collections;


public class NullGameObjectFactory : GameObjectFactory {

	private GameObject newPlatform;
	private int ypos = -2;
	private int xpos = 2;

	private RNGStateGenerator rng;	
	GameObject currentPlatform;


	public NullGameObjectFactory(){
		
		
		switch (LevelSelection.CURRENT_THEME) {
		case Theme.endless:
			rng = new EndlessRNGStateGenerator();
			break;
		case Theme.story:
			rng = new DefaultRNGStateGenerator();
			break;
		case Theme.xmas:
			rng = new DefaultRNGStateGenerator();
			break;
		}
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


