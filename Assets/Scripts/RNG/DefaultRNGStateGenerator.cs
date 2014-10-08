using UnityEngine;
using System.Collections;

public class DefaultRNGStateGenerator : RNGStateGenerator {

	public RNGState currentRNGState { get; set; }
	public RNGState previousRNGState { get; set; }

	public DefaultRNGStateGenerator(){
		}

	public void generateNextState(){
	}
}
