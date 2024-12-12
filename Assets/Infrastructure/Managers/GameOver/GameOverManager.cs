using Assets.Core.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    private Text _gameOverScore;
    private void Start()
    {
        _gameOverScore.text = $"Score : {GameManager.instance.GetScore()}";

    }
    public void RestartGame()
    {
        // Reload the GamePlay scene
        GameManager.instance.ResetGame();
        GameManager.instance.SetGameOn();
        SceneManager.LoadScene(GameScene.GAME_PLAY);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        // Quit the application
        Application.Quit();
    }
}
