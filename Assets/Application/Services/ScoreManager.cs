using UnityEngine;

public class ScoreManager : IScoreManager
{
    private int _score;
    public void AddScore(int score)
    {
        _score += score;
    }

    public int GetScore()
    {
        return _score;
    }

    public void ResetScore()
    {
        _score = 0;
    }
}
