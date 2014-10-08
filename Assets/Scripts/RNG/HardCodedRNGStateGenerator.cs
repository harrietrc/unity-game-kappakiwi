using UnityEngine;
using System.Collections;

public class HardCodedRNGStateGenerator : RNGStateGenerator {

	public RNGState currentRNGState { get; set; }
	public RNGState previousRNGState { get; set; }


	public HardCodedRNGStateGenerator(){
	}

	public void generateNextState(){
	}
}
