using UnityEngine;
using UnityEngine.Assertions;

namespace Scripts.BoidBehaviours
{
    [CreateAssetMenu(menuName = "Boid Behaviour/Stay In Radius")]
    public class StayInRadius : BoidBehaviour
    {
        [SerializeField]
        private Vector2 m_center = Vector2.zero;

        [SerializeField]
        [Range(0.0f, 100.0f)]
        private float m_radius = 10.0f;

        public override Vector2 CalculateMove(Boid boid)
        {
            Assert.IsTrue(boid != null);

            Vector2 directionToCenter = m_center - (Vector2)boid.transform.position;
            float distanceToCenter = directionToCenter.magnitude;

            if (m_radius < distanceToCenter)
            {
                return directionToCenter.normalized;
            }

            return Vector2.zero;
        }
    }
}
