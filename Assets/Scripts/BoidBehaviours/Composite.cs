using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Scripts.BoidBehaviours
{
    [CreateAssetMenu(menuName = "Boid Behaviour/Composite")]
    public class Composite : BoidBehaviour
    {
        [SerializeField]
        private List<BoidBehaviour> m_boidBehaviours = new List<BoidBehaviour>();

        public override Vector2 CalculateMove(Boid boid)
        {
            Assert.IsTrue(boid != null);

            Vector2 compositeMove = Vector2.zero;

            foreach (var behaviour in m_boidBehaviours)
            {
                compositeMove += behaviour.CalculateMove(boid); // TODO: Add weight/force to each behaviour.
            }

            compositeMove /= m_boidBehaviours.Count;
            compositeMove.Normalize();

            return compositeMove;
        }
    }
}
