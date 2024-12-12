using UnityEngine;

public interface IScoreManager
{
    public int  GetScore();
    public void AddScore(int score);
    public void ResetScore();
}
