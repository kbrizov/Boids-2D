using System.Collections.Generic;
using UnityEngine;

public class BoidPerceptionComponent : MonoBehaviour
{
    [SerializeField]
    private float m_innerPerceptionRadius = 1.0f;

    [SerializeField]
    private float m_outerPerceptionRadius = 4.0f;

    [SerializeField]
    private LayerMask m_perceptionLayer = new LayerMask();

    public ICollection<GameObject> GetInnerPerceivedObjects()
    {
        return this.GetPerceivedObjectsInRadius(m_innerPerceptionRadius);
    }

    public ICollection<GameObject> GetOuterPerceivedObjects()
    {
        return this.GetPerceivedObjectsInRadius(m_outerPerceptionRadius);
    }

    private ICollection<GameObject> GetPerceivedObjectsInRadius(float radius)
    {
        Collider2D[] perceivedColliders = Physics2D.OverlapCircleAll(this.transform.position, radius, m_perceptionLayer);
        ICollection<GameObject> perceivedObjects = new List<GameObject>(perceivedColliders.Length);

        foreach (var collider in perceivedColliders)
        {
            perceivedObjects.Add(collider.gameObject);
        }

        return perceivedObjects;
    }
}
