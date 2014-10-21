using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour {
	
	private static BackgroundMusic instance = null;
	
	public static BackgroundMusic Instance {
		get { return instance; }
	}
	
	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		
	}
	
	void Awake() {
		
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
		
	}
}
