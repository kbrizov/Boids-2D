using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Scripts.BoidBehaviours
{
    [CreateAssetMenu(menuName = "Boid Behaviour/Cohesion")]
    public class Cohesion : BoidBehaviour
    {
        public override Vector2 CalculateMove(Boid boid)
        {
            Assert.IsTrue(boid != null);

            ICollection<GameObject> perceivedObjects = boid.PerceptionComponent.GetOuterPerceivedObjects();

            if (perceivedObjects.Count == 0)
            {
                return Vector2.zero;
            }

            Vector2 move = Vector2.zero;

            foreach (var gameObject in perceivedObjects)
            {
                move += (Vector2)gameObject.transform.position;
            }

            move /= perceivedObjects.Count;
            move -= (Vector2)boid.transform.position;

            return move;
        }
    }
}
