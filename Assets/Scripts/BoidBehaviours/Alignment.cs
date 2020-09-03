using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Scripts.BoidBehaviours
{
    [CreateAssetMenu(menuName = "Boid Behaviour/Alignment")]
    public class Alignment : BoidBehaviour
    {
        public override Vector2 CalculateMove(Boid boid)
        {
            Assert.IsTrue(boid != null);
            ICollection<GameObject> perceivedObjects = boid.PerceptionComponent.GetOuterPerceivedObjects();

            if (perceivedObjects.Count == 0)
            {
                return boid.transform.up;
            }

            Vector2 alignmentMove = Vector2.zero;

            foreach (var gameObject in perceivedObjects)
            {
                alignmentMove += (Vector2)gameObject.transform.up;
            }

            alignmentMove /= perceivedObjects.Count;

            return alignmentMove;
        }
    }
}
