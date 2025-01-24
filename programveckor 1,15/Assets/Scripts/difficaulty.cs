using UnityEngine;

public enum Difficulty
{
    Easy,
    Medium,
    Hard
}

public class DifficultyManager : MonoBehaviour
{
    public static Difficulty CurrentDifficulty { get; private set; } = Difficulty.Medium;

    public static float enemyHealthMultiplier;
    public static float enemySpeedMultiplier;
    public static float playerHealthMultiplier;

    // Call this method to set the difficulty
    public static void SetDifficulty(Difficulty difficulty)
    {
        CurrentDifficulty = difficulty;

        switch (difficulty)
        {
            case Difficulty.Easy:
                enemyHealthMultiplier = 0.6f;
                enemySpeedMultiplier = 0.6f;
                playerHealthMultiplier = 1.2f;
                break;

            case Difficulty.Medium:
                enemyHealthMultiplier = 1.0f;
                enemySpeedMultiplier = 1.0f;
                playerHealthMultiplier = 1.0f;
                break;

            case Difficulty.Hard:
                enemyHealthMultiplier = 1.5f;
                enemySpeedMultiplier = 1.5f;
                playerHealthMultiplier = 0.8f;
                break;
        }
    }
}
