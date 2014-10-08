using UnityEngine;
using System.Collections;

public interface RNGStateGenerator {

	RNGState currentRNGState { get; set; }
	RNGState previousRNGState { get; set; }

	void generateNextState();

}
