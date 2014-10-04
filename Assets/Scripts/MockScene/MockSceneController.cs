using UnityEngine;
using System.Collections;

public class MockSceneController : MonoBehaviour {

	private GameObject MockSinglePlatform;

	// Use this for initialization
	void Start () {
		InstantiateMockObjects ();
	}

	void InstantiateMockObjects()
	{
		// Should use our factory to instantiate
		this.MockSinglePlatform = (GameObject) Instantiate(Resources.Load ("Prefabs/Mock/" + "pref_platform"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
