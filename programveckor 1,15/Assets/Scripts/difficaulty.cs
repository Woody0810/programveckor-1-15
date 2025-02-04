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
    public static void SetDifficulty(Difficulty difficulty)
    {
        CurrentDifficulty = difficulty;

        switch (difficulty)
        {
            case Difficulty.Easy:
                PlayerPrefs.SetFloat("EnemyHealthMultiplier", 0.6f);
                PlayerPrefs.SetFloat("EnemySpeedMultiplier", 0.6f);
                PlayerPrefs.SetFloat("PlayerHealthMultiplier", 1.2f);
                Debug.Log("playerhealthinscript " + PlayerPrefs.GetFloat("PlayerHealthMultiplier"));
                enemyHealthMultiplier = 0.6f;
                enemySpeedMultiplier = 0.6f;
                playerHealthMultiplier = 1.2f;
                break;

            case Difficulty.Medium:
                PlayerPrefs.SetFloat("EnemyHealthMultiplier", 1);
                PlayerPrefs.SetFloat("EnemySpeedMultiplier", 1);
                PlayerPrefs.SetFloat("PlayerHealthMultiplier", 1);
                enemyHealthMultiplier = 1.0f;
                enemySpeedMultiplier = 1.0f;
                playerHealthMultiplier = 1.0f;
                break;

            case Difficulty.Hard:
                PlayerPrefs.SetFloat("EnemyHealthMultiplier", 1.2f);
                PlayerPrefs.SetFloat("EnemySpeedMultiplier", 1.2f);
                PlayerPrefs.SetFloat("PlayerHealthMultiplier", 0.8f);
                enemyHealthMultiplier = 1.5f;
                enemySpeedMultiplier = 1.5f;
                playerHealthMultiplier = 0.8f;
                break;
        }
    }
}
