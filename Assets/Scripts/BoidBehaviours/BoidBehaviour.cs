using UnityEngine;

namespace Scripts.BoidBehaviours
{
    public abstract class BoidBehaviour : ScriptableObject
    {
        public abstract Vector2 CalculateMove(Boid boid);
    }
}
