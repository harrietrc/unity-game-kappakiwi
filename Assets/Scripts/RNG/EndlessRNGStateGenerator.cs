using UnityEngine;
using System.Collections;

public class EndlessRNGStateGenerator : RNGStateGenerator {

	public RNGState currentRNGState { get; set; }
	public RNGState previousRNGState { get; set; }
	public RNGState beginRNGState { get; set; }

	public EndlessRNGStateGenerator(){
		currentRNGState = new RNGState ();
	}

	public void generateNextState(){
		previousRNGState = currentRNGState;
		currentRNGState = new RNGState ();
	}

	public void generateBeginState(){
	}
	
}
