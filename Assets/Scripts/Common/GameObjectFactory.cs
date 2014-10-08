using UnityEngine;
using System.Collections;


public class GameObjectFactory : MonoBehaviour {

	private GameObject newPlatform;
	private int ypos = -2;
	private int xpos = 2;

	private RNGStateGenerator rng;

	
	GameObject currentPlatform;

	// Use this for initialization
	void Start () {




	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void setRNGDependency(RNGStateGenerator dependency){
		this.rng = dependency;
		}

	public void generateLevelStart(){

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

	public void generateTick(){
			hardCodedGenerateTickHook ();

		}

	private bool temp = true;
	private void hardCodedGenerateTickHook(){	
		if (temp) {
			if (Application.loadedLevelName != "level_one") {
						this.newPlatform = (GameObject)Instantiate (Resources.Load ("Prefabs/Platforms/" + "pref_standard_platform"));
						this.newPlatform.transform.position = new Vector3 (2, 9, 0);

						this.newPlatform = (GameObject)Instantiate (Resources.Load ("Prefabs/Platforms/" + "pref_standard_platform"));
						this.newPlatform.transform.position = new Vector3 (-2, 12, 0);
			}
				} else {
					
				}
		temp = !temp;
		}

	public GameObjectFactory(){
		}
}
