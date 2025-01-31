using UnityEngine;

public class Justice : TarotAbility
{
    public void Execute()
    {
        // Access the ScoreManager instance
        if (ScoreManager.Instance != null)
        {
            // score multiplier
            ScoreManager.Instance.scoreMultiplier += 0.25f;
            Debug.Log("Justice ability activated! Score multiplier increased to: " + ScoreManager.Instance.scoreMultiplier);
        }
        else
        {
            Debug.LogWarning("ScoreManager instance not found.");
        }
    }
}
