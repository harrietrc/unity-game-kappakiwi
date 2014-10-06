using UnityEngine;
using System.Collections;

public class ScreenShifter : MonoBehaviour {

	private Object[] gameObjectsOnScreen;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public ScreenShifter() {
		}

	public void shiftScreen(){
		gameObjectsOnScreen = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
		}

}
