using UnityEngine;
using System.Collections;

public interface RNGStateGenerator {

	RNGState currentRNGState { get; set; }
	RNGState previousRNGState { get; set; }
	RNGState beginRNGState { get; set; }

	void generateNextState();

	void generateBeginState();

}
