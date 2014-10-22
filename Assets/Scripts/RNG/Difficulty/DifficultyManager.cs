using UnityEngine;
using System.Collections;

public class DifficultyManager {

	public enum Difficulty {easy, medium, hard}
	public enum EnemyCount {low, medium, high}
	public enum ItemCount {low, medium, high}
	public enum LevelLength {low, medium, high}

	public Difficulty CURRENT_DIFFICULTY = Difficulty.medium;
	public EnemyCount CURRENT_ENEMYCOUNT = EnemyCount.medium;
	public ItemCount CURRENT_ITEMCOUNT = ItemCount.medium;
	public LevelLength CURRENT_LEVELLENGTH = LevelLength.medium;

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
}
