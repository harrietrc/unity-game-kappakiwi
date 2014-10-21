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

		hardCodedLevelStartHook ();
		}

	private void hardCodedLevelStartHook(){

		currentPlatform = (GameObject) Instantiate(Resources.Load ("Prefabs/Platforms/" + "pref_standard_platform"));
		Vector3 temp = new Vector3(2,2,0);
		currentPlatform.transform.position += temp;

		currentPlatform = (GameObject) Instantiate(Resources.Load ("Prefabs/Platforms/" + "pref_standard_platform"));
		temp = new Vector3(-2,4,0);
		currentPlatform.transform.position += temp;

		currentPlatform = (GameObject) Instantiate(Resources.Load ("Prefabs/Platforms/" + "pref_standard_platform"));
		temp = new Vector3(2,6,0);
		currentPlatform.transform.position += temp;

		currentPlatform = (GameObject) Instantiate(Resources.Load ("Prefabs/Platforms/" + "pref_standard_platform"));
		temp = new Vector3(-2,8,0);
		currentPlatform.transform.position += temp;

		currentPlatform = (GameObject) Instantiate(Resources.Load ("Prefabs/Platforms/" + "pref_standard_platform"));
		temp = new Vector3(2,10,0);
		currentPlatform.transform.position += temp;

		currentPlatform = (GameObject) Instantiate(Resources.Load ("Prefabs/Platforms/" + "pref_standard_platform"));
		temp = new Vector3(-2,12,0);
		currentPlatform.transform.position += temp;

		currentPlatform = (GameObject) Instantiate(Resources.Load ("Prefabs/Platforms/" + "pref_standard_platform"));
		temp = new Vector3(2,14,0);
		currentPlatform.transform.position += temp;

		currentPlatform = (GameObject) Instantiate(Resources.Load ("Prefabs/Platforms/" + "pref_standard_platform"));
		temp = new Vector3(-2,16,0);
		currentPlatform.transform.position += temp;

		currentPlatform = (GameObject) Instantiate(Resources.Load ("Prefabs/Platforms/" + "pref_standard_platform"));
		temp = new Vector3(2,18,0);
		currentPlatform.transform.position += temp;

		currentPlatform = (GameObject) Instantiate(Resources.Load ("Prefabs/Platforms/" + "pref_standard_platform"));
		temp = new Vector3(-2,20,0);
		currentPlatform.transform.position += temp;

	
		}

	public override void generateTick(){
			hardCodedGenerateTickHook ();
		}

	private void hardCodedGenerateTickHook(){	
			this.newPlatform = (GameObject)Instantiate (Resources.Load ("Prefabs/Platforms/" + "pref_standard_platform"));
			this.newPlatform.transform.position = new Vector3 (2, 18, 0);

			this.newPlatform = (GameObject)Instantiate (Resources.Load ("Prefabs/Platforms/" + "pref_standard_platform"));
			this.newPlatform.transform.position = new Vector3 (-2, 20, 0);
			}


}
