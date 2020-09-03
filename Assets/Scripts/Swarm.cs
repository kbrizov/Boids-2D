﻿using Scripts.BoidBehaviours;
using System.Collections.Generic;
using UnityEngine;

public class Swarm : MonoBehaviour
{
    private readonly IList<Boid> m_boids = new List<Boid>();

    [SerializeField]
    [Range(0.0f, 256.0f)]
    private uint numberOfBoids = 64;

    [SerializeField]
    [Range(0.0f, 512.0f)]
    private uint spawnAreaRadius = 8;

    [SerializeField]
    private Boid m_boidPrefab = null;

    [SerializeField]
    private BoidBehaviour m_boidBehaviour = null;

    public void Awake()
    {
        for (int i = 0; i < numberOfBoids; i++)
        {
            Vector2 position = Random.insideUnitCircle * spawnAreaRadius;
            Quaternion rotation = Quaternion.Euler(Vector3.forward * Random.Range(0, 360));
            Boid boid = Instantiate(m_boidPrefab, position, rotation, parent: this.transform);

            m_boids.Add(boid);
        }
    }

    public void FixedUpdate()
    {
        foreach (var boid in m_boids)
        {
            Vector2 move = m_boidBehaviour.CalculateMove(boid);
            boid.Move(move);
        }
    }
}
