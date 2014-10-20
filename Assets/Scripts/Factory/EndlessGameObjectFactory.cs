using UnityEngine;
using System.Collections;


public class EndlessGameObjectFactory : GameObjectFactory {

	private GameObject newPlatform;
	private int ypos = -2;
	private int xpos = 2;

	private RNGStateGenerator rng;

	
	GameObject currentPlatform;

	public EndlessGameObjectFactory(){
		
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

		hardCodedLevelStartHook ();
		}

	private void hardCodedLevelStartHook(){

		currentPlatform = (GameObject) Instantiate(Resources.Load ("Prefabs/Platforms/" + "pref_standard_platform"));
		Vector3 temp = new Vector3(2,3,0);
		currentPlatform.transform.position += temp;
//		currentPlatform.transform.parent = GameObject.FindGameObjectWithTag ("MainCamera" ).transform;

		currentPlatform = (GameObject) Instantiate(Resources.Load ("Prefabs/Platforms/" + "pref_standard_platform"));
		temp = new Vector3(-2,6,0);
		currentPlatform.transform.position += temp;
//		currentPlatform.transform.parent = GameObject.FindGameObjectWithTag ("MainCamera" ).transform;
	
		}

	public override void generateTick(){
			hardCodedGenerateTickHook ();

		}

	private bool temp = true;
	private void hardCodedGenerateTickHook(){	
		if (temp) {
						this.newPlatform = (GameObject)Instantiate (Resources.Load ("Prefabs/Platforms/" + "pref_standard_platform"));
						this.newPlatform.transform.position = new Vector3 (2, 9, 0);

						this.newPlatform = (GameObject)Instantiate (Resources.Load ("Prefabs/Platforms/" + "pref_standard_platform"));
						this.newPlatform.transform.position = new Vector3 (-2, 12, 0);
			} else {}
		temp = !temp;
		}


}
