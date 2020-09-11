using System.Collections.Generic;
using UnityEngine;

public class BoidPerceptionComponent : MonoBehaviour
{
    private const int INITIAL_PERCEPTION_CAPACITY = 128;

    private ICollection<GameObject> m_innerPerceivedObjects = new List<GameObject>(INITIAL_PERCEPTION_CAPACITY);
    private ICollection<GameObject> m_outerPerceivedObjects = new List<GameObject>(INITIAL_PERCEPTION_CAPACITY);

    [SerializeField]
    private float m_innerPerceptionRadius = 1.0f;

    [SerializeField]
    private float m_outerPerceptionRadius = 4.0f;

    [SerializeField]
    private LayerMask m_perceptionLayer = new LayerMask();

    public ICollection<GameObject> GetInnerPerceivedObjects()
    {
        this.GetPerceivedObjectsInRadius(m_innerPerceptionRadius, ref m_innerPerceivedObjects);

        return m_innerPerceivedObjects;
    }

    public ICollection<GameObject> GetOuterPerceivedObjects()
    {
        this.GetPerceivedObjectsInRadius(m_outerPerceptionRadius, ref m_outerPerceivedObjects);

        return m_outerPerceivedObjects;
    }

    private ICollection<GameObject> GetPerceivedObjectsInRadius(float radius, ref ICollection<GameObject> perceivedObjects)
    {
        perceivedObjects.Clear();

        Collider2D[] perceivedColliders = Physics2D.OverlapCircleAll(this.transform.position, radius, m_perceptionLayer);

        foreach (var collider in perceivedColliders)
        {
            perceivedObjects.Add(collider.gameObject);
        }

        perceivedObjects.Remove(this.gameObject);

        return perceivedObjects;
    }
}
