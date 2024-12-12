using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Core.Entities
{
    public class Pipe
    {
        public float MovementSpeed { get; private set; }
        public float MaxLeftPoint { get; private set; }
        public Pipe(float movementSpeed, float maxLeftPoint)
        {
            MovementSpeed = movementSpeed;
            MaxLeftPoint = maxLeftPoint;
        }

        public Vector3 CalculateMovement(Vector3 currentPosition)
        {
            return currentPosition + ( Vector3.left * MovementSpeed * Time.deltaTime);
        }

        public bool IsPipeInDeadZone(Vector3 currentPosition)
        {
            return   currentPosition.x < MaxLeftPoint;
        }
    }
}
