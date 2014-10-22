using UnityEngine;
using System.Collections;

public class DifficultyManager {

	public enum Difficulty {easy, medium, hard}
	public enum EnemyCount {low, medium, high}
	public enum ItemCount {low, medium, high}
	public enum LevelLength {low, medium, high}

	public static Difficulty CURRENT_DIFFICULTY = Difficulty.medium;
	public static EnemyCount CURRENT_ENEMYCOUNT = EnemyCount.medium;
	public static ItemCount CURRENT_ITEMCOUNT = ItemCount.medium;
	public static LevelLength CURRENT_LEVELLENGTH = LevelLength.medium;

	private DifficultyManager(){}


}
