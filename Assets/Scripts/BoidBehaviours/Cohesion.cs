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

            Vector2 cohesionMove = Vector2.zero;

            foreach (var gameObject in perceivedObjects)
            {
                cohesionMove += (Vector2)gameObject.transform.position;
            }

            cohesionMove /= perceivedObjects.Count;
            cohesionMove -= (Vector2)boid.transform.position;
            cohesionMove.Normalize();

            return cohesionMove;
        }
    }
}
