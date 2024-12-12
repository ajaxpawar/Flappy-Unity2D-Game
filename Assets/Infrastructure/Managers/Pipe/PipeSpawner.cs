using System.Collections;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    private float _spawnRate = 6f;
    private float _lowestPossibleSpawnRate = 1.4f;
    private float _reduceRateBy = 0.2f;
    public float HightRatio=0.8f;
    private int _rateChangeByScore = 10;
    private int _lastCheckedScore = 0; // To keep track of when to adjust the spawn rate
    [SerializeField]
    private GameObject[] _pipeRefs;
    private GameObject _pipe;
    void Start()
    {

        StartCoroutine(SpawnPipe());
    }
    void Update()
    {
        if (GameManager.instance.GetScore() >= _lastCheckedScore + _rateChangeByScore)
        {
            _lastCheckedScore = GameManager.instance.GetScore();
            IncreaseSpawnRate();
        }
    }
    IEnumerator SpawnPipe()
    {


        while (GameManager.instance.IsGameOn)
        //while (true)
        {
            yield return new WaitForSeconds(_spawnRate);
            int PipesRandomIndex;
            float HigestPoint = transform.position.y + HightRatio;
            float LowestPoint = transform.position.y - HightRatio;
            PipesRandomIndex = Random.Range(0, _pipeRefs.Length);
            _pipe = _pipeRefs[PipesRandomIndex];
            Instantiate(_pipe, new Vector3(transform.position.x, Random.Range(LowestPoint, HigestPoint), 0f), transform.rotation);
        }

    }
    private void IncreaseSpawnRate()
    {
        if (_spawnRate > _lowestPossibleSpawnRate) // Limit to prevent the spawn rate from becoming too fast
        {
            _spawnRate -= _reduceRateBy; // Decrease the spawn rate by 0.2 seconds
        }
    }
}
