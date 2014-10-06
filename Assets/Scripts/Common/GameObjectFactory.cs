using UnityEngine;
using System.Collections;

public class GameObjectFactory : MonoBehaviour {

	private GameObject newPlatform;
	private int ypos = -2;
	private int xpos = 2;

	private RNGStateGenerator rng;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void setRNGDependency(RNGStateGenerator dependency){
		this.rng = dependency;
		}

	public void generateTick(){
		if (1 == 1) {
			this.newPlatform = (GameObject) Instantiate(Resources.Load ("Prefabs/Platforms/" + "pref_standard_platform"));
			this.newPlatform.transform.position = new Vector3(xpos,ypos,0);
			ypos = ypos + 1;
			xpos = xpos + 1;
				}

		}

	public GameObjectFactory(){
		}
}
