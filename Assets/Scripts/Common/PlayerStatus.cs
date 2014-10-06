using UnityEngine;
using System.Collections;

public class PlayerStatus {

	public float FitnessLevel{ get; set; }
	public float MaxFitnessLevel = 1.5f;
	public float MinFitenessLevel = 0.5f;

	public PlayerStatus(){
		FitnessLevel = 1.0f;
		}

}
