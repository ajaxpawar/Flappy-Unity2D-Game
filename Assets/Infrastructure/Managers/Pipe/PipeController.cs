using Assets.Core.Entities;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    float MaxLeftPoint = -10.5f;
    float MovementSpeed = 2;
    private Pipe _pipe;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _pipe = new Pipe(MovementSpeed,MaxLeftPoint);
    }

    // Update is called once per frame
    void Update()
    {
        MoveToLeft();
        DestroyPipeIfCrossMaxLimit();
    }
    void MoveToLeft()
    {
        if (GameManager.instance.IsGameOn)
        {
            transform.position = _pipe.CalculateMovement(transform.position);
        }
    }
    void DestroyPipeIfCrossMaxLimit()
    {
        if (_pipe.IsPipeInDeadZone(transform.position))
        {
            Destroy(gameObject);
        }
    }
}
