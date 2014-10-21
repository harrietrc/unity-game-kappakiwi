using UnityEngine;
using System.Collections;

/**
 *  Simple script that updates the item GameObject with the next frame of the animation. 
 * */
public class ItemAnimator : MonoBehaviour {

	private Sprite[] sprites;  // Should correspond with a field in the Item class
	public float framesPerSecond;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
	
		spriteRenderer = renderer as SpriteRenderer;
		sprites = gameObject.GetComponent<Item>().sprites; // Should be foolproof (i.e. only one Item script will be attached to a given GameObject)
	}
	
	// Update is called once per frame
	void Update () {
	
		int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
		index = index % sprites.Length;  // Loop back to the start of the array of sprites
		spriteRenderer.sprite = sprites[index];
	}
}
