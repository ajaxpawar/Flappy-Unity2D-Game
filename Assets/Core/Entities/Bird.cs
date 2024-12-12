using UnityEngine;

public class Bird
{
    public float MovementForce { get;private set; }
    public Bird(float movementForce)
    {
        MovementForce = movementForce;
    }
    public Vector2 CalculateMovement()
    {
        return Vector2.up * MovementForce;
    }
}
