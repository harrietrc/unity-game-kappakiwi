using UnityEngine;
using System.Collections;

public class DifficultyManager {

	public enum Difficulty {easy, medium, hard}
	public enum EnemyCount {low, medium, high}
	public enum ItemCount {low, medium, high}
	public enum LevelLength {low, medium, high}

	public Difficulty CURRENT_DIFFICULTY = Difficulty.easy;
	public EnemyCount CURRENT_ENEMYCOUNT = EnemyCount.low;
	public ItemCount CURRENT_ITEMCOUNT = ItemCount.low;
	public LevelLength CURRENT_LEVELLENGTH = LevelLength.low;

	private static DifficultyManager instance;
	
	private DifficultyManager() {}
	
	public static DifficultyManager Instance
	{
		get 
		{
			if (instance == null)
			{
				instance = new DifficultyManager();
			}
			return instance;
		}
	}

	public RNGState.itemType createItemType(){
		switch (CURRENT_ITEMCOUNT) {
			case ItemCount.low:
				int index = 0;
				index = Random.Range(0,7);
				switch(index){
				case 0:
				return RNGState.itemType.none;
					break;
				case 1:
				return RNGState.itemType.none;
					break;
				case 2:
					return RNGState.itemType.none;
					break;
				case 3:
					return RNGState.itemType.none;
					break;
				case 4:
					return RNGState.itemType.none;
					break;
				case 5:
					return RNGState.itemType.none;
					break;
				case 6:
					return RNGState.itemType.none;
					break;
				}
				break;
			case ItemCount.medium:
				index = Random.Range(0,5);
				switch(index){
				case 0:
					return RNGState.itemType.healthy;
					break;
				case 1:
					return RNGState.itemType.junk;
					break;
				case 2:
					return RNGState.itemType.none;
					break;
				case 3:
					return RNGState.itemType.none;
					break;
				case 4:
					return RNGState.itemType.none;
					break;
				}
				break;
		case ItemCount.high:
			index = Random.Range(0,3);
				switch(index){
				case 0:
					return RNGState.itemType.healthy;
					break;
				case 1:
					return RNGState.itemType.junk;
					break;
				case 2:
					return RNGState.itemType.none;
					break;
				}
			break;
	}
		return RNGState.itemType.none;

	
	}

	public RNGState.enemyType createEnemyType(){
		switch (CURRENT_ENEMYCOUNT) {
		case EnemyCount.low:
			int index = 0;
			index = Random.Range(0,13);
			switch(index){
			case 0:
				return RNGState.enemyType.none;
				break;
			case 1:
				return RNGState.enemyType.none;
				break;
			case 2:
				return RNGState.enemyType.none;
				break;
			case 3:
				return  RNGState.enemyType.none;
				break;
			case 4:
				return RNGState.enemyType.none;
				break;
			case 5:
				return RNGState.enemyType.none;
				break;
			case 6:
				return RNGState.enemyType.none;
				break;
			case 8:
				return RNGState.enemyType.none;
				break;
			case 9:
				return RNGState.enemyType.none;
				break;
			case 10:
				return RNGState.enemyType.none;
				break;
			case 11:
				return RNGState.enemyType.none;
				break;
			case 12:
				return RNGState.enemyType.none;
				break;
				
			}
			break;
		case EnemyCount.medium:
			index = 0;
			index = Random.Range(0,8);
			switch(index){
			case 0:
				return RNGState.enemyType.falling;
				break;
			case 1:
				return RNGState.enemyType.patrol;
				break;
			case 2:
				return RNGState.enemyType.shooting;
				break;
			case 3:
				return  RNGState.enemyType.stationary;
				break;
			case 4:
				return RNGState.enemyType.none;
				break;
			case 5:
				return RNGState.enemyType.none;
				break;
			case 6:
				return RNGState.enemyType.none;
				break;
			case 7:
				return RNGState.enemyType.none;
				break;
				
			}
			break;
		case EnemyCount.high:
			index = 0;
			index = Random.Range(0,6);
			switch(index){
			case 0:
				return RNGState.enemyType.falling;
				break;
			case 1:
				return RNGState.enemyType.patrol;
				break;
			case 2:
				return RNGState.enemyType.shooting;
				break;
			case 3:
				return  RNGState.enemyType.stationary;
				break;
			case 4:
				return RNGState.enemyType.none;
				break;
			case 5:
				return RNGState.enemyType.none;
				break;
			}
			break;
		}
		return RNGState.enemyType.none;

	}

	public RNGState.platformType createPlatformType(){
		switch (CURRENT_DIFFICULTY) {
		case Difficulty.easy:
			int index = 0;
			index = Random.Range(0,8);
			switch(index){
			case 0:
				return RNGState.platformType.standard;
				break;
			case 1:
				return RNGState.platformType.standard;
				break;
			case 2:
				return RNGState.platformType.standard;
				break;
			case 3:
				return RNGState.platformType.standard;
				break;
			case 4:
				return RNGState.platformType.standard;
				break;
			case 5:
				return RNGState.platformType.standard;
				break;
			case 6:
				return RNGState.platformType.standard;
				break;
			case 7:
				return RNGState.platformType.standard;
				break;
			}
			break;
		case Difficulty.medium:
			index = 0;
			index = Random.Range(0,5);
			switch(index){
			case 0:
				return RNGState.platformType.collapsing;
				break;
			case 1:
				return RNGState.platformType.moving;
				break;
			case 2:
				return RNGState.platformType.standard;
				break;
			case 3:
				return RNGState.platformType.standard;
				break;
			case 4:
				return RNGState.platformType.standard;
				break;
			}
			break;
		case Difficulty.hard:
			index = 0;
			index = Random.Range(0,3);
			switch(index){
			case 0:
				return RNGState.platformType.collapsing;
				break;
			case 1:
				return RNGState.platformType.moving;
				break;
			case 2:
				return RNGState.platformType.standard;
				break;
			}
			break;
		}
		
		return RNGState.platformType.standard;
	}

	public int createLevelLength(){

		switch (CURRENT_LEVELLENGTH) {
		case LevelLength.low:
			return 1;
			break;
		case LevelLength.medium:
			return 50;
			break;
		case LevelLength.high:
			return 100;
			break;
		}
		return 20;
	}
}