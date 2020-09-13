using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Scripts.BoidBehaviours
{
    [CreateAssetMenu(menuName = "Boid Behaviour/Separation")]
    public class Separation : BoidBehaviour
    {
        public override Vector2 CalculateMove(Boid boid)
        {
            Assert.IsTrue(boid != null);
            ICollection<GameObject> perceivedObjects = boid.PerceptionComponent.GetInnerPerceivedObjects();

            if (perceivedObjects.Count == 0)
            {
                return Vector2.zero;
            }

            Vector2 separationMove = Vector2.zero;

            foreach (var gameObject in perceivedObjects)
            {
                separationMove += (Vector2)(boid.transform.position - gameObject.transform.position);
            }

            separationMove /= perceivedObjects.Count;
            separationMove.Normalize();

            return separationMove;
        }
    }
}
