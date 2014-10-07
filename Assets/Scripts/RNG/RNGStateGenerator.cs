using UnityEngine;
using System.Collections;

public class RNGStateGenerator {
	
	// Note: Random.Range(min, max) 
	// has overloaded methods, that returns the value in the both float and int
	// you can use Random.Range(min, max) directly in code anywhere
	// no need to call the method below actually
	
	public int rangeInt(int min, int max){
		// returns a random value of integer within given the range
		
		// formula of creating number in a range is 
		// (int)(random() * (max - min) + min)
		
		int z = (int) ( Random.value * (max - min) + min);
		return z;
		// ex: range is 5 and 9, value returns always between [0.0, 1.0)
		// say that upper limit very close to 1, for ex. 0.9999999, take it as 1
		// z = ( 1 * (9-5) + 5) --> yields to = 9 
		// if random value is 0, then low value is 5
	}
	
	public Vector2 getRandomV2(){
		// returns a Vector2 that x and y in range of -10 , +10
		Vector2  randomV2 = new Vector2(Random.Range(-10.0, 10.0), 0, Random.Range(-10.0, 10.0));
		return randomV2;
	}
	
	public Vector2 getRandomV2(float x, float y){
		//returns a Vector2 instance given range of x, y float values
		Vector2 randomV2 = new Vector2(Random.Range(x, y), 0, Random.Range(x, y));
		return randomV2;
	}
	
	public Vector3 getRandomV3(float x, float y){
		// returns aVector3 instance of x, y and z=0 values
		Vector2 randomV3 = new Vector3(Random.Range(x, y), 0, Random.Range(x, y), 0);
		return randomV3;
	}
	
	public Vector3 getRandomV3(float x, float y, float z){
		// returns aVector3 instance of x, y and z values
		Vector2 randomV3 = new Vector3(Random.Range(x, y), 0, Random.Range(x, y), Random.Range(x, y));
		return randomV3;
	}

	public int getRandomInRange(int min, int max){
		
		
	}
	
}
