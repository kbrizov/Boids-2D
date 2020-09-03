using UnityEngine;

public class Swarm : MonoBehaviour
{
    [SerializeField]
    [Range(0, 256)]
    private uint numberOfBoids = 32;

    [SerializeField]
    [Range(0, 256)]
    private uint spawnAreaRadius = 8;

    [SerializeField]
    private Boid m_boidPrefab = null;

    public void Awake()
    {
        for (int i = 0; i < numberOfBoids; i++)
        {
            Vector2 position = Random.insideUnitCircle * spawnAreaRadius;
            Quaternion rotation = Quaternion.Euler(Vector3.forward * Random.Range(0, 360));
            Instantiate(m_boidPrefab, position, rotation, parent: this.transform);
        }
    }
}
