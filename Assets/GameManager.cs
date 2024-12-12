using Assets.Application.Services;
using Assets.Core.Constants;
using Assets.Core.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool IsGameOn;
    public int PlayerScore;
    private IScoreManager _scoreManager;
    private IGameAudioManager _gameAudioManager;
    private void Awake()
    {
        MakeSingleton();
        _scoreManager = new ScoreManager();
        _gameAudioManager = new GameAudioManager(gameObject.GetComponent<AudioSource>());
        SetGameOn();

    }
    private void Start()
    {

    }
    private void Update()
    {
        
    }
    public int GetScore()
    {
        return _scoreManager.GetScore();
    }
    public void AddScore(int score)
    {
         _scoreManager.AddScore(score);
    } 
    public void ResetGame()
    {
         _scoreManager.ResetScore();
        SetGameOn();
        _gameAudioManager.PlayBackgroundAudio();
    }
    private void MakeSingleton()
    {
        if(instance is not null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void SetGameOn()
    {
        IsGameOn = true;
    }
    public void SetGameOver()
    {
        Debug.Log("Game Over");
        IsGameOn = false;
        _gameAudioManager.StopBackgroundAudio();
        SceneManager.LoadScene(GameScene.GAME_OVER);
    }
}
