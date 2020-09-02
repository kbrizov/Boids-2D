using System.Collections.Generic;
using UnityEngine;

public abstract class BoidBehaviour : ScriptableObject
{
    public abstract Vector2 CalculateVelocity(Boid boid, IEnumerable<Transform> context);
}
