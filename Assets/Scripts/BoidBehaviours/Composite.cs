using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Scripts.BoidBehaviours
{
    [CreateAssetMenu(menuName = "Boid Behaviour/Composite")]
    public class Composite : BoidBehaviour
    {
        [SerializeField]
        private List<BoidBehaviourWeightPair> m_pairs = new List<BoidBehaviourWeightPair>();

        public override Vector2 CalculateMove(Boid boid)
        {
            Assert.IsTrue(boid != null);

            Vector2 compositeMove = Vector2.zero;

            foreach (var pair in m_pairs)
            {
                BoidBehaviour behaviour = pair.BoidBehaviour;
                float weight = pair.Weight;
                compositeMove += (behaviour.CalculateMove(boid).normalized * weight);
            }

            compositeMove /= m_pairs.Count;
            compositeMove.Normalize();

            return compositeMove;
        }

        [System.Serializable]
        private class BoidBehaviourWeightPair
        {
            public BoidBehaviour BoidBehaviour = null;

            [Range(0.0f, 1.0f)]
            public float Weight = 1.0f;
        }
    }
}
