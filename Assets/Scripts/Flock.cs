using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    private readonly IList<Boid> m_boids = new List<Boid>();

    [SerializeField]
    private uint numberOfBoids = 128;

    [SerializeField]
    private Boid m_boidPrefab = null;

    [SerializeField]
    private BoidBehaviour m_boidBehaviour = null;
}
