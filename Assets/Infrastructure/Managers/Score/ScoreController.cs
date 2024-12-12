using Assets.Core.Constants;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private Text _score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _score = GameObject.FindWithTag(Tags.PlayerScore).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.AddScore(1);
        _score.text = GameManager.instance.GetScore().ToString();
    }
}
